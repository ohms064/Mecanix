using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="LevelManager/Anylitics")]
public class AnalyticsManager : ScriptableObject {
    public int successClicks, failedClicks;
    public float firstDoorTime, secondDoorTime, thirdDoorTime, totalTime;
    public DoorDescriptor firstDoor, secondDoor, thirdDoor;
    public float oxygenPuzzleTime;

    public string data {
        get {
            return string.Format( "Clicks:\nExitosos: {0} Fallidos: {1}\nTiempos:\n1ra Puerta: {2} 2da Puerta: {3},\n3ra Puerta {4}, total: {5},\nOxígeno: {6}", successClicks, failedClicks, firstDoorTime, secondDoorTime, thirdDoorTime, totalTime, oxygenPuzzleTime );
        }
    }

    public void AddDoor(DoorDescriptor des, float time) {
        if ( des == firstDoor ) {
            firstDoorTime = time;
            return;
        }
        if ( des == secondDoor ) {
            secondDoorTime = time;
            return;
        }
        if ( des == thirdDoor ) {
            thirdDoorTime = time;
        }
    }

}
