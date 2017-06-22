using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "LevelManager/Create Item Receiver")]
public class ReceiverDescriptor : ScriptableObject {
    public Interaction[] itemInteractions;
    [TextArea( 5, 10 )]
    public string failedInteraction;
}
