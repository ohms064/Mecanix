using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsEvent : EventBehaviour {
    LightmapData[] data;

    public override void EndEvent() {
    }

    public override void OnActivate( Descriptor desc ) {
        EnableLightmaps();
    }

    public override void OnDeactivate( Descriptor desc ) {
        DisableLightmaps();
    }

    public override void OnStart() {
    }

    public override void StartEvent() {
    }

    // Use this for initialization
    void Start () {
        data = LightmapSettings.lightmaps;
        DisableLightmaps();
	}

    public void DisableLightmaps() {
        // Disable lightmaps in scene by removing the lightmap data references
        LightmapSettings.lightmaps = new LightmapData[] { };
    }

    public void EnableLightmaps() {
        // Reenable lightmap data in scene.
        LightmapSettings.lightmaps = data;
    }
}

