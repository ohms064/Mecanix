using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHold : Door {
    private float t = 0;
    private float animInverse;

    private new void Start() {
        origin = this.transform.position;
        animInverse = animationDuration;
    }

    public override void Interact( PlayerInteractor interactor ) {
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        if ( interactor.message ){
            if ( !data.IsActive ) {
                data.IsActive = true;
                if ( !isOpen ) {
                    StopCoroutine( Close() );
                }
                StartCoroutine( Open() );
            }
        }
        else{
            if ( data.IsActive ) {
                data.IsActive = false;
                if ( isOpen ) {
                    StopCoroutine( Open() );
                }
                StartCoroutine( Close() );
            }
        }
    }

    protected override IEnumerator Open() {
        float beginTime = Time.timeSinceLevelLoad;
        isOpen = true;
        while ( t < 1 ) {
            t += Time.deltaTime * animInverse;
            transform.position = Vector3.Lerp( origin, destiny, t );
            yield return new WaitForEndOfFrame();
        }
    }

    protected override IEnumerator Close() {
        float beginTime = Time.timeSinceLevelLoad;
        isOpen = false;
        while ( t > 0 ) {
            t -= Time.deltaTime * animInverse;
            transform.position = Vector3.Lerp( origin, destiny, t );
            yield return new WaitForEndOfFrame();
        }       
    }
}
