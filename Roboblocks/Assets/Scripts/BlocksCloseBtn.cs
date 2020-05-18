using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlocksCloseBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public List<GameObject> closeThis;
    public GameObject edit_btn;
    public GameObject run_btn;
    public GameObject StopBtn;
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


        foreach (GameObject item in closeThis)
        {
            item.SetActive(false);
        }


        gameObject.GetComponent<Image>().color = defaultColor;
        edit_btn.SetActive(true);
        run_btn.SetActive(true);
        StopBtn.SetActive(false);
        if (quit_btn != null)
        {
            quit_btn.SetActive(true);
        }
        if (restart_btn != null)
        {
            restart_btn.SetActive(true);
        }

    }
}
