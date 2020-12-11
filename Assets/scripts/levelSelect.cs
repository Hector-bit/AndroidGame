using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour
{
    [SerializedField] private bool unlocked; 
    public Image unlockImage; //find a way to use a dimmed version of the planet instead of an image
    // public GameObject[] stars;
    
    private void UpdateLevelImage()
    {
        if(!unlocked){
            unlockImage.gameObject.SetActive(true);
        } else {
            unlockImage.gameObject.SetActive(false);
        }
    }
}
