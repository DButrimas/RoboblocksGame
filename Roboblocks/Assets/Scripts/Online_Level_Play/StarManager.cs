using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;

public class StarManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject confirmPanel;
    public GameObject levelLoadPanel;

    public GameObject rateThisLevelTxt;

    public bool blockChange;

    public float score = 0;


    public class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
    public IEnumerator RateLevel(string url, string j)
    {

        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(j);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.certificateHandler = new BypassCertificate();
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            rateThisLevelTxt.GetComponent<TextMeshProUGUI>().text = "Network error";
        }
        else
        {
            rateThisLevelTxt.GetComponent<TextMeshProUGUI>().text = "Thank you for rating !";
        }
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (blockChange == false)
        {

            if (gameObject.name.Contains("1"))
            {
                gameObject.GetComponent<Image>().color = hoverColor;
            }
            else if (gameObject.name.Contains("2"))
            {
                gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<Image>().color = hoverColor;
                gameObject.GetComponent<Image>().color = hoverColor;
            }
            else if (gameObject.name.Contains("3"))
            {
                gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<Image>().color = hoverColor;
                gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<Image>().color = hoverColor;

                gameObject.GetComponent<Image>().color = hoverColor;
            }
            else if (gameObject.name.Contains("4"))
            {
                gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<Image>().color = hoverColor;
                gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<Image>().color = hoverColor;
                gameObject.transform.parent.gameObject.transform.FindChild("Star3").GetComponent<Image>().color = hoverColor;


                gameObject.GetComponent<Image>().color = hoverColor;
            }
            else if (gameObject.name.Contains("5"))
            {
                gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<Image>().color = hoverColor;
                gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<Image>().color = hoverColor;
                gameObject.transform.parent.gameObject.transform.FindChild("Star3").GetComponent<Image>().color = hoverColor;
                gameObject.transform.parent.gameObject.transform.FindChild("Star4").GetComponent<Image>().color = hoverColor;



                gameObject.GetComponent<Image>().color = hoverColor;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (blockChange == true)
        {

        }
        else
        {
            gameObject.GetComponent<Image>().color = defaultColor;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (UserInfo.logedIn == false)
        {
            rateThisLevelTxt.GetComponent<TextMeshProUGUI>().text = "Login to rate this level !";

        }
        else
        {

            if (blockChange == false)
            {
                blockChange = true;

                if (gameObject.name.Contains("1"))
                {

                    gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star3").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star4").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star5").GetComponent<StarManager>().blockChange = true;

                    gameObject.GetComponent<Image>().color = hoverColor;
                    score = 1;
                }
                else if (gameObject.name.Contains("2"))
                {
                    gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star3").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star4").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star5").GetComponent<StarManager>().blockChange = true;




                    gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<Image>().color = hoverColor;
                    gameObject.GetComponent<Image>().color = hoverColor;
                    score = 2;
                }
                else if (gameObject.name.Contains("3"))
                {
                    gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star4").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star5").GetComponent<StarManager>().blockChange = true;



                    gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<Image>().color = hoverColor;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<Image>().color = hoverColor;

                    gameObject.GetComponent<Image>().color = hoverColor;
                    score = 3;
                }
                else if (gameObject.name.Contains("4"))
                {
                    gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star3").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star5").GetComponent<StarManager>().blockChange = true;




                    gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<Image>().color = hoverColor;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<Image>().color = hoverColor;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star3").GetComponent<Image>().color = hoverColor;


                    gameObject.GetComponent<Image>().color = hoverColor;
                    score = 4;
                }
                else if (gameObject.name.Contains("5"))
                {
                    gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star3").GetComponent<StarManager>().blockChange = true;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star4").GetComponent<StarManager>().blockChange = true;


                    gameObject.transform.parent.gameObject.transform.FindChild("Star1").GetComponent<Image>().color = hoverColor;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star2").GetComponent<Image>().color = hoverColor;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star3").GetComponent<Image>().color = hoverColor;
                    gameObject.transform.parent.gameObject.transform.FindChild("Star4").GetComponent<Image>().color = hoverColor;



                    gameObject.GetComponent<Image>().color = hoverColor;
                    score = 5;
                }

                Rating r = new Rating();
                r.LevelId = LevelBrowserSelectedLevel.selected.id;
                r.User = UserInfo.Username;

                r.User_rating = score;

                string json = JsonUtility.ToJson(r, true);


                StartCoroutine(RateLevel("https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/rateLevel/" + r.LevelId, json));
            }
        }

    }
}