using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.Networking;
using Assets.Scripts.level_editor;

public class Publish : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject nameInput;
    public GameObject descriptionInput;

    public GameObject successSavePanel;
    public GameObject savelevelpanel;
    public GameObject failSavePanel;
    public int errorCnt;


    public GameObject rotationSpeedSlider;
    public GameObject movementSpeedSlider;
    public GameObject shootingSpeedSlider;
    public GameObject triggerScaleSlider;



    public bool error = false;

    void Start()
    {
        errorCnt = 0;
        if (!UserInfo.logedIn)
        {
            gameObject.gameObject.SetActive(false);
        }
        else
        {
            gameObject.gameObject.SetActive(true);
        }
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

        if (nameInput.GetComponent<TMP_InputField>().text.ToString() == "")
        {
            nameInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Field can't be empty !";

            nameInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.red;

            error = true;
        }
        if (nameInput.GetComponent<TMP_InputField>().text.ToString() == "")
        {
            descriptionInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Field can't be empty !";

            descriptionInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.red;

            error = true;
        }

        if (error == true)
        {
            gameObject.GetComponent<Image>().color = defaultColor;
            error = false;
            return;
        }


        var savables = GameObject.FindGameObjectsWithTag("savable");
        List<Object> objects = new List<Object>();
        Level level = new Level();


        foreach (var item in savables)
        {


            if (item.name.Contains("Wall") || item.name.Contains("ramp"))
            {
                if (item.name.Contains("ramp"))
                {
                    Object a = new Object(item.transform.position.x, item.transform.position.y, item.transform.position.z, item.transform.localEulerAngles.x, item.transform.localEulerAngles.y, item.transform.localEulerAngles.z, item.GetComponent<Renderer>().material.color.r,
   item.GetComponent<Renderer>().material.color.g, item.GetComponent<Renderer>().material.color.b, item.name);
                    objects.Add(a);
                }
                else if (item.name.Contains("Wall"))
                {
                    Object a = new Object(item.transform.position.x, item.transform.position.y, item.transform.position.z, item.transform.localEulerAngles.x, item.transform.localEulerAngles.y, item.transform.localEulerAngles.z, item.GetComponent<Renderer>().material.color.r,
item.GetComponent<Renderer>().material.color.g, item.GetComponent<Renderer>().material.color.b, item.name, item.transform.localScale.x, item.transform.localScale.y, item.transform.localScale.z);
                    objects.Add(a);
                }

            }
            else
            {
                Object a = new Object(item.transform.position.x, item.transform.position.y, item.transform.position.z, item.transform.localEulerAngles.x, item.transform.localEulerAngles.y, item.transform.localEulerAngles.z, item.name);
                objects.Add(a);
            }
        }

        level.objects = objects;
        level.name = nameInput.GetComponent<TMP_InputField>().text.ToString();
        level.description = descriptionInput.GetComponent<TMP_InputField>().text.ToString();
        level.date = DateTime.Now;
        level.user = UserInfo.Username;


        string json = JsonUtility.ToJson(level, true);

        string uri = "https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/";


        StartCoroutine(PublishLevel(uri, json));


        gameObject.GetComponent<Image>().color = defaultColor;

    }
    public class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
    public IEnumerator PublishLevel(string url, string registerdataJsonString)
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
            failSavePanel.SetActive(true);

            errorCnt++;
        }
        else
        {
            float rotationSpeed = rotationSpeedSlider.GetComponent<Slider>().value;
            float movementSpeed = movementSpeedSlider.GetComponent<Slider>().value;
            float shootingSpeed = shootingSpeedSlider.GetComponent<Slider>().value;
            float triggerScale = triggerScaleSlider.GetComponent<Slider>().value;

            TankProperties tp = new TankProperties();
            tp.BarrelRotationSpeed = rotationSpeed;
            tp.MovementSpeed = movementSpeed;
            tp.ShootingSpeed = shootingSpeed;
            tp.TriggerScale = triggerScale;
            tp.levelName = nameInput.GetComponent<TMP_InputField>().text.ToString();

            url = "https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/tankproperties";
            string json3 = JsonUtility.ToJson(tp, true);


            uwr = new UnityWebRequest(url, "POST");
            jsonToSend = new System.Text.UTF8Encoding().GetBytes(json3);



            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            uwr.certificateHandler = new BypassCertificate();


            yield return uwr.SendWebRequest();


            if (uwr.isNetworkError)
            {
                failSavePanel.SetActive(true);

                errorCnt++;
            }
            else
            {

            }

            if (TankWaypoints.waypoints.Count > 0)
            {
                WaypointModel wpm = new WaypointModel();
                List<Waypoint> wpp = new List<Waypoint>();

                foreach (var item in TankWaypoints.waypointsGameobject)
                {
                    Waypoint p = new Waypoint();
                    p.posX = item.transform.position.x;
                    p.posY = item.transform.position.y;
                    p.posZ = item.transform.position.z;
                    wpp.Add(p);

                }
                wpm.waypoints = wpp;

                wpm.LevelName = nameInput.GetComponent<TMP_InputField>().text.ToString();

                url = "https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/waypoints";
                string json2 = JsonUtility.ToJson(wpm, true);


                uwr = new UnityWebRequest(url, "POST");
                jsonToSend = new System.Text.UTF8Encoding().GetBytes(json2);



                uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
                uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                uwr.SetRequestHeader("Content-Type", "application/json");
                uwr.certificateHandler = new BypassCertificate();

                yield return uwr.SendWebRequest();

  
                if (uwr.isNetworkError)
                {
                    failSavePanel.SetActive(true);

                    errorCnt++;
                }
                else
                {

                }
            }

            if (errorCnt > 0)
            {
                failSavePanel.SetActive(true);
            }
            else {
                successSavePanel.SetActive(true);
                savelevelpanel.SetActive(false);
            }

        }
    }
}
