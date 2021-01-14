using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//Level1 is the mars level
//Level2 is the planet1 llevel
//Level3 is the moon level

public class Stats : MonoBehaviour
{
    public List<string> planetBadges = new List<string>();

    void Awake(){
        planetBadges.Add("moonBadge");
        Debug.Log("just added badge from stats script");
    }
}
