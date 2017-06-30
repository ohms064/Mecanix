using UnityEngine;

[CreateAssetMenu( menuName = "LevelManager/Objects/Create Piloto" )]
class PilotoDescriptor : ReceiverDescriptor {
    public Descriptor[] requiredObjects;
    [TextArea( 5, 10 )]
    public string successText, failedText;

    public new bool canActivate() {
        for ( int i = 0; i < requiredObjects.Length; i++ ) {
            if ( !requiredObjects[i].isActive ) {
                Debug.Log( failedText );
                return false;
            }
        }
        Debug.Log( successText );
        return true;
    }
}

