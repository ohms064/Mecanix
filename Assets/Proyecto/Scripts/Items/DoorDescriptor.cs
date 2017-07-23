using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "LevelManager/Objects/Create Door" )]
public class DoorDescriptor : Descriptor {
    public event SceneDelegate SceneLoadingFinish;
    public event SceneDelegate StartSceneLoading;
    public float doorDelay;
    public Descriptor[] required;

    public IEnumerator DoorDelay() {
        if ( StartSceneLoading != null ) {
            StartSceneLoading();
        }
        yield return new WaitForSeconds( doorDelay );
        if ( SceneLoadingFinish != null ) {
            SceneLoadingFinish();
        }
    }

    public bool CanActivate() {
        for ( int i = 0; i < required.Length; i++ ) {
            if ( !required[i].IsActive ) {
                return false;
            }
        }
        return true;
    }

   
}
