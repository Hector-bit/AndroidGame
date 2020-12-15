using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked; 
    public Image unlockImage; //find a way to use a dimmed version of the planet instead of an image
    // public GameObject[] stars;

    private void Start(){
        UpdateLevelImage();
    }
    
    private void UpdateLevelImage()
    {
        if(!unlocked){
            unlockImage.gameObject.SetActive(true);
        } else {
            unlockImage.gameObject.SetActive(false);
        }
    }

    public void PressSelection(string levelName){
        if(unlocked){
            SceneManager.LoadScene(levelName);
        }
    }
}
