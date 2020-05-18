using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelBrowserPlayBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

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


        SceneManager.LoadScene("Player_level", LoadSceneMode.Single);


    }
}
