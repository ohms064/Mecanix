using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneLoad {
    MENU, GAME, WAIT, SELECTOR, NONE
}

public class SceneEvent : EventBehaviour {
    public SceneLoaderScriptable manager;
    public float delay;
    public SceneLoad onActivateScene, onStartEventScene;
    public override void EndEvent() {
        
    }

    public override void OnActivate( Descriptor desc ) {
        StartCoroutine( SelectScene(onActivateScene) );
    }

    public override void OnDeactivate( Descriptor desc ) {
        
    }

    public override void OnStart() {
        
    }

    public override void StartEvent() {
        StartCoroutine( SelectScene( onStartEventScene ) );
    }

    public IEnumerator SelectScene(SceneLoad sceneToLoad) {
        yield return new WaitForSeconds( delay );
        switch ( sceneToLoad ) {
            case SceneLoad.MENU:
                manager.StartMainMenu();
                break;
            case SceneLoad.GAME:
                StartCoroutine(manager.LoadAsync());
                break;
            case SceneLoad.WAIT:
                manager.StartLoadingScreen();
                break;
            case SceneLoad.SELECTOR:
                manager.StartSelectorScreen();
                break;
        }
    }
}
