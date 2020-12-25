using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private bool Gamemenu;

    private void start(){
        GameMenu = false;
    }


    //This function will be added to a button that will open and close the menu
    private void menuSelection(){
        if(GameMenu == false){
            GameMenu = true;
        } else {
            GameMenu = false;
        }
    }
}
