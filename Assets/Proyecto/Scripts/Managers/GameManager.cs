﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public OVRCameraRig mainCameraRig;
    public GameObject player;
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

}
