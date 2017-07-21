using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    public Canvas menuPause;
    public AudioMixerManager audioMixerManager;

    void Start() {
        menuPause.enabled = false;
        AudioListener.pause = false;
    }

    public void Pause() {
        menuPause.enabled = true;
        Time.timeScale = 0;
        if ( audioMixerManager != null )
            audioMixerManager.ChangeToPause();
    }

    public void Resume() {
        menuPause.enabled = false;
        if(audioMixerManager != null)
            audioMixerManager.ChangeToPlay();
        Time.timeScale = 1;
    }

    public void Toggle() {
        menuPause.enabled = !menuPause.enabled;
        if ( menuPause.enabled ) {
            Time.timeScale = 0;
            if ( audioMixerManager != null )
                audioMixerManager.ChangeToPause();
        }
        else {
            if ( audioMixerManager != null )
                audioMixerManager.ChangeToPlay();
            Time.timeScale = 1;
        }
    }

    void OnDestroy() {
        Resume();
    }


}
