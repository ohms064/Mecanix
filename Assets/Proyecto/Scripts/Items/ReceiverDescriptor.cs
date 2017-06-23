using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "LevelManager/Objects/Create Item Receiver")]
public class ReceiverDescriptor : Descriptor {
    public Interaction itemInteractions;
    [TextArea( 5, 10 )]
    public string failedInteraction;
}
