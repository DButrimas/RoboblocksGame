using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using System;

public class SaveLocalBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject nameInput;
    public GameObject descriptionInput;

    public GameObject successSavePanel;
    public GameObject savelevelpanel;

    public bool error = false;

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
                }else if (item.name.Contains("Wall"))
                {
                    Object a = new Object(item.transform.position.x, item.transform.position.y, item.transform.position.z, item.transform.localEulerAngles.x, item.transform.localEulerAngles.y, item.transform.localEulerAngles.z, item.GetComponent<Renderer>().material.color.r,
item.GetComponent<Renderer>().material.color.g, item.GetComponent<Renderer>().material.color.b, item.name,item.transform.localScale.x, item.transform.localScale.y, item.transform.localScale.z);
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

        string destination = Application.persistentDataPath + "/" + level.name + ".dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, level);
        file.Close();

        successSavePanel.SetActive(true);
        savelevelpanel.SetActive(false);

        gameObject.GetComponent<Image>().color = defaultColor;

    }
}
