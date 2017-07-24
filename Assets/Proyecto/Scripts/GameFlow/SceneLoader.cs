using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    [SerializeField] SceneLoaderScriptable sceneManager;
    public float delay;

	// Use this for initialization
	void Start () {
        StartCoroutine( sceneManager.LoadAsync(delay) );
	}
}
