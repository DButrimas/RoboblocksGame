using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Logout : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;
    public GameObject signin_btn;
    public GameObject signup_btn;
    public GameObject MenuManager;

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

        signin_btn.SetActive(true);
        signup_btn.SetActive(true);

        MenuManager.GetComponent<MainMenuManager>().logout();
        UserInfo.Username = null;
        UserInfo.logedIn = false;

        gameObject.GetComponent<Image>().color = defaultColor;

        gameObject.SetActive(false);

    }
}