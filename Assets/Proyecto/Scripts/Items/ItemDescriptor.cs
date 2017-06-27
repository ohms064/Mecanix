using UnityEngine;


[CreateAssetMenu(menuName = "LevelManager/Objects/Create Item")]
public class ItemDescriptor : Descriptor {
    public Vector3 position = Vector3.zero;

    public override void Reset() {
        base.Reset();
        position = Vector3.zero;
    }
}
