using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This Script will be responsible for level selection and keeping track
// of which levels are unlocked

public class LevelSelection : MonoBehaviour
{
    public void PressSelection(string levelName){
        SceneManager.LoadScene(levelName);
    }
}
