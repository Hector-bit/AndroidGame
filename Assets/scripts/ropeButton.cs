using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ropeButton : MonoBehaviour
{
    public ropeSystem rope;
    public Button grappleButton;

    private RectTransform baseRect = null;

    private Canvas canvas;
    private Camera cam;


    void Start()
    {
        grappleButton.onClick.AddListener(GrappleClicked);
        baseRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            Debug.LogError("The button is not within the rectangle");
    }
    // Update is called once per frame
    void GrappleClicked()
    {
        if(rope.ropeRenderer.enabled == false)
        {
            // rope.ropeRenderer.enabled == true;
            Debug.Log("Rope swing 'activated'");
        } else 
        {
            rope.ResetRope();
        }
    }
}
