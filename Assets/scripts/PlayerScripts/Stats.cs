using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Level1 is the mars level
//Level2 is the planet1 llevel
//Level3 is the moon level
[System.Serializable]

//SUPER IMPORTANT
//Everything that needs to be saved will be in this script

public class Stats{
    public bool moonCompleted;
    public bool marsCompleted;
    public bool planetOneCompleted;

    // public bool moonUnlocked;
    // public bool marsUnlocked;
    // public bool planetOneUnlocked;

    public Stats (Victory victory){
        //this is a constructor used by SaveSystem to save the following
        moonCompleted = victory.moonCompleted;
        marsCompleted = victory.marsCompleted;
        planetOneCompleted = victory.planetOneCompleted;

        // moonUnlocked = victory.moonUnlocked;
        // marsUnlocked = victory.marsUnlocked;
        // planetOneUnlocked = victory.planetOneUnlocked;
    }

    // public Stats (ControlLevelSelection controlLevelSelection){
    //     moonUnlocked = victory.moonUnlocked;
    //     marsUnlocked = victory.marsUnlocked;
    //     planetOneUnlocked = victory.planetOneUnlocked;
    // }
}
