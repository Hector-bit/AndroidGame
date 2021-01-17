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

    public Stats (Victory victory){
        moonCompleted = victory.moonCompleted;
        marsCompleted = victory.marsCompleted;
        planetOneCompleted = victory.planetOneCompleted;
    }
}
