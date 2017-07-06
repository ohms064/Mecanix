using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelManager/Objects/Create AudioDescriptor")]
public class AudioDescriptor : EventDescriptor {
    public AudioSource inactive, onActive, onStart;


    public override void OnActivate(Descriptor desc) {
        if(onStart != null)
            onStart.Stop();
        if(onActive != null)
            onActive.Play();
    }
    public override void OnStart() {
        if(onStart != null)
            onStart.Play();
    }

    public override void StartEvent() {
        if (onActive != null)
            onActive.Play();
    }

    public override void OnDeactivate(Descriptor desc) {
        if(inactive != null) {
            inactive.Play();
        }
    }
}