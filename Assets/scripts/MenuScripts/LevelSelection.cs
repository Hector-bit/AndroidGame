using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This Script will be responsible for level selection and keeping track
// of which levels are unlocked

//Level1 = Mars
//Level2 = PlanetOne
//Level3 = Moon

public class LevelSelection : MonoBehaviour
{
    public void PressSelection(string levelName){
        SceneManager.LoadScene(levelName);
    }
}
