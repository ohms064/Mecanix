using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "LevelManager/Objects/Create Door" )]
public class DoorDescriptor : Descriptor {
    [HideInInspector]public int leftScene, rightScene;
    public event SceneDelegate SceneLoadingFinish;
    public event SceneDelegate StartSceneLoading;

    public IEnumerator LoadSceneLeftAsync() {
        if ( StartSceneLoading != null ) {
            StartSceneLoading();
        }

        AsyncOperation loader = SceneManager.LoadSceneAsync( leftScene, LoadSceneMode.Additive );
        loader.allowSceneActivation = false;
        while ( !loader.isDone ) {
            yield return new WaitForEndOfFrame();
            if ( loader.progress >= 0.9f ) {
                loader.allowSceneActivation = true;
            }
        }
        if ( SceneLoadingFinish != null ) {
            SceneLoadingFinish();
        }
    }

    public IEnumerator LoadSceneRightAsync() {
        if ( StartSceneLoading != null ) {
            StartSceneLoading();
        }

        AsyncOperation loader = SceneManager.LoadSceneAsync( rightScene, LoadSceneMode.Additive );
        loader.allowSceneActivation = false;
        while ( !loader.isDone ) {
            yield return new WaitForEndOfFrame();
            if ( loader.progress >= 0.9f ) {
                loader.allowSceneActivation = true;
            }
        }
        if ( SceneLoadingFinish != null ) {
            SceneLoadingFinish();
        }
    }

    public IEnumerator UnLoadSceneLeft() {
        AsyncOperation loader = SceneManager.UnloadSceneAsync( leftScene);
        loader.allowSceneActivation = false;
        while ( !loader.isDone ) {
            yield return new WaitForEndOfFrame();
            if ( loader.progress >= 0.9f ) {
                loader.allowSceneActivation = true;
            }
        }
    }

    public IEnumerator UnLoadSceneRight() {
        AsyncOperation loader = SceneManager.UnloadSceneAsync( rightScene );
        loader.allowSceneActivation = false;
        while ( !loader.isDone ) {
            yield return new WaitForEndOfFrame();
            if ( loader.progress >= 0.9f ) {
                loader.allowSceneActivation = true;
            }
        }
    }
}
