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

	// Use this for initialization
	void Start () {
        cameraOrigin = GameManager.instance.mainCameraRig.rightEyeCamera;
        layerMask = LayerMask.GetMask( "Item", "Interactive" );
    }
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetMouseButtonDown( 0 ) ) {
            TryInteract();
        }
	}

    void TryInteract() {
        Transform origin = cameraOrigin.transform;
        RaycastHit hit;
        if ( Physics.Raycast( origin.position, origin.forward.normalized, out hit, grabDistance ) ) {
            var inter = hit.transform.GetComponent<InteractiveBehaviour>();
            if ( inter != null ) {
                inter.Interact( this );
            }
        }
        else if(grabbedObject != null){
            Drop();
        }
    }

    public Transform Drop() {
        Transform droppedObject = grabbedObject;
        grabbedObject.parent = null;
        grabbedObject = null;
        grabbedObjectData = null;
        return droppedObject;
    }

    public void Grab(Transform hit) {
        if ( grabbedObject != null ) {
            return;
        }
        grabbedObject = hit;
        grabbedObjectData = grabbedObject.GetComponent<ItemData>();
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
