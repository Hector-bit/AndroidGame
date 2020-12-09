using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelIcon;
    public GameObject thisCanvas;
    //remember to change number of levels as you create levels
    public int numberOfLevels = 3;

    // Start is called before the first frame update
    void Start()
    {
        Rect panelDimensions = levelHolder.GetComponent<RectTransform().rect;
        Rect iconDimensions = levelIcon.GetComponent<RectTransform().rect;
        int maxInARow = Mathf.FloorToInt(panelDimensions.width / iconDimensions.width);
        int maxInACol = Mathf.FloorToInt(panelDimensions.height / iconDimensions.height);
        int amountPerPage = maxInARow * maxInACol;
        int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        LoadPanels(totalPages);
    }

    void LoadPanels(int numberOfPanels){
        Debug.Log(numberOfPanels);
        GameObject panelClone = Instantiate)levelHolder) as GameObject;
        for(int i = ; i <= numberOfPanels; i++){
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Page-" + i;
            panel.GetComponent<RectTransform>().localPosition = new vector2(panelDimensions.width * (i-1), 0);
            LoadIcons(25, panel);
        }
    }

    void LoadIcons(int numberOfIcons, GameObject parentObject){
        for(int i = 1; i <= numberOfIcons; i++){
            GameObject icon = Instant(levelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.name = "Level " + i;
        }
    }
}
