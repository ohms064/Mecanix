using UnityEngine;

[CreateAssetMenu( menuName = "LevelManager/Objects/Create Piloto" )]
public class PilotoDescriptor : ReceiverDescriptor {
    public Descriptor[] requiredObjects;
    [TextArea( 5, 10 )]
    public string successText, failedText;

    public bool canActivate() {
        for ( int i = 0; i < requiredObjects.Length; i++ ) {
            if ( !requiredObjects[i].IsActive ) {
                DebugUI.instance.Log( failedText );
                return false;
            }
        }
        return true;
    }
}

