using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SaveLevelBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;



    public GameObject savePanel;


    public GameObject nameInput;
    public GameObject descriptionInput;

    public GameObject loadlevelpanel;


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

        nameInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Level name...";

        nameInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.black;

        descriptionInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Level description";

        descriptionInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.black;



        gameObject.GetComponent<Image>().color = clickedColor;
        savePanel = GameObject.Find("Canvas").transform.Find("Panel_save_level").gameObject;

        if (savePanel.active == false)
        {
            if (loadlevelpanel.active == true) {
                loadlevelpanel.SetActive(false);
            }
            savePanel.SetActive(true);
        }
        else
        {
            savePanel.SetActive(false);
        }

        gameObject.GetComponent<Image>().color = defaultColor;
    }
}