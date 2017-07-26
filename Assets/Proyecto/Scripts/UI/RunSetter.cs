using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunSetter : MonoBehaviour {

    public AnalyticsManager manager;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = manager.data;	
	}

}
