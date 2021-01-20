using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlLevelSelection : MonoBehaviour
{
    public bool moonUnlocked;
    public bool marsUnlocked;
    public bool planetOneUnlocked;

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
        LoadControlLevelSelection();
        if(moonCompleted == true){
            marsUnlocked = true;
        }
        if(marsCompleted == true){
            planetOneUnlocked = true;
        }

        if(marsUnlocked == true){UpdateLevelImage(marsUnlocked, marsUnlockImage);}
        if(planetOneUnlocked == true){UpdateLevelImage(planetOneUnlocked, planetOneUnlockImage);}
        SaveSystem.SaveControlLevelSelection(this);
    }

    public void LoadLevel(){
        Stats data = SaveSystem.LoadLevel();
        moonCompleted = data.moonCompleted;
        marsCompleted = data.marsCompleted;
        planetOneCompleted = data.planetOneCompleted;
    }

    public void LoadControlLevelSelection(){
        StatsLevel data = SaveSystem.LoadControlLevelSelection();
        moonUnlocked = data.moonUnlocked;
        marsUnlocked = data.marsUnlocked;
        planetOneUnlocked = data.planetOneUnlocked;
    }

    //This small bit of code makes the planet object appear
    private void UpdateLevelImage(bool moon, Image image)
    {
        if(moon == true){
            image.gameObject.SetActive(true);
        } else {
            image.gameObject.SetActive(false);
        }
    }
}
