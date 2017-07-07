using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Descriptor : ScriptableObject {
    public delegate void ObjectActivate( Descriptor descriptor );
    public event ObjectActivate Activate, Deactivate;
    public EventBehaviour[] events;

    public string label;
    public bool IsActive {
        get {
            return _isActive;
        }
        set {
            if ( value == _isActive ) {
                return;
            }
            _isActive = value;
            if ( _isActive ) {
                if ( Activate != null ) {
                    Activate( this );
                }
                else if(Deactivate != null) {
                    Deactivate( this );
                }
            }
        }
    }
    [SerializeField] protected bool _isActive = false;
    [SerializeField] protected bool initialActive = false;
    [TextArea( 5, 10 )]
    public string description, activeDescription;

    public virtual void Reset() {
        IsActive = initialActive;
    }  
    
    public void SubscribeToEvents() {
        for(int i = 0; i < events.Length; i++) {
            Activate += events[i].OnActivate;
            Deactivate += events[i].OnDeactivate;
        }
    }  
}
