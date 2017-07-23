using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEvent : EventBehaviour {
    [SerializeField] SceneLoaderScriptable manager;
    public float delay;
    public override void EndEvent() {
        
    }

    public override void OnActivate( Descriptor desc ) {
        StartCoroutine( LoadWait() );
    }

    public override void OnDeactivate( Descriptor desc ) {
        
    }

    public override void OnStart() {
        
    }

    public override void StartEvent() {
        
    }

    IEnumerator LoadWait() {
        yield return new WaitForSeconds( delay );
        manager.StartLoadingScreen();
    }
}
