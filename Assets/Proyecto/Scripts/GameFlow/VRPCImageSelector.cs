using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRPCImageSelector : MonoBehaviour {
    public Sprite spritePC, spriteVR;
	// Use this for initialization
	void Awake () {
        GetComponent<Image>().sprite =
#if UNITY_STANDALONE
            spritePC;
#elif UNITY_ANDROID
        spriteVR;
#else
        spritePC;
#endif
    }

}
