using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameEvent : EventBehaviour {
    [SerializeField] SceneLoaderScriptable manager;
    public float delay;
    public override void EndEvent() {

    }

    public override void OnActivate( Descriptor desc ) {
    }

    public override void OnDeactivate( Descriptor desc ) {

    }

    public override void OnStart() {

    }

    public override void StartEvent() {
        StartCoroutine( LoadMenu() );
    }


    IEnumerator LoadMenu() {
        yield return new WaitForSeconds( delay );
        manager.StartMainMenu();
    }
}
