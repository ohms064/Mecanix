using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/Input")]
public class InputReceiver : ScriptableObject {
    public bool click;
    float t;
    public const float waitTime = 0.3f;
    public bool grabInteraction = false, moveInteraction = false, movePressed = false;

    private bool Until() {
        return click || Time.timeSinceLevelLoad - t > waitTime;
    }

    public IEnumerator CheckDoubleClick() {
        while ( Application.isPlaying ) {
            if ( click ) {
                click = false;
                yield return new WaitForEndOfFrame();
                t = Time.timeSinceLevelLoad;
                yield return new WaitUntil( Until );
                click = false;
                grabInteraction = Time.timeSinceLevelLoad - t <= waitTime;
                moveInteraction = !grabInteraction && movePressed;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void StartChecking( MonoBehaviour monobehaviour ) {

        monobehaviour.StartCoroutine( CheckDoubleClick() );
    }

    public void Reset() {
        moveInteraction = grabInteraction = false;
    }
}
