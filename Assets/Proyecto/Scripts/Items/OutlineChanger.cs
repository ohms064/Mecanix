using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineChanger : MonoBehaviour {
    public Material mat;
    public Color color1, color2;
    public float time = 5f;
    private float inverseTime;

    public void Start() {
        inverseTime = 1 / time;
        StartCoroutine( ColorChange( color1, color2));
    }

    IEnumerator ColorChange(Color begin, Color to) {
        float t = 0f;        
        Color color;
        while ( t < time ) {
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
            color = Color.Lerp( begin, to, t * inverseTime );
            mat.SetColor( "_OutlineColor", color );
        }
        StartCoroutine( ColorChange( to, begin) );
    }
}
