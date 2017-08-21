using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRPCImageSelector : MonoBehaviour {
    public Sprite spritePC, spriteVR, vrNoController;
	// Use this for initialization
	void Awake () {
        Sprite vr = OVRInput.IsControllerConnected(OVRInput.Controller.Remote) ? spriteVR : vrNoController;
        GetComponent<Image>().sprite =
#if UNITY_STANDALONE
            spritePC;
#elif UNITY_ANDROID
        vr;
#else
        spritePC;
#endif
    }

}
