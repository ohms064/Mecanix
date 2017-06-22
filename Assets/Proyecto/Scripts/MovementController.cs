using UnityEngine;

public class MovementController : OVRPlayerController {


    protected override void Awake() {
        base.Awake();

    }

    protected override void UpdateController() {
        if ( useProfileData ) {
            if ( InitialPose == null ) {
                // Save the initial pose so it can be recovered if useProfileData
                // is turned off later.
                InitialPose = new OVRPose() {
                    position = CameraRig.transform.localPosition,
                    orientation = CameraRig.transform.localRotation
                };
            }

            var p = CameraRig.transform.localPosition;
            if ( OVRManager.instance.trackingOriginType == OVRManager.TrackingOrigin.EyeLevel ) {
                p.y = OVRManager.profile.eyeHeight - (0.5f * Controller.height) + Controller.center.y;
            }
            else if ( OVRManager.instance.trackingOriginType == OVRManager.TrackingOrigin.FloorLevel ) {
                p.y = -(0.5f * Controller.height) + Controller.center.y;
            }
            CameraRig.transform.localPosition = p;
        }
        else if ( InitialPose != null ) {
            // Return to the initial pose if useProfileData was turned off at runtime
            CameraRig.transform.localPosition = InitialPose.Value.position;
            CameraRig.transform.localRotation = InitialPose.Value.orientation;
            InitialPose = null;
        }

        UpdateMovement();

        Vector3 moveDirection = Vector3.zero;

        float motorDamp = (1.0f + (Damping * SimulationRate * Time.deltaTime));

        MoveThrottle.x /= motorDamp;
        //MoveThrottle.y = (MoveThrottle.y > 0.0f) ? (MoveThrottle.y / motorDamp) : MoveThrottle.y;
        MoveThrottle.y /= motorDamp;
        MoveThrottle.z /= motorDamp;

        if ( DebugUI.instance != null )
            DebugUI.instance.print( string.Format( "Throttle 4: {0} Final", MoveThrottle ) );

        moveDirection += MoveThrottle * SimulationRate * Time.deltaTime;

        // Gravity
        if ( Controller.isGrounded && FallSpeed <= 0 )
            FallSpeed = ((Physics.gravity.y * (GravityModifier * 0.002f)));
        else
            FallSpeed += ((Physics.gravity.y * (GravityModifier * 0.002f)) * SimulationRate * Time.deltaTime);

        moveDirection.y += FallSpeed * SimulationRate * Time.deltaTime;

        // Offset correction for uneven ground
        float bumpUpOffset = 0.0f;

        if ( Controller.isGrounded && MoveThrottle.y <= transform.lossyScale.y * 0.001f ) {
            bumpUpOffset = Mathf.Max( Controller.stepOffset, new Vector3( moveDirection.x, 0, moveDirection.z ).magnitude );
            moveDirection -= bumpUpOffset * Vector3.up;
        }

        Vector3 predictedXZ = Vector3.Scale( (Controller.transform.localPosition + moveDirection), new Vector3( 1, 0, 1 ) );

        // Move contoller
        Debug.Log( string.Format( "moveDirection: {0}", moveDirection ) );
        if ( DebugUI.instance != null )
            DebugUI.instance.print( string.Format( "moveDirection: {0}", moveDirection ) );
        Controller.Move( moveDirection );

        Vector3 actualXZ = Vector3.Scale( Controller.transform.localPosition, new Vector3( 1, 0, 1 ) );

        if ( predictedXZ != actualXZ )
            MoveThrottle += (actualXZ - predictedXZ) / (SimulationRate * Time.deltaTime);
    }

    public override void UpdateMovement() {
        if ( HaltUpdateMovement )
            return;

        bool moveForward = Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow );
        bool moveLeft = Input.GetKey( KeyCode.A ) || Input.GetKey( KeyCode.LeftArrow );
        bool moveRight = Input.GetKey( KeyCode.D ) || Input.GetKey( KeyCode.RightArrow );
        bool moveBack = Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow );

        bool dpad_move = false;

        if ( OVRInput.Get( OVRInput.Button.DpadUp ) ) {
            moveForward = true;
            dpad_move = true;

        }

        if ( OVRInput.Get( OVRInput.Button.DpadDown ) ) {
            moveBack = true;
            dpad_move = true;
        }

        MoveScale = 1.0f;

        if ( (moveForward && moveLeft) || (moveForward && moveRight) ||
             (moveBack && moveLeft) || (moveBack && moveRight) )
            MoveScale = 0.70710678f;
        /*
        // No positional movement if we are in the air
        if ( !Controller.isGrounded )
            MoveScale = 0.0f;
        */

        MoveScale *= SimulationRate * Time.deltaTime;

        // Compute this for key movement
        float moveInfluence = Acceleration * 0.1f * MoveScale * MoveScaleMultiplier;

        // Run!
        if ( dpad_move || Input.GetKey( KeyCode.LeftShift ) || Input.GetKey( KeyCode.RightShift ) )
            moveInfluence *= 2.0f;

        Quaternion ort = transform.rotation;
        Vector3 ortEuler = ort.eulerAngles;
        ortEuler.z = ortEuler.x = 0f;
        ort = Quaternion.Euler( ortEuler );
        if ( DebugUI.instance != null )
            DebugUI.instance.print( string.Format( "Throttle 1: {0} Initial Value", MoveThrottle ) );

        if ( moveForward ) {
            MoveThrottle += ort * ( transform.lossyScale.z * moveInfluence * Vector3.forward ); 
        }
        if ( moveBack )
            MoveThrottle += ort * (transform.lossyScale.z * moveInfluence * BackAndSideDampen * Vector3.back);
        if ( moveLeft )
            MoveThrottle += ort * (transform.lossyScale.x * moveInfluence * BackAndSideDampen * Vector3.left);
        if ( moveRight )
            MoveThrottle += ort * (transform.lossyScale.x * moveInfluence * BackAndSideDampen * Vector3.right);

        Vector3 euler = transform.rotation.eulerAngles;

        if ( DebugUI.instance != null )
            DebugUI.instance.print( string.Format( "Throttle 2: {0} Post Pad input", MoveThrottle ) );

        bool curHatLeft = OVRInput.Get( OVRInput.Button.PrimaryShoulder );

        if ( curHatLeft && !prevHatLeft )
            euler.y -= RotationRatchet;

        prevHatLeft = curHatLeft;

        bool curHatRight = OVRInput.Get( OVRInput.Button.SecondaryShoulder );

        if ( curHatRight && !prevHatRight )
            euler.y += RotationRatchet;

        prevHatRight = curHatRight;

        euler.y += buttonRotation;
        buttonRotation = 0f;

        float rotateInfluence = SimulationRate * Time.deltaTime * RotationAmount * RotationScaleMultiplier;

#if !UNITY_ANDROID || UNITY_EDITOR
        if ( !SkipMouseRotation )
            euler.y += Input.GetAxis( "Mouse X" ) * rotateInfluence * 3.25f;
#endif

        moveInfluence = Acceleration * 0.1f * MoveScale * MoveScaleMultiplier;

#if !UNITY_ANDROID // LeftTrigger not avail on Android game pad
		moveInfluence *= 1.0f + OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
#endif

        Vector2 primaryAxis = OVRInput.Get( OVRInput.Axis2D.PrimaryThumbstick );

        Debug.Log( string.Format( "Axis:{0}", primaryAxis ) );

        MoveThrottle += CameraRig.rightEyeCamera.transform.forward * primaryAxis.y;
        MoveThrottle += CameraRig.rightEyeCamera.transform.right * primaryAxis.x;

        if ( DebugUI.instance != null )
            DebugUI.instance.print( string.Format( "Camera Forward: {0}Right {1}", CameraRig.rightEyeCamera.transform.forward, CameraRig.rightEyeCamera.transform.right ) );

        /*
        if ( primaryAxis.y > 0.0f )
            MoveThrottle += ort * (primaryAxis.y * transform.lossyScale.z * moveInfluence * Vector3.forward);

        if ( primaryAxis.y < 0.0f )
            MoveThrottle += ort * (Mathf.Abs( primaryAxis.y ) * transform.lossyScale.z * moveInfluence * BackAndSideDampen * Vector3.back);

        if ( primaryAxis.x < 0.0f )
            MoveThrottle += ort * (Mathf.Abs( primaryAxis.x ) * transform.lossyScale.x * moveInfluence * BackAndSideDampen * Vector3.left);

        if ( primaryAxis.x > 0.0f )
            MoveThrottle += ort * (primaryAxis.x * transform.lossyScale.x * moveInfluence * BackAndSideDampen * Vector3.right);
        */
        Vector2 secondaryAxis = OVRInput.Get( OVRInput.Axis2D.SecondaryThumbstick );
        if ( DebugUI.instance != null )
            DebugUI.instance.print( string.Format( "Throttle 3: {0} Post Axis Input", MoveThrottle ) );

        euler.y += secondaryAxis.x * rotateInfluence;

        Debug.LogFormat( "Euler Angles: {0}", euler );

        transform.rotation = Quaternion.Euler( euler );
    }
}
