using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectedLevelLoader : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public GameObject level_name;
    public GameObject level_picture;

    public bool locked;
    public bool locked2;

    void Update()
    {
        if (level_picture.transform.childCount > 0)
        {
            locked = true;
        }

    }
    void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (locked == false)
        {
            gameObject.GetComponent<Image>().color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (locked == false)
        {
            gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (locked == false)
        {
            gameObject.GetComponent<Image>().color = clickedColor;

            SceneManager.LoadScene(level_name.GetComponent<TextMeshProUGUI>().text, LoadSceneMode.Single);

            gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
}