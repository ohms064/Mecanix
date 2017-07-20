using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelManager/Objects/Create AudioDescriptor")]
public class AudioEvent : EventBehaviour {
    [SerializeField] AudioAsset inactive, active, onStart;
    AudioSource source;

    private void Start() {
        source = GetComponent<AudioSource>();
        source.clip = onStart.clip;
        source.loop = onStart.loop;
        source.Play();
    }

    public override void OnActivate(Descriptor desc) {
        if ( onStart.clip != null || inactive.clip != null) {
            source.Stop();
        }
        StartEvent();
    }
    public override void OnStart() {

    }

    public override void OnDeactivate(Descriptor desc) {
        if ( onStart.clip != null || active.clip != null ) {
            source.Stop();
        }
        EndEvent();
    }

    public override void StartEvent() {
        if ( active.clip != null ) {
            source.clip = active.clip;
            source.loop = active.loop;
            source.Play();
        }
    }

    public override void EndEvent() {
        if ( inactive.clip != null ) {
            source.clip = inactive.clip;
            source.loop = inactive.loop;
            source.Play();
        }
    }
}