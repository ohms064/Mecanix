using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "LevelManager/Status/Create Gravity Data" )]
public class GravityDescriptor : Descriptor {
    public event ObjectActivate ActivateGravity, DeactivateGravity;
    public Vector3 gravityValue, noGravityValue;
    public float shiftDuration = 1;
    public float gravityDuration = 30f;

    public void Set( bool on ) {
        IsActive = on;
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
        IsActive = on;
        if ( on ) {
            if ( ActivateGravity != null )
                ActivateGravity( this );
            behaviour.StartCoroutine( ActivateLerp(behaviour) );
        }
        else {
            if ( DeactivateGravity != null )
                DeactivateGravity( this );
            behaviour.StopAllCoroutines();
            behaviour.StartCoroutine( DeactivateLerp(behaviour));
        }
    }

    IEnumerator ActivateLerp( MonoBehaviour behaviour ) {
        float t = 0;
        float time = Time.timeSinceLevelLoad;
        while ( t < 1f ) {
            Physics.gravity = Vector3.Lerp( noGravityValue, gravityValue, t );
            yield return new WaitForEndOfFrame();
            t = (Time.timeSinceLevelLoad - time) / shiftDuration;
        }
    }

    IEnumerator DeactivateLerp( MonoBehaviour behaviour ) {
        float t = 0;
        float time = Time.timeSinceLevelLoad;
        while ( t < 1f ) {
            Physics.gravity = Vector3.Lerp( gravityValue, noGravityValue, t );
            yield return new WaitForEndOfFrame();
            t = (Time.timeSinceLevelLoad - time) / shiftDuration;
        }
        yield return new WaitForSeconds( gravityDuration );
        if ( !IsActive ) {
            Set( true, behaviour );
        }
    }


}
