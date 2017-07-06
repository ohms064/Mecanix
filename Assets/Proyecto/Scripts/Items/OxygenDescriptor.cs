using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OxygenStatus {
    NORMAL, WARNING, DANGER, DEATH, START
}

[CreateAssetMenu( menuName = "LevelManager/Status/Create Oxygen Data" )]
public class OxygenDescriptor : Descriptor {
    public delegate void OxygenStatusChange();
    public event OxygenStatusChange OxygenWarning;
    public event OxygenStatusChange OxygenDanger;
    public event OxygenStatusChange OxygenOk;
    public event OxygenStatusChange OxygenDeath;
    public OxygenStatus status;
    public float nivelOxigeno;
    [TextArea(5,10)] public string deathMessage;
    
    [SerializeField] private float warningOxigeno, dangerOxigeno, maxOxigeno;

    public void Begin() {
        nivelOxigeno = maxOxigeno;
        status = OxygenStatus.START;
        IsActive = true;
    }

    public void Set( float delta ) {
        nivelOxigeno -= delta;

        if ( nivelOxigeno <= 0  ) {  
            if ( OxygenDeath != null && status != OxygenStatus.DEATH ) {
                status = OxygenStatus.DEATH;
                DebugUI.instance.Log( deathMessage );
                OxygenDeath();
            }
            return;
        }

        if ( nivelOxigeno <= dangerOxigeno ) {
            if ( OxygenDanger != null && status != OxygenStatus.DANGER ) {
                status = OxygenStatus.DANGER;
                OxygenDanger();
            }
            return;
        }

        if ( nivelOxigeno <= warningOxigeno ) {
            if ( OxygenWarning != null && status != OxygenStatus.WARNING ) {
                status = OxygenStatus.WARNING;
                OxygenWarning();
            }
            return;
        }
        else {
            if ( OxygenOk != null && status != OxygenStatus.NORMAL ) {
                status = OxygenStatus.NORMAL;
                OxygenOk();
            }
        }
        
    }
}
