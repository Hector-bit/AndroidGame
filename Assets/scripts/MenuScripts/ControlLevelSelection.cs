using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlLevelSelection : Stats
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
    private void Start()
    {
        // Debug.Log("HELLO" + planetBadges);
        string[] tempPlanetBadges = planetBadges.ToArray();
        // foreach (string badge in tempPlanetBadges)
        // {
            foreach(string somethin in tempPlanetBadges){
                Debug.Log(somethin);
            }
            Debug.Log("hello from badges");
            if(planetBadges.Contains("moonBadge")){moonUnlocked = true; UpdateLevelImage(moonUnlocked, moonUnlockImage);}
            if(planetBadges.Contains("marsBadge")){marsUnlocked = true; UpdateLevelImage(marsUnlocked, marsUnlockImage);}
            if(planetBadges.Contains("planetOneBadge")){planetOneUnlocked = true; UpdateLevelImage(planetOneUnlocked, planetOneUnlockImage);}
        // }

        // UpdateLevelImage(moonUnlocked, moonUnlockImage);
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
