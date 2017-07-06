using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveBehaviour : MonoBehaviour {
    public abstract void Interact( PlayerInteractor interactor );
    public abstract void Interact( InteractiveBehaviour interactor );
    public abstract void Restart();
    public bool message;
    public EventDescriptor[] events;

    public virtual void Start() {
        for(int i = 0; i < events.Length; i++) {
            events[i].OnStart();
        }
    }
}
