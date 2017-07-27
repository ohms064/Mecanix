using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void SceneDelegate();
public delegate void SceneSetter();

[CreateAssetMenu(menuName = "ScriptableObjects/SceneManager" )]
public class SceneLoaderScriptable : ScriptableObject {
    public int sceneId, sceneLoader, sceneSelector, sceneMenu;
    public LoadSceneMode loadingMode = LoadSceneMode.Single;
    AsyncOperation loader;
    public static event SceneDelegate SceneLoadingFinish;
    public static event SceneDelegate StartSceneLoading;

    public IEnumerator LoadAsync() {
 
        loader = SceneManager.LoadSceneAsync( sceneId, loadingMode );
        loader.allowSceneActivation = false;
        while ( !loader.isDone ) {
            yield return new WaitForFixedUpdate();
            if ( loader.progress >= 0.9f ) {
                loader.allowSceneActivation = true;
            }
        }
        if ( SceneLoadingFinish != null ) {
            SceneLoadingFinish();
        }
    }

    public IEnumerator LoadAsync(float delay) {
        float time = 0f;
        loader = SceneManager.LoadSceneAsync( sceneId, loadingMode );
        loader.allowSceneActivation = false;
        while ( !loader.isDone ) {
            yield return new WaitForFixedUpdate();
            if ( loader.progress >= 0.9f ) {
                while ( time < delay ) {
                    time += Time.fixedDeltaTime;
                    yield return new WaitForFixedUpdate();
                }
                loader.allowSceneActivation = true;
            }
        }
        if ( SceneLoadingFinish != null ) {
            SceneLoadingFinish();
        }
    }

    public void StartLoading() {
        if ( StartSceneLoading != null ) {
            StartSceneLoading();
        }
    }

    public void StartLoadingScreen() {
        SceneManager.LoadScene( sceneLoader );
    }

    public void StartSelectorScreen() {
        SceneManager.LoadScene( sceneSelector );
    }

    public void StartMainMenu() {
        SceneManager.LoadScene( sceneMenu );
    }

    public void QuitApplication() {
        Application.Quit();
    }

    public void SelectScene( SceneLoad sceneToLoad ) {        
        switch ( sceneToLoad ) {
            case SceneLoad.MENU:
                StartMainMenu();
                break;
            case SceneLoad.WAIT:
                StartLoadingScreen();
                break;
            case SceneLoad.SELECTOR:
                StartSelectorScreen();
                break;
        }
    }
}
