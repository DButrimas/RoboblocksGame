using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;
using Assets.Scripts.Online_Level_Play;

public class LevelsLoader : MonoBehaviour,IPointerClickHandler
{
    public GameObject list_item_prefab;
    public GameObject context;
    public GameObject no_lvl_text;
    public GameObject error_connecting;

    public void OnPointerClick(PointerEventData eventData)
    {
        string uri = "https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/";

        int cnt = context.transform.childCount;

        for (int i = 0; i < cnt; i++)
        {
            Destroy(context.transform.GetChild(i).gameObject);
        }

        StartCoroutine(LoadLevels(uri, ""));


    }

    public class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
    public IEnumerator LoadLevels(string url, string registerdataJsonString)
    {

        var uwr = new UnityWebRequest(url, "GET");



        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(null);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.certificateHandler = new BypassCertificate();


        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
        }
        if (uwr.isNetworkError)
        {
            error_connecting.SetActive(true);


        }
        else
        {

            var a = JsonConvert.DeserializeObject<List<Level>>(uwr.downloadHandler.text);

            if (a.Count == 0)
            {
                no_lvl_text.SetActive(true);
            }
            else
            {
                no_lvl_text.SetActive(false);

            }


            foreach (var item in a)
            {

                GameObject temp = Instantiate(list_item_prefab, context.transform);
                temp.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.name;

                temp.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.username;

                temp.transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.date.ToShortDateString();

                temp.transform.GetChild(4).transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.description;


                temp.GetComponent<LevelBrowserItem>().level = item;

                if (item.rating == null || item.rating == 0)
                {

                }
                else if (item.rating == 1)
                {
                    temp.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                }
                else if (item.rating == 2)
                {
                    temp.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
                }
                else if (item.rating == 3)
                {
                    temp.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>().color = Color.yellow;
                }
                else if (item.rating == 4)
                {
                    temp.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(3).GetComponent<Image>().color = Color.yellow;

                }
                else if (item.rating == 5)
                {
                    temp.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(3).GetComponent<Image>().color = Color.yellow;
                    temp.transform.GetChild(2).transform.GetChild(4).GetComponent<Image>().color = Color.yellow;


                }

                string uri = "https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/getHighScore/" + item.id;

                uwr = new UnityWebRequest(uri, "GET");



                uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(null);
                uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                uwr.SetRequestHeader("Content-Type", "application/json");
                uwr.certificateHandler = new BypassCertificate();


                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError)
                {
                }
                else
                {
                    if (uwr.downloadHandler.text == "not found")
                    {
                        temp.transform.GetChild(4).transform.GetChild(1).transform.GetChild(3).gameObject.SetActive(false);
                        temp.transform.GetChild(4).transform.GetChild(1).transform.GetChild(4).gameObject.SetActive(false);
                        temp.transform.GetChild(4).transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
                    }
                    else
                    {
                        var bb = JsonConvert.DeserializeObject<TopLevelScore>(uwr.downloadHandler.text);

                        temp.transform.GetChild(4).transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
                        temp.transform.GetChild(4).transform.GetChild(1).transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Time: " + bb.Complition_time.ToString() + " seconds";
                        temp.transform.GetChild(4).transform.GetChild(1).transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "User: " + bb.User.ToString();

                    }
                }

            }


        }
    }
}
