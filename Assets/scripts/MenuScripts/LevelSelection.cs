using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This Script will be responsible for level selection and keeping track
// of which levels are unlocked

public class LevelSelection : stats
{
    [SerializeField] private bool moonUnlocked = false;
    [SerializeField] private bool marsUnlocked = false; 
    public Image moonUnlockImage; //find a way to use a dimmed version of the planet instead of an image
    // public GameObject[] stars;
    // public string[] planetsUnlocked = new string[] {"moonBadge", "marsBadge"};

    private void Start(){
        // Debug.Log("HELLO" + planetBadges);
        foreach (string badge in planetBadges)
        {
            Debug.Log(badge);
            if(badge == "moonBadge"){moonUnlocked = true;}
            if(badge == "marsBadge"){marsUnlocked = true;}
        }

        UpdateLevelImage(moonUnlocked);
    }
    
    private void UpdateLevelImage(bool moon)
    {
        if(moon == true){
            moonUnlockImage.gameObject.SetActive(false);
        } else {
            moonUnlockImage.gameObject.SetActive(false);
        }
        
        // if(mars == true){
        //     unlockImage.gameObject.SetActive(true);
        // } else {
        //     unlockImage.gameObject.SetActive(false);
        // }
    }

    public void PressSelection(string levelName){
        SceneManager.LoadScene(levelName);
    }
}
