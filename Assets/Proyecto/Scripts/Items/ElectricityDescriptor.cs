using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "LevelManager/Status/Create Electricity Data" )]
public class ElectricityDescriptor : Descriptor {
    public LightmapData lightsOff;
    public LightmapData lightOn;
    public bool electricityOn;
    public event ObjectActivate ActivateElectricity;
    public event ObjectActivate DeactivateElectricity;

    public void Set( bool on ) {
        electricityOn = on;
        if ( on ) {
            if ( ActivateElectricity != null )
                ActivateElectricity( this );
        }
        else {
            if ( DeactivateElectricity != null )
                DeactivateElectricity( this );
        }
    }
}
