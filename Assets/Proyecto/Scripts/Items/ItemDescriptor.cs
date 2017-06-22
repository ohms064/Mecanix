using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(menuName = "LevelManager/Create Item")]
public class ItemDescriptor : ScriptableObject {
    public int id;
    public string label;
    [TextArea(5, 10)]
    public string description;
}
