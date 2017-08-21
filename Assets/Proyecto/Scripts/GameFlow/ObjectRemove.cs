using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType {
    VR, PC
}
public class ObjectRemove : MonoBehaviour {
    public ObjectType type;

    private void Awake() {
        switch ( type ) {
            case ObjectType.VR:
#if UNITY_STANDALONE
                Destroy( gameObject );
#endif
                break;
            case ObjectType.PC:
#if UNITY_ANDROID
                Destroy(gameobject);
#endif
                break;
            default:
                break;
        }
    }
}
