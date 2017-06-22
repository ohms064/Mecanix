using UnityEngine;

[System.Serializable]
public class Interaction {
    public ItemDescriptor item;
    [TextArea( 5, 10 )]
    public string correctText;
}

