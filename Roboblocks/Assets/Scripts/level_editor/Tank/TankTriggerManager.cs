using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankTriggerManager : MonoBehaviour
{

    public GameObject slider;
    void Start()
    {
        slider = GameObject.Find("Canvas").transform.FindChild("tank_waypoints_panel").gameObject.transform.FindChild("Slider").gameObject;

    }

    void Update()
    {
        
        gameObject.transform.FindChild("Sphere").localScale = new Vector3(slider.GetComponent<Slider>().value, slider.GetComponent<Slider>().value, slider.GetComponent<Slider>().value);
    }

}
