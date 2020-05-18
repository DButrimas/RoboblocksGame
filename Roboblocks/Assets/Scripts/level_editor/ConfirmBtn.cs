using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConfirmBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

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
        if (gameObject.name == "delete") {
            SelectedStatic.selected.GetComponent<SelectedObj>().delete();
        }
        else
        {
            SelectedStatic.selected.GetComponent<SelectedObj>().cancel();
        }
        gameObject.GetComponent<Image>().color = defaultColor;

    }
}
