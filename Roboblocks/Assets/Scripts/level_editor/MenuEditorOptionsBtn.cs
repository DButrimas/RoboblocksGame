using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuEditorOptionsBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject savePanel;


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
        savePanel = GameObject.Find("Canvas").transform.Find("Editor_menu_options").gameObject;

        if (savePanel.active == false)
        {
            savePanel.SetActive(true);
        }
        else
        {
            savePanel.SetActive(false);
        }


    }
}
