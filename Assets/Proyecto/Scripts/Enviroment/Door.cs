using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractiveBehaviour {
    public DoorDescriptor data;
    [SerializeField] DoorTrigger trigger;
    [SerializeField] protected float animationDuration = 1f, openDuration;
    protected bool isAnimating = false;
    public bool isOpen = false;
    protected Vector3 origin;
    [SerializeField] protected Vector3 destiny;
    public float messageDelay;
    [HideInInspector]public bool firstOpen = false;
    public AnalyticsManager analytics;

    public override void Start() {
        base.Start();
        origin = transform.position;
        destiny += origin;
        firstOpen = false;
    }

    public override void Interact( PlayerInteractor interactor ) {
        if ( !data.IsActive || isAnimating || isOpen)
            return;
        //SceneManagement and open animation
    }

    public override void Interact( InteractiveBehaviour interactor ) {
        if ( interactor.message && data.CanActivate() ) {
            data.IsActive = true;
            for ( int i = 0; i < events.Length; i++ ) {
                events[i].OnActivate(data);
            }
            StartCoroutine( OnActive() );
        }
        else if ( data.IsActive ) {
            isAnimating = true;
            if ( !firstOpen ) {
                firstOpen = true;
                analytics.AddDoor( data, Time.timeSinceLevelLoad );
            }
            StartCoroutine( data.DoorDelay() );
        }
    }

    IEnumerator OnActive() {
        yield return new WaitForSeconds(messageDelay);
        DebugUI.instance.Log( data.activeDescription );
    }

    protected virtual IEnumerator Open() {
        if ( isOpen ) {
            yield break;
        }
        float t = 0;
        float beginTime = Time.timeSinceLevelLoad;
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].StartEvent();
        }
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
        if ( !isOpen ) {
            yield break;
        }
        float t = 0;
        float beginTime = Time.timeSinceLevelLoad;
        isAnimating = true;
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].EndEvent();
        }
        while ( t < 1 ) {
            t = (Time.timeSinceLevelLoad - beginTime) / animationDuration;
            transform.position = Vector3.Lerp( destiny, origin, t );
            yield return new WaitForEndOfFrame();
        }
        isAnimating = false;
        isOpen = false;
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].EndEvent();
        }
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
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].StartEvent();
        }
        StartCoroutine( Open() );
    }

    public void OnSceneLoadStart() {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void OnUnloadFinished() {
    }

    public override void Restart() {
        
    }
}
