using Assets.Scripts.level_editor;
using Assets.Scripts.Online_Level_Play;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ObjectLoader : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject robot_prefab;
    public GameObject wall_prefab;
    public GameObject ramp_prefab;
    public GameObject lamp_prefab;
    public GameObject doors_prefab;
    public GameObject bridge_prefab;
    public GameObject finish_prefab;
    public GameObject tank_prefab;
    public int errorCtn;

    public GameObject errorPanel;


    public GameObject TM;

    public GameObject waypoint_prefab;

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
            errorCtn++;
            errorPanel.SetActive(true);

        }
        else
        {



            var a = JsonConvert.DeserializeObject<List<ObjectModel>>(uwr.downloadHandler.text);


            uwr = new UnityWebRequest("https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/tankproperties/" + LevelBrowserSelectedLevel.selected.name, "GET");

            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(null);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            uwr.certificateHandler = new BypassCertificate();


            yield return uwr.SendWebRequest();


            if (uwr.isNetworkError)
            {
                errorCtn++;
                errorPanel.SetActive(true);


            }
            else
            {
                var cc = JsonConvert.DeserializeObject<List<TankProperties>>(uwr.downloadHandler.text);

                foreach (var item in cc)
                {
                    TankPropsStatic.BarrelRotationSpeed = item.BarrelRotationSpeed;
                    TankPropsStatic.MovementSpeed = item.MovementSpeed;
                    TankPropsStatic.ShootingSpeed = item.ShootingSpeed;
                    TankPropsStatic.TriggerScale = item.TriggerScale;
                    
                }
            }



            uwr = new UnityWebRequest("https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/levelWaypoints/" + LevelBrowserSelectedLevel.selected.id, "GET");



            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(null);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            uwr.certificateHandler = new BypassCertificate();


            yield return uwr.SendWebRequest();


            if (uwr.isNetworkError)
            {
                errorCtn++;
                errorPanel.SetActive(true);



            }
            else
            {

                var b = JsonConvert.DeserializeObject<List<Waypoint>>(uwr.downloadHandler.text);

                TankPropsStatic.waypoints = JsonConvert.DeserializeObject<List<Waypoint>>(uwr.downloadHandler.text);

                foreach (var item in b)
                {
                    GameObject temp = Instantiate(waypoint_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    Destroy(temp.GetComponent<SelectedObj>());
                    temp.GetComponent<MeshRenderer>().enabled = false;
                }
            }

            if (errorCtn > 0)
            {
                errorPanel.SetActive(true);
            }

            foreach (var item in a)
            {
                if (item.name.Contains("robot"))
                {
                    GameObject temp = Instantiate(robot_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    Destroy(temp.GetComponent<SelectedObj>());
                    Destroy(temp.GetComponent<Draggable>());
                }
                else if (item.name.Contains("Wall"))
                {
                    GameObject temp = Instantiate(wall_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<Renderer>().material.color = new Color(item.r, item.g, item.b);
                    temp.transform.localScale = new Vector3(item.scaleX, item.scaleY, item.scaleZ);
                    Destroy(temp.GetComponent<SelectedObj>());
                    Destroy(temp.GetComponent<Draggable>());
                }
                else if (item.name.Contains("ramp"))
                {
                    GameObject temp = Instantiate(ramp_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<Renderer>().material.color = new Color(item.r, item.g, item.b);
                    Destroy(temp.GetComponent<SelectedObj>());
                    Destroy(temp.GetComponent<Draggable>());

                }
                else if (item.name.Contains("lamp"))
                {
                    GameObject temp = Instantiate(lamp_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    Destroy(temp.GetComponent<SelectedObj>());
                    Destroy(temp.GetComponent<Draggable>());
                }
                else if (item.name.Contains("doors"))
                {
                    GameObject temp = Instantiate(doors_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    Destroy(temp.GetComponent<SelectedObj>());
                    Destroy(temp.GetComponent<Draggable>());
                }
                else if (item.name.Contains("bridge"))
                {
                    GameObject temp = Instantiate(bridge_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    Destroy(temp.GetComponent<SelectedObj>());
                    Destroy(temp.GetComponent<Draggable>());
                }
                else if (item.name.Contains("finish"))
                {
                    GameObject temp = Instantiate(finish_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    Destroy(temp.GetComponent<SelectedObj>());
                    Destroy(temp.GetComponent<Draggable>());
                }
                else if (item.name.Contains("tank") || item.name.Contains("Tank"))
                {
                    GameObject temp = Instantiate(tank_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    Destroy(temp.transform.GetChild(0).GetComponent<SelectedObj>());
                    Destroy(temp.transform.GetChild(0).GetComponent<Draggable>());
                    Destroy(temp.transform.GetChild(0).GetComponent<TankTriggerManager>());

                    temp.transform.GetChild(0).FindChild("Sphere").GetComponent<TankShootManager>().speed = TankPropsStatic.BarrelRotationSpeed;
                    temp.transform.GetChild(0).FindChild("Sphere").GetComponent<TankShootManager>().shootSpeed = TankPropsStatic.ShootingSpeed;

                    temp.transform.GetChild(0).GetComponent<TankMovementManager>().movementSpeed = TankPropsStatic.MovementSpeed;


                    temp.transform.GetChild(0).FindChild("Sphere").localScale = new Vector3(TankPropsStatic.TriggerScale, TankPropsStatic.TriggerScale, TankPropsStatic.TriggerScale);




                }
            }

        }
    }

    void Start()
    {
        errorCtn = 0; 
        StartCoroutine(LoadLevels("https://roboblockswebapi20200518032741.azurewebsites.net/api/levels/levelObjects/" + LevelBrowserSelectedLevel.selected.id, ""));


    }
}

