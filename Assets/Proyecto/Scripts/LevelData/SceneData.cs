using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelManager/LevelData")]
public class SceneData : ScriptableObject {
    public LightmapData lightmapData { get { return new LightmapData { lightmapDir = dir, lightmapColor = color, shadowMask = shadowmask }; } }
    public Texture2D dir, color, shadowmask;
    [HideInInspector]public int sceneId;

}
