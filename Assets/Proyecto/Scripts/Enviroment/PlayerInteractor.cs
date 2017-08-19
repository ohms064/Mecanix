using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour {
    public float grabDistance = 10f;
    [SerializeField]Transform grabPosition, boxGrabPosition;
    Transform grabbedObject;
    public ItemData grabbedObjectData;
    Camera cameraOrigin;
    int layerMask;
    const int ITEM_LAYER = 9;
    [HideInInspector] public bool secondInteraction;
    public OVRInput.Button button = OVRInput.Button.One;
    [SerializeField] EventBehaviour[] events;
    public InputReceiver input;

	// Use this for initialization
	void Start () {
        input.Reset();
        cameraOrigin = GameManager.instance.mainCameraRig.rightEyeCamera;
        layerMask = LayerMask.GetMask( "Item", "Interactive" );
        StartCoroutine( input.CheckDoubleClick() );
    }
	
	// Update is called once per frame
	void Update () {
        if (
#if UNITY_ANDROID
            input.grabInteraction
#endif
#if !UNITY_EDITOR && !UNITY_STANDALONE
            || OVRInput.GetDown( button ) || Input.anyKeyDown
#endif
            ) {
            TryInteract();
            input.grabInteraction = false;
        }
        input.click = Input.GetMouseButtonDown( 0 );
	}

    void TryInteract() {
        Transform origin = cameraOrigin.transform;
        RaycastHit hit;
        if ( Physics.Raycast( origin.position, origin.forward.normalized, out hit, grabDistance, layerMask ) ) {
            var inter = hit.transform.GetComponent<InteractiveBehaviour>();
            if ( inter != null ) {
                if ( inter.Equals( grabbedObjectData ) ) {
                    secondInteraction = true;
                    grabbedObjectData.Interact( this );
                    secondInteraction = false;
                }
                else {
                    inter.Interact( this );
                }
            }
        }
        else if ( grabbedObject != null ) {
            secondInteraction = true;
            grabbedObjectData.Interact( this );
            secondInteraction = false;
        }
    }

    public Transform Drop() {
        Transform droppedObject = grabbedObject;
        grabbedObject.parent = null;
        grabbedObject = null;
        grabbedObjectData = null;
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].EndEvent();
        }
        if ( DebugUI.instance != null ) {
            DebugUI.instance.Log( "" );
        }
        return droppedObject;
    }

    public void Grab(ItemData hit) {
        if ( grabbedObject != null ) {
            return;
        }
        grabbedObject = hit.transform;
        grabbedObjectData = hit;
        if ( hit.data.grab ) {
            grabbedObject.position = boxGrabPosition.position;
        }
        else {
            grabbedObject.position = grabPosition.position;
        }
        
        grabbedObject.parent = grabPosition; //TODO: This must be temporal!
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].OnActivate(hit.data);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if ( cameraOrigin == null )
            return;
        Transform origin = cameraOrigin.transform;
        Gizmos.DrawRay( origin.position, origin.forward );
    }
#endif
}
