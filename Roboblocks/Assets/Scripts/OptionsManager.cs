using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class OptionsManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public Toggle windowed;
    public TMP_Dropdown resolutionDD;


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

        string []resolutions = resolutionDD.options[resolutionDD.value].text.Split('x');



         Screen.SetResolution(int.Parse(resolutions[0]), int.Parse(resolutions[1]), !windowed.isOn);

        gameObject.GetComponent<Image>().color = defaultColor;

    }
}