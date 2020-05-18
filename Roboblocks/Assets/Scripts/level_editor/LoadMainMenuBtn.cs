using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoadMainMenuBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject savelevelpanel;
    public GameObject loadlevelpanel;

    public GameObject editorMenuOptionsPanel;
    public GameObject editorMenuButton;


    public GameObject confirmLoadMainMenuPanel;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = defaultColor;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = clickedColor;

        gameObject.GetComponent<Image>().color = defaultColor;

        confirmLoadMainMenuPanel.SetActive(true);

        if (savelevelpanel.active == true)
        {
            savelevelpanel.SetActive(false);
        }
        if (loadlevelpanel.active == true)
        {
            loadlevelpanel.SetActive(false);
        }
        editorMenuButton.SetActive(false);

        editorMenuOptionsPanel.SetActive(false);
    }
}