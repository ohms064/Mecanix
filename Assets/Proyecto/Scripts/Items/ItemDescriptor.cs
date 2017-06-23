using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(menuName = "LevelManager/Objects/Create Item")]
public class ItemDescriptor : Descriptor {
    [TextArea(5, 10)]
    public string description;
}
