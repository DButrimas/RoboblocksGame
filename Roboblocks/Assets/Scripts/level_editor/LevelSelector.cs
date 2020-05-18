using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color hover;
    public Color selected;
    public Color defaultColor;

    public bool hovering;
    public Level lvl;

    bool isSelected = false;

    float tmp_a;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SelectedStatic.selected_lvl != null)
        {
            if (SelectedStatic.selected_lvl.name != lvl.name)
            {
                gameObject.GetComponent<Image>().color = hover;

            }
        }
        else
        {
            gameObject.GetComponent<Image>().color = hover;

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (SelectedStatic.selected_lvl != null)
        {
            if (SelectedStatic.selected_lvl.name != lvl.name)
            {
                gameObject.GetComponent<Image>().color = defaultColor;

            }
        }
        else
        {
            gameObject.GetComponent<Image>().color = defaultColor;
  
        }

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (SelectedStatic.selected_lvl == null)
        {
            SelectedStatic.selected_lvl = lvl;
            SelectedStatic.selected_lvl_parent_item = gameObject;
            gameObject.GetComponent<Image>().color = selected;

        }
        else
        {
            SelectedStatic.selected_lvl_parent_item.GetComponent<Image>().color = defaultColor;
            SelectedStatic.selected_lvl = lvl;
            SelectedStatic.selected_lvl_parent_item = gameObject;
            gameObject.GetComponent<Image>().color = selected;
        }

    }

    public void Update()
    {


    }
}
