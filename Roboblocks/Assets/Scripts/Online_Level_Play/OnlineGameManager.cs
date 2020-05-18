using Assets.Scripts.Online_Level_Play;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class OnlineGameManager : MonoBehaviour
{
    public GameObject victoryText;
    public GameObject gameOverText;
    public GameObject newHighScore;

    public GameObject ScoreTxt;
    public GameObject blocksTxt;
    public GameObject timeTxt;

    public GameObject Quit_btn;
    public GameObject Restart_btn;

    public GameObject rateThisLevelTxt;

    public GameObject errorPositngScore;

    public bool victory;
    public bool gameover;

    public float hujne;

    public Stopwatch sw;
    public string aaaaaaa;

    


    // Start is called before the first frame update
    void Start()
    {
        sw = new Stopwatch();
    }



    public class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
    public IEnumerator PostScore(string url, string j)
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
            if (uwr.downloadHandler.text == "new")
            {
                newHighScore.SetActive(true);
            }

        }
    }


    void Update()
    {
        aaaaaaa = sw.Elapsed.ToString();
        if (victory == true)
        {
            Quit_btn.SetActive(false);
            Restart_btn.SetActive(false);

            victoryText.SetActive(true);

            int secondsToadd = 0;

            if (GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Minutes > 0)
            {
                secondsToadd = GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Minutes * 60;
            }
            secondsToadd += GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Seconds;

            timeTxt.GetComponent<TextMeshProUGUI>().text = "Time: " + secondsToadd + "seconds";



            if (UserInfo.logedIn == true)
            {
                TopLevelScore r = new TopLevelScore();
                r.LevelId = LevelBrowserSelectedLevel.selected.id;
                r.User = UserInfo.Username;
                float secondsToadd2 = 0;
                if (GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Minutes > 0)
                {
                    secondsToadd2 = GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Minutes * 60;
                }
                secondsToadd2 += GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Seconds;


                r.Complition_time = secondsToadd2;

                string json = JsonUtility.ToJson(r, true);


                StartCoroutine(PostScore("https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/postScore/" + r.LevelId, json));
                victory = false;
            }

        }
        else if(gameover == true)
        {

            Quit_btn.SetActive(false);
            Restart_btn.SetActive(false);

            int secondsToadd = 0;

            if (GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Minutes > 0)
            {
                secondsToadd = GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Minutes * 60;
            }
            secondsToadd += GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Elapsed.Seconds;

            timeTxt.GetComponent<TextMeshProUGUI>().text = "Time: " + secondsToadd + "seconds";


            gameOverText.SetActive(true);

            timeTxt.SetActive(false);
        }
    }
}
