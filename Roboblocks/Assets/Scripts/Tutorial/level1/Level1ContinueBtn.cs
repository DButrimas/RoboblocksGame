using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Level1ContinueBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;



    public GameObject page1_panel;
    public GameObject page2_panel;


    public GameObject[] openThis;


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


        if (this.gameObject.name == "continue")
        {
            page1_panel.SetActive(false);
            page2_panel.SetActive(true);
        }
        else
        {
            page2_panel.SetActive(false);
            foreach (var item in openThis)
            {
                item.SetActive(true);
            }
        }
        gameObject.GetComponent<Image>().color = defaultColor;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
