using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour {
    public GameObject rot;
    float offset;
#if UNITY_ANDROID && !UNITY_STANDALONE
    // Update is called once per frame
    private void Start() {
        offset = transform.localEulerAngles.y;
    }

    void FixedUpdate () {
        Vector3 r = transform.localEulerAngles;
        transform.localEulerAngles =  new Vector3(r.x, rot.transform.localEulerAngles.y + offset, r.x);
	}
#endif
}
