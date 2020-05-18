using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject panel;

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject MenuManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MenuManager.GetComponent<MainMenuManager>().selectedButton != gameObject.name)
        {
            gameObject.GetComponent<Image>().color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MenuManager.GetComponent<MainMenuManager>().selectedButton != gameObject.name)
        {
            gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = clickedColor;
        if (MenuManager.GetComponent<MainMenuManager>().selectedButton == "")
        {
            MenuManager.GetComponent<MainMenuManager>().selectedButton = gameObject.name;
        }
        else
        {
            MenuManager.GetComponent<MainMenuManager>().DisablePanel(MenuManager.GetComponent<MainMenuManager>().selectedButton, defaultColor);

            MenuManager.GetComponent<MainMenuManager>().selectedButton = gameObject.name;
        }
        panel.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
