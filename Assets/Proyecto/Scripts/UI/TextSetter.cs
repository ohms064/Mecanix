using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour {
    public Descriptor descriptor;

    private void Awake() {
        GetComponent<Text>().text = descriptor.label;
    }

    private void OnEnable() {
        GetComponent<Text>().text = descriptor.label;
    }
}
