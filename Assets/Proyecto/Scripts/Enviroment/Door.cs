using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractiveBehaviour {
    public DoorDescriptor data;
    [SerializeField] DoorTrigger trigger;
    [SerializeField] protected float animationDuration = 1f, openDuration;
    protected bool isAnimating = false, isOpen = false;
    protected Vector3 origin;
    [SerializeField] protected Vector3 destiny;

    protected void Start() {
        origin = transform.position;
    }

    public override void Interact( PlayerInteractor interactor ) {
        if ( !data.IsActive || isAnimating || isOpen)
            return;
        //SceneManagement and open animation
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        if ( interactor.message )
            data.IsActive = true;
        else if(data.IsActive){
            isAnimating = true;
            StartCoroutine( data.DoorDelay() );
        }
    }

    protected virtual IEnumerator Open() {
        float t = 0;
        float beginTime = Time.timeSinceLevelLoad;
        while ( t < 1 ) {
            t = (Time.timeSinceLevelLoad - beginTime) / animationDuration;
            transform.position = Vector3.Lerp( origin, destiny, t );
            yield return new WaitForEndOfFrame();
        }
        isAnimating = false;
        isOpen = true;
        do {
            yield return new WaitForSeconds( openDuration );
        } while ( trigger != null && trigger.isInside );
        StartCoroutine( "Close" );
    }

    protected virtual IEnumerator Close() {
        float t = 0;
        float beginTime = Time.timeSinceLevelLoad;
        isAnimating = true;
        while ( t < 1 ) {
            t = (Time.timeSinceLevelLoad - beginTime) / animationDuration;
            transform.position = Vector3.Lerp( destiny, origin, t );
            yield return new WaitForEndOfFrame();
        }
        isAnimating = false;
        isOpen = false;
        //isRightScene = GameManager.instance.player.transform.position.x - transform.position.x > 0; // false if player is on left of the door
    }

    // This function is called when the object becomes enabled and active
    protected void OnEnable() {
        data.SceneLoadingFinish += OnSceneLoaded;
        data.StartSceneLoading += OnSceneLoadStart;
    }

    // This function is called when the behaviour becomes disabled or inactive
    protected void OnDisable() {
        data.SceneLoadingFinish -= OnSceneLoaded;
        data.StartSceneLoading -= OnSceneLoadStart;
    }

    public void OnSceneLoaded() {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        StartCoroutine( "Open" );
    }

    public void OnSceneLoadStart() {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void OnUnloadFinished() {
    }

    public override void Restart() {
        throw new NotImplementedException();
    }
}
