using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadMainMenuConfirmBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;


    public GameObject editorMenuOptionsPanel;
    public GameObject editorMenuButton;

    public GameObject confirmLoadMainMenuPanel;


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

        gameObject.GetComponent<Image>().color = defaultColor;

        confirmLoadMainMenuPanel.SetActive(false);

        editorMenuOptionsPanel.SetActive(true);

        editorMenuButton.SetActive(true);


        var a = GameObject.FindGameObjectsWithTag("savable");
        foreach (var item in a)
        {
            Destroy(item.gameObject);
        }
        SelectedStatic.levels.Clear();
        SelectedStatic.selected_lvl = null;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
}