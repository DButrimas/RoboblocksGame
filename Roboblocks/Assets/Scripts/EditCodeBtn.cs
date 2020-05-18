using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditCodeBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

     public List<GameObject> openThis;
    public GameObject stop_btn;
    public GameObject run_btn;
    public GameObject quit_btn;
    public GameObject restart_btn;


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


        foreach (GameObject item in openThis)
        {
            item.SetActive(true);
        }


        gameObject.GetComponent<Image>().color = defaultColor;


        gameObject.SetActive(false);
        stop_btn.SetActive(false);
        run_btn.SetActive(false);
        if (quit_btn != null)
        {
            quit_btn.SetActive(false);
        }
        if (restart_btn != null)
        {
            restart_btn.SetActive(false);
        }

    }
}
