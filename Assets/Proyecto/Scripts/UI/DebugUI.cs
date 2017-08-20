using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DebugUI : MonoBehaviour {
    private Text debug;
    public static DebugUI instance;
    private int lines = 0;
    public int maxLines = 5;
    public float waitTime;
    private bool waitingToHide = false;

	// Use this for initialization
	void Start () {
        debug = GetComponent<Text>();
	    instance = this;
	}

    public void Log( string text ) {
        /*
        debug.text += string.Format("{0}\n",text);
        lines++;
        if ( lines > maxLines ) {
            string debugText = debug.text;
            int find = debugText.IndexOf( "\n", 1, StringComparison.Ordinal );
            debugText = debugText.Remove( 0, find);
            debug.text = debugText;
        }
        Debug.Log( text );
        */
        if ( waitingToHide ) {
            StopAllCoroutines();
            waitingToHide = false;
        }

        debug.text = string.Format("{0}\n", text);
        Debug.Log(text);

        StartCoroutine( Hide() );
    }

    IEnumerator Hide() {
        waitingToHide = true;
        yield return new WaitForSeconds( waitTime );
        debug.text = "";
    }
}
