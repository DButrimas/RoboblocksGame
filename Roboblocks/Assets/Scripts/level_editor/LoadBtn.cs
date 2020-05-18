using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoadBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject robot_prefab;
    public GameObject wall_prefab;
    public GameObject ramp_prefab;
    public GameObject lamp_prefab;
    public GameObject doors_prefab;
    public GameObject bridge_prefab;
    public GameObject finish_prefab;
    public GameObject tank_prefab;
    public GameObject tank_prefab2;

    public GameObject waypoint_prefab;

    public GameObject confirmLoadLevelPanel;

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

        confirmLoadLevelPanel.SetActive(false);

        gameObject.GetComponent<Image>().color = defaultColor;

        var a = GameObject.FindGameObjectsWithTag("savable");
        foreach (var item in a)
        {
            Destroy(item);
        }



        if (SelectedStatic.selected_lvl != null)
        {
            foreach (Object item in SelectedStatic.selected_lvl.objects)
            {
                if (item.name.Contains("robot"))
                {
                   GameObject temp = Instantiate(robot_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                   temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = true;
                }
                else if (item.name.Contains("Wall"))
                {
                    GameObject temp = Instantiate(wall_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<Renderer>().material.color = new Color(item.r, item.g, item.b);
                    temp.GetComponent<SelectedObj>().enabled = true;
                    temp.transform.localScale = new Vector3(item.scaleX,item.scaleY,item.scaleZ);
                }
                else if (item.name.Contains("ramp"))
                {
                    GameObject temp = Instantiate(ramp_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<Renderer>().material.color = new Color(item.r, item.g, item.b);
                    temp.GetComponent<SelectedObj>().enabled = true;
                }
                else if (item.name.Contains("lamp"))
                {
                    GameObject temp = Instantiate(lamp_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = true;
                }
                else if (item.name.Contains("doors"))
                {
                    GameObject temp = Instantiate(doors_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = true;
                }
                else if (item.name.Contains("bridge"))
                {
                    GameObject temp = Instantiate(bridge_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = true;
                }
                else if (item.name.Contains("finish"))
                {
                    GameObject temp = Instantiate(finish_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = true;
                }
                else if (item.name.Contains("tank"))
                {
                    GameObject temp = Instantiate(tank_prefab2, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = true;

                }
                else if (item.name.Contains("waypoint"))
                {
                    GameObject temp = Instantiate(waypoint_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = true;
                }
            }
            
        }



    }
}
