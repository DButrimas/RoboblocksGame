using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color obj_col;
    public Color temp;


    float tmp_a;
    public void OnPointerEnter(PointerEventData eventData)
    {
        temp = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = Color.black;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = temp;
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (SelectedStatic.selected.gameObject.name.Contains("ramp"))
        {


            tmp_a = SelectedStatic.selected.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color.a;
            temp = new Color(temp.r, temp.g, temp.b, tmp_a);


            SelectedStatic.selected.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = temp;
        }
        else
        {
            tmp_a = SelectedStatic.selected.gameObject.GetComponent<Renderer>().material.color.a;
            temp = new Color(temp.r, temp.g, temp.b, tmp_a);

            SelectedStatic.selected.gameObject.GetComponent<Renderer>().material.color = temp;
        }

    }
}

