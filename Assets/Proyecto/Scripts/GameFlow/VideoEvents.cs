using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoEvents : MonoBehaviour {
    public VideoPlayer player;
    public SceneEvent ev;

    private void OnEnable() {
        player.loopPointReached += OnEnd;
    }
    private void OnDisable() {
        player.loopPointReached -= OnEnd;
    }

    public void OnEnd( VideoPlayer vi ) {
        //ev.ChangeScene(ev.scene2LoadOnStartEvent);
    }

}
