using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "LevelManager/Status/Create Gravity Data" )]
public class GravityDescriptor : Descriptor {
    public event ObjectActivate ActivateGravity;
    public event ObjectDeactivate DeactivateGravity;
    public Vector3 gravityValue, noGravityValue;
    public float shiftDuration = 1;
    public float gravityDuration = 30f;

    public void Set( bool on ) {
        isActive = on;
        if ( on ) {
            if ( ActivateGravity != null )
                ActivateGravity( this );
            Physics.gravity = gravityValue;
        }
        else {
            if ( DeactivateGravity != null )
                DeactivateGravity( this );
            Physics.gravity = noGravityValue;
        }
    }

    public void Set( bool on, MonoBehaviour behaviour ) {
        isActive = on;
        if ( on ) {
            if ( ActivateGravity != null )
                ActivateGravity( this );
            behaviour.StartCoroutine( Activate(behaviour) );
        }
        else {
            if ( DeactivateGravity != null )
                DeactivateGravity( this );
            behaviour.StopAllCoroutines();
            behaviour.StartCoroutine( Deactivate(behaviour));
        }
    }

    IEnumerator Activate( MonoBehaviour behaviour ) {
        float t = 0;
        float time = Time.timeSinceLevelLoad;
        while ( t < 1f ) {
            Physics.gravity = Vector3.Lerp( noGravityValue, gravityValue, t );
            yield return new WaitForEndOfFrame();
            t = (Time.timeSinceLevelLoad - time) / shiftDuration;
        }
    }

    IEnumerator Deactivate( MonoBehaviour behaviour ) {
        float t = 0;
        float time = Time.timeSinceLevelLoad;
        while ( t < 1f ) {
            Physics.gravity = Vector3.Lerp( gravityValue, noGravityValue, t );
            yield return new WaitForEndOfFrame();
            t = (Time.timeSinceLevelLoad - time) / shiftDuration;
        }
        yield return new WaitForSeconds( gravityDuration );
        if ( !isActive ) {
            Set( true, behaviour );
        }
    }


}
