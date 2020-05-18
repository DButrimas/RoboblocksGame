using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;
using System.IO;
using System.Net;
using System;
using UnityEngine.Networking;
using System.Text;

public class SignUpManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;
    public Color defaultMenuButtonColor;

    public TextMeshProUGUI email;
    public TextMeshProUGUI password;
    public TextMeshProUGUI username;

    public GameObject email_error;
    public GameObject password_error;
    public GameObject username_error;

    public GameObject logout_btn;

    public GameObject pwd;

    public GameObject MenuManager;

    public string jsonstring;
    public string uri;

    public GameObject successPanel;

    public GameObject login_btn;
    public GameObject register_btn;

    public GameObject Menu_Panel;

    public void close()
    {
        username_error.GetComponent<TextMeshProUGUI>().enabled = false;
        password_error.GetComponent<TextMeshProUGUI>().enabled = false;
        email_error.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public void SignUp()
    {
        username_error.GetComponent<TextMeshProUGUI>().enabled = false;
        password_error.GetComponent<TextMeshProUGUI>().enabled = false;
        email_error.GetComponent<TextMeshProUGUI>().enabled = false;

        if (checkInput(username.text,password.text,email.text).Count == 0)
        {
            StartCoroutine(CallRegister(uri, jsonstring));
        }
        else
        {
            foreach (var err in checkInput(username.text, password.text, email.text))
            {
                if (err == "Please enter username")
                {
                    username_error.GetComponent<TextMeshProUGUI>().enabled = true;
                    username_error.GetComponent<TextMeshProUGUI>().text = err;
                }else if (err == "Please enter password")
                {
                    password_error.GetComponent<TextMeshProUGUI>().enabled = true;
                    password_error.GetComponent<TextMeshProUGUI>().text = err;
                }
                else if (err == "Please enter email")
                {
                    email_error.GetComponent<TextMeshProUGUI>().enabled = true;
                    email_error.GetComponent<TextMeshProUGUI>().text = err;
                }
                else if (err == "Username must contain at least 4 letters")
                {
                    username_error.GetComponent<TextMeshProUGUI>().enabled = true;
                    username_error.GetComponent<TextMeshProUGUI>().text = err;
                }
                else if (err == "Please enter valid email address")
                {
                    email_error.GetComponent<TextMeshProUGUI>().enabled = true;
                    email_error.GetComponent<TextMeshProUGUI>().text = err;
                }
                else if (err == "Password must contain at least 4 letters")
                {
                    password_error.GetComponent<TextMeshProUGUI>().enabled = true;
                    password_error.GetComponent<TextMeshProUGUI>().text = err;
                }
            }
        }
    }


    public class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
   

    public IEnumerator CallRegister(string url, string registerdataJsonString)
    {

        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(registerdataJsonString);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.certificateHandler = new BypassCertificate();
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            email_error.GetComponent<TextMeshProUGUI>().enabled = true;
            email_error.GetComponent<TextMeshProUGUI>().text = "Conection error.";
        }
        else
        {

            MenuManager.GetComponent<MainMenuManager>().DisablePanel(MenuManager.GetComponent<MainMenuManager>().selectedButton, defaultMenuButtonColor);

            MenuManager.GetComponent<MainMenuManager>().selectedButton = "";

            login_btn.SetActive(false);

            register_btn.SetActive(false);

            successPanel.SetActive(true);

            logout_btn.SetActive(true);

            UserInfo.Username = uwr.downloadHandler.text;
            UserInfo.logedIn = true;

            MenuManager.GetComponent<MainMenuManager>().setLoginInfo();


        }

    }
    public List<string> checkInput(string username, string password, string email)
    {
        List<string> error = new List<string>();

        var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

        if (username.Length == 1)
        {
            error.Add("Please enter username");
        }else if(password.Length == 1)
        {
            error.Add("Please enter password");
        }else if (email.Length == 1)
        {
            error.Add("Please enter email");
        }else if (username.Length < 4)
        {
            error.Add("Username must contain at least 4 letters");
        }
        else if (!regex.IsMatch(email))
        {
            error.Add("Please enter valid email address");
        }
        else if (password.Length < 4)
        {
            error.Add("Password must contain at least 4 letters");
        }
        return error;
    }

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
        jsonstring = $"{{ \"Email\" : \"{email.text}\",\"Password\" : \"{pwd.GetComponent<TMP_InputField>().text}\", \"Username\" : \"{username.text}\" }}";
        SignUp();
    }
    void Start()
    {
        uri = "https://roboblockswebapi20200518032741.azurewebsites.net/api/users/register";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
