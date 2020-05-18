using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SavePanelCloseBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public GameObject save_panel;

    public GameObject nameInput;
    public GameObject descriptionInput;

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
        save_panel.SetActive(false);

        nameInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Level name...";

        nameInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.black;

        descriptionInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Level description";

        descriptionInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.black;

        gameObject.GetComponent<Image>().color = defaultColor;

    }
}
