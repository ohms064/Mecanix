using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour {
    public static OxygenManager instance;
    public OxygenDescriptor descriptor;
    private bool isActive = false;
    public DoorDescriptor doorTrigger;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        doorTrigger.SceneLoadingFinish += OnSceneStart;
    }

    private void Update() {
        if(isActive)
            descriptor.Set( Time.deltaTime );
    }

    private void OnSceneStart() {
        isActive = true;
        descriptor.Begin();
        doorTrigger.SceneLoadingFinish -= OnSceneStart;
        Debug.Log( "El oxígeno empezó a drenarse!" );
    }

}
