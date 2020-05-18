using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public string selectedButton = null;
    public bool buttonChange;

    public GameObject selectedBrowserLevel = null;

    public GameObject logedInAs;

    public GameObject login_btn;
    public GameObject register_btn;
    public GameObject logout_btn;

    public void setLoginInfo()
    {
        logedInAs.SetActive(true);
        logedInAs.GetComponent<TextMeshProUGUI>().text = "Logged in as " + UserInfo.Username;
    }
    public void logout()
    {
        logedInAs.SetActive(false);
    }

    public void DisablePanel(string buttonName, Color defaultColor)
    {
        GameObject.Find(buttonName).GetComponent<Image>().color = defaultColor;
        GameObject.Find(buttonName).GetComponent<MenuBtn>().panel.SetActive(false);
    }
    void Start()
    {
        if (UserInfo.logedIn)
        {
            setLoginInfo();
            login_btn.SetActive(false);
            logout_btn.SetActive(true);
            register_btn.SetActive(false);

        }
    }

    void Update()
    {

    }
}
