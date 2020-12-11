using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class singleLevel : MonoBehaviour
{
    public void BackButton(){
        SceneManager.LoadScene("Level1");
    }
}
