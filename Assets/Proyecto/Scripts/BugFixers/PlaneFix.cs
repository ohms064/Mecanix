using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaneFix : MonoBehaviour {

    public enum Axis {
        X, Y, Z
    }
    public Axis axis;
    public float val, respawnAxis, refreshTime;
    public bool below = true;
    public int maxTries;
    private int tries = 0;
    private Vector3 origin;
    // Update is called once per frame

    private void Start() {
        origin = transform.position;
    }

    IEnumerator Refresh() {
        while ( Application.isPlaying ) {
            yield return new WaitForSecondsRealtime( refreshTime );
            tries = 0;
        }
    }

    void FixedUpdate() {
        float axisVal;
        switch ( axis ) {
            case Axis.X:
                axisVal = transform.position.x;
                if ( Check( axisVal ) ) {
                    Vector3 pos = transform.position;
                    pos.x = respawnAxis;
                    transform.position = pos;
                    tries++;
                }
                break;
            case Axis.Y:
                axisVal = transform.position.y;
                if ( Check( axisVal ) ) {
                    Vector3 pos = transform.position;
                    pos.y = respawnAxis;
                    transform.position = pos;
                    tries++;
                }
                break;
            case Axis.Z:
                axisVal = transform.position.z;
                if ( Check( axisVal ) ) {
                    Vector3 pos = transform.position;
                    pos.z = respawnAxis;
                    transform.position = pos;
                    tries++;
                }
                break;
        }
    }
    private void LateUpdate() {
        if ( tries > maxTries ) {
            transform.position = origin;
            tries = 0;
        }
    }

    private bool Check( float axisVal ) {
        return below ? axisVal < val : axisVal > val;
    }
}
