using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public OVRCameraRig mainCameraRig;
    public GameObject player;
    
    
    public ElectricityDescriptor electricity;
    public GravityDescriptor gravity;
    public OxygenDescriptor oxygen;

    [SerializeField] Descriptor[] reset;

    public static GameManager instance;


    protected virtual void Awake() {
        instance = this;
        for ( int i = 0; i < reset.Length; i++ ) {
            reset[i].Reset();
        }
    }

    private void OnEnable() {
        oxygen.OxygenDeath += RestartScene;
    }

    private void OnDisable() {
        oxygen.OxygenDeath -= RestartScene;
    }

    private void OnDestroy() {
        instance = null;
    }

    public virtual void RestartScene() {        
        SceneManager.LoadScene( 0 );
    }
}
