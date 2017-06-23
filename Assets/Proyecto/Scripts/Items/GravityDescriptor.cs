using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "LevelManager/Status/Create Gravity Data" )]
public class GravityDescriptor : Descriptor {
    public bool gravityOn;
    public event ObjectActivate ActivateGravity;
    public event ObjectDeactivate DeactivateGravity;

    public void Set(bool on) {
        gravityOn = on;
        if ( on ) {
            if ( ActivateGravity != null )
                ActivateGravity( this );
        }
        else {
            if ( DeactivateGravity != null )
                DeactivateGravity( this );
        }
    }

    
}
