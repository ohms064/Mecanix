using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruccionesInicio : MonoBehaviour {
    [TextArea(1, 2)]
    public string vr, pc, vrNoController;
	// Use this for initialization
	void Start () {
        string v = OVRInput.IsControllerConnected( OVRInput.Controller.Remote ) ? vr : vrNoController;
        DebugUI.instance.Log(
#if UNITY_STANDALONE
            pc
#elif UNITY_ANDROID
        v
#else
        pc
#endif
        , 10f);
    }

}
