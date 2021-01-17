﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlLevelSelection : MonoBehaviour
{
    public bool moonUnlocked = true;
    public bool marsUnlocked = false;
    public bool planetOneUnlocked = false;

    public bool moonCompleted;
    public bool marsCompleted;
    public bool planetOneCompleted;

    public Image moonUnlockImage; 
    public Image marsUnlockImage;
    public Image planetOneUnlockImage;
    //find a way to use a dimmed version of the planet instead of an image
    // public GameObject[] stars;
    // public string[] planetsUnlocked = new string[] {"moonBadge", "marsBadge"};
    // void Awake(){
    //     if(moonCompleted == true){
    //         marsUnlocked = true;
    //     }
    //     if(marsCompleted == true){
    //         planetOneUnlocked = true;
    //     }
    // }

    private void Awake()
    {
        LoadLevel();
        if(moonCompleted == true){
            marsUnlocked = true;
        }
        if(marsCompleted == true){
            planetOneUnlocked = true;
        }
        // Debug.Log("HELLO" + planetBadges);
        // string[] tempPlanetBadges = planetBadges.ToArray();
        // foreach (string badge in tempPlanetBadges)
        // {
            // foreach(string somethin in tempPlanetBadges){
            //     Debug.Log(somethin);
            // }
            // Debug.Log("hello from badges");
            // if(moonCompleted == true){moonUnlocked = true; UpdateLevelImage(moonUnlocked, moonUnlockImage);}
        if(marsUnlocked == true){UpdateLevelImage(marsUnlocked, marsUnlockImage);}
        if(planetOneUnlocked == true){UpdateLevelImage(planetOneUnlocked, planetOneUnlockImage);}

            // for(int i = 0; i <= tempPlanetBadges.Length; i++;){
            //     if()
            // }
        // }

        // UpdateLevelImage(moonUnlocked, moonUnlockImage);
    }

    public void LoadLevel(){
        Stats data = SaveSystem.LoadLevel();
        moonCompleted = data.moonCompleted;
        marsCompleted = data.marsCompleted;
        planetOneCompleted = data.planetOneCompleted;
        Debug.Log(data.moonCompleted + "from loadlevel");
        Debug.Log(data.marsCompleted + "from loadlevel");
        Debug.Log(data.planetOneCompleted + "from loadlevel");
    }

    //don't mind the variable names for updatelevelimage, its all handled in the void start() function
    private void UpdateLevelImage(bool moon, Image image)
    {
        if(moon == true){
            image.gameObject.SetActive(true);
        } else {
            image.gameObject.SetActive(false);
        }
        // if(mars == true){
        //     unlockImage.gameObject.SetActive(true);
        // } else {
        //     unlockImage.gameObject.SetActive(false);
        // }
    }
}
