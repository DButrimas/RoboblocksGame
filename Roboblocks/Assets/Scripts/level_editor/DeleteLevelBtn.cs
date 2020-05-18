using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeleteLevelBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public GameObject LoadLevelPanel;
    public GameObject ConfirmLevelDeletePanel;


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

        if (SelectedStatic.selected_lvl != null)
        {
            LoadLevelPanel.SetActive(false);
            ConfirmLevelDeletePanel.SetActive(true);
        }


        gameObject.GetComponent<Image>().color = defaultColor;
    }
}