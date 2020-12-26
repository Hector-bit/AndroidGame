using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlLevelSelection : stats
{
    [SerializeField] private bool moonUnlocked = false;
    [SerializeField] private bool marsUnlocked = false; 
    [SerializeField] private bool planetOneUnlocked = false;

    public Image moonUnlockImage; 
    public Image marsUnlockImage;
    public Image planetOneUnlockImage;
    //find a way to use a dimmed version of the planet instead of an image
    // public GameObject[] stars;
    // public string[] planetsUnlocked = new string[] {"moonBadge", "marsBadge"};

    private void Start(){
        // Debug.Log("HELLO" + planetBadges);
        foreach (string badge in planetBadges)
        {
            Debug.Log(badge);
            if(badge == "moonBadge"){moonUnlocked = true; UpdateLevelImage(moonUnlocked, moonUnlockImage);}
            if(badge == "marsBadge"){marsUnlocked = true; UpdateLevelImage(marsUnlocked, marsUnlockImage);}
            if(badge == "planetOneBadge"){planetOneUnlocked = true; UpdateLevelImage(planetOneUnlocked, planetOneUnlockImage);}
        }

        // UpdateLevelImage(moonUnlocked, moonUnlockImage);
    }
    
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
