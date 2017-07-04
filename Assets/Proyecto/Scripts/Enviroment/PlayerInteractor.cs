using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour {
    public float grabDistance = 10f;
    [SerializeField]Transform grabPosition;
    Transform grabbedObject;
    public ItemData grabbedObjectData;
    Camera cameraOrigin;
    int layerMask;
    const int ITEM_LAYER = 9;
    [HideInInspector] public bool secondInteraction;
    public OVRInput.Button button = OVRInput.Button.One;

	// Use this for initialization
	void Start () {
        cameraOrigin = GameManager.instance.mainCameraRig.rightEyeCamera;
        layerMask = LayerMask.GetMask( "Item", "Interactive" );
    }
	
	// Update is called once per frame
	void Update () {

        if (
#if UNITY_EDITOR
            Input.GetMouseButtonDown(0)
#else
            OVRInput.GetDown( button ) 
#endif
            ) {        
            TryInteract();
        }        
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
        else if(grabbedObject != null){
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
        return droppedObject;
    }

    public void Grab(ItemData hit) {
        if ( grabbedObject != null ) {
            return;
        }
        grabbedObject = hit.transform;
        grabbedObjectData = hit;
        grabbedObject.position = grabPosition.position;
        grabbedObject.parent = grabPosition; //TODO: This must be temporal!
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
