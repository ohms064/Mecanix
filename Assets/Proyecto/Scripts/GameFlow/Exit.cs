using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
    private float time;
    public float pressedTime = 3f;
    public SceneLoad sceneToLoad;
    public SceneLoaderScriptable manager;
	
	// Update is called once per frame
	void FixedUpdate () {
        if ( Input.GetMouseButton( 1 )
#if UNITY_ANDROID
            || Input.GetMouseButton(0)
#endif
            ) {
            time += Time.fixedDeltaTime;
            if ( time > pressedTime ) {
                manager.SelectScene( sceneToLoad );
            }
        }
        else {
            time = 0f;
        }
	}
}
