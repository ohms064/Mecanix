using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Descriptor : ScriptableObject {
    public delegate void ObjectActivate( Descriptor descriptor );
    public delegate void ObjectDeactivate( Descriptor descriptor );
    public string label;
    public bool isActive = false;
    [SerializeField] private bool initialActive = false;

    public virtual void Reset() {
        isActive = initialActive;
    }
}
