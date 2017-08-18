using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionItemData : ItemData {

    public override void Interact( PlayerInteractor interactor ) {
        if ( !data.IsActive ) {
            DebugUI.instance.Log( data.activeDescription );
            return;
        }
        base.Interact( interactor );
    }
}
