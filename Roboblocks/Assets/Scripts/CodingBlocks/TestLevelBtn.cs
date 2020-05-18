using Assets.Scripts.Online_Level_Play;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestLevelBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject rotationSpeedSlider;
    public GameObject shootingSpeedSlider;
    public GameObject movementSpeedSlider;

    public GameObject scaleSlider;

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

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("savable");

        var savables = GameObject.FindGameObjectsWithTag("savable");
        List<Object> objects = new List<Object>();
        Level level = new Level();


        foreach (var item in savables)
        {


            if (item.name.Contains("Wall") || item.name.Contains("ramp"))
            {
                if (item.name.Contains("ramp"))
                {
                    Object a = new Object(item.transform.position.x, item.transform.position.y, item.transform.position.z, 
                        item.transform.localEulerAngles.x, item.transform.localEulerAngles.y, item.transform.localEulerAngles.z, item.GetComponent<Renderer>().material.color.r,
   item.GetComponent<Renderer>().material.color.g, item.GetComponent<Renderer>().material.color.b, item.name);
                    objects.Add(a);
                }
                else if (item.name.Contains("Wall"))
                {
                    Object a = new Object(item.transform.position.x, item.transform.position.y, item.transform.position.z,
                        item.transform.localEulerAngles.x, item.transform.localEulerAngles.y, item.transform.localEulerAngles.z, item.GetComponent<Renderer>().material.color.r,
item.GetComponent<Renderer>().material.color.g, item.GetComponent<Renderer>().material.color.b, item.name, item.transform.localScale.x, item.transform.localScale.y, item.transform.localScale.z);
                    objects.Add(a);
                }

            }else if(item.name.Contains("tank") || item.name.Contains("Tank"))
            {

                TankPropsStatic.BarrelRotationSpeed = rotationSpeedSlider.GetComponent<Slider>().value;
                TankPropsStatic.ShootingSpeed = shootingSpeedSlider.GetComponent<Slider>().value;
                TankPropsStatic.MovementSpeed = movementSpeedSlider.GetComponent<Slider>().value;



                TankPropsStatic.Scale = new Vector3(scaleSlider.GetComponent<Slider>().value, scaleSlider.GetComponent<Slider>().value, scaleSlider.GetComponent<Slider>().value);



                Object a = new Object(item.transform.position.x, item.transform.position.y, item.transform.position.z, item.transform.localEulerAngles.x, item.transform.localEulerAngles.y, item.transform.localEulerAngles.z, item.name);
                objects.Add(a);
            }
            else
            {
                Object a = new Object(item.transform.position.x, item.transform.position.y, item.transform.position.z, item.transform.localEulerAngles.x, item.transform.localEulerAngles.y, item.transform.localEulerAngles.z, item.name);
                objects.Add(a);
            }
        }

        level.objects = objects;
        level.name = "";
        level.description = "";
        level.date = DateTime.Now;
        LaunchedState.level = level;
 

        SceneManager.LoadScene("lastSave", LoadSceneMode.Single);

    }

}