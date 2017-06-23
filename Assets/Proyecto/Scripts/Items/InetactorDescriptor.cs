using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "LevelManager/Objects/Create Interactor" )]
public class InetactorDescriptor : Descriptor {
    public Descriptor[] requiredObjects;
    [TextArea( 5, 10 )]
    public string successText, failedText;
}
