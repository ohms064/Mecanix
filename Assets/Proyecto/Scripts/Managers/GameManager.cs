using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour {

    public OVRCameraRig mainCameraRig;
    public GameObject player;
    
    
    public ElectricityDescriptor electricity;
    public GravityDescriptor gravity;
    public OxygenDescriptor oxygen;

    [SerializeField] Descriptor[] reset;
    [SerializeField] GameObject[] dontDestroy;
    
    public static GameManager instance;


    private void Awake() {
        instance = this;
        for ( int i = 0; i < reset.Length; i++ ) {
            reset[i].Reset();
        }

        for ( int i = 0; i < dontDestroy.Length; i++ ) {
            DontDestroyOnLoad( dontDestroy[i] );
        }
    }
}
