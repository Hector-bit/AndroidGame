using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//rewrite this code using the word pause somewhere
//chances are your confused because I am too and I just wrote this

public class GameMenu : MonoBehaviour
{
    [SerializeField] private bool inGameMenu = false;
    public GameObject In_Game_Menu;

    // private void start(){
    //     inGameMenu = false;
    // }


    //This function will be added to a button that will open and close the menu
    public void menuSelection(){
        if(inGameMenu == false){
            inGameMenu = true;
        } else {
            inGameMenu = false;
        }
        inGameMenuCheck();
    }

    private void inGameMenuCheck(){
        if(inGameMenu == true){
            // In_Game_Menu.GetComponent<Canvas>().enabled = true;
            In_Game_Menu.gameObject.SetActive(true);
        } else {
            // In_Game_Menu.GetComponent<Canvas>().enabled = false;
            In_Game_Menu.gameObject.SetActive(false);
        }
    }
}
