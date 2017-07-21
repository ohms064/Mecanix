using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu( menuName = "ScriptableObjects/AudioMixerManager" )]
public class AudioMixerManager : ScriptableObject {
    [SerializeField] AudioMixer mixer;
    [SerializeField] float transitionTime = 0.01f;
    [SerializeField] AudioMixerSnapshot pauseSnaphot, unpauseSnapshot;
    [Range( -20.0f, 20.0f )] public float effects, music;

    public void SetMusicVolume(float value) {
        mixer.SetFloat( "MusicVolume", value );
        music = value;
    }

    public void SetEffectsVolume( float value ) {
        mixer.SetFloat( "EffectsVolume", value );
        effects = value;
    }

    public void SetEffectsVolume() {
        mixer.SetFloat( "EffectsVolume", effects );
    }

    public void SetMusicVolume() {
        mixer.SetFloat( "MusicVolume", music );
    }

    public void ChangeToPlay() {
        unpauseSnapshot.TransitionTo( transitionTime );
    }

    public void ChangeToPause() {
        pauseSnaphot.TransitionTo( transitionTime );
    }

    public float GetMusicVolume() {
        float value = 0.0f;
        if ( mixer.GetFloat( "MusicVolume", out value ) ) {
            return value;
        }
        return 0.0f;
    }

    public float GetEffectsVolume() {
        float value = 0.0f;
        if ( mixer.GetFloat( "EffectsVolume", out value ) ) {
            return value;
        }
        return 0.0f;
    }

    public float GetVolume(string group) {
        float value = 0.0f;
        if ( mixer.GetFloat( group, out value ) ) {
            return value;
        }
        return 0.0f;
    }

    public void Begin() {
        SetEffectsVolume();
        SetMusicVolume();
    }
}
