using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveBehaviour : MonoBehaviour {
    public abstract void Interact( PlayerInteractor interactor );
    public abstract void Interact( InteractiveBehaviour interactor );
}
