﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "LevelManager/Objects/Create Interactor" )]
public class InteractorDescriptor : Descriptor {
    public Descriptor[] requiredObjects;
    [TextArea( 5, 10 )]
    public string successText, failedText;

    public bool canActivate() {
        for ( int i = 0; i < requiredObjects.Length; i++ ) {
            if ( !requiredObjects[i].isActive ) {
                Debug.Log( failedText );
                return false;
            }
        }
        Debug.Log( successText );
        return true;
    }
}
