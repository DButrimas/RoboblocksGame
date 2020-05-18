using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseMenuPanelButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public Color defaultMenuButtonColor;

    public GameObject MenuManager;

    public GameObject signUpManager;

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

        MenuManager.GetComponent<MainMenuManager>().DisablePanel(MenuManager.GetComponent<MainMenuManager>().selectedButton, defaultMenuButtonColor);

        MenuManager.GetComponent<MainMenuManager>().selectedButton = "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
