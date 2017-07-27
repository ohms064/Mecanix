using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoEnableEvent : MonoBehaviour {
    public VideoPlayer player;
    public bool enabledOnEnd;

    private void OnEnable() {
        player.loopPointReached += OnEnd;
    }
    private void OnDisable() {
        player.loopPointReached -= OnEnd;
    }

    public void OnEnd( VideoPlayer vi ) {
        gameObject.SetActive( enabledOnEnd );
    }
}
