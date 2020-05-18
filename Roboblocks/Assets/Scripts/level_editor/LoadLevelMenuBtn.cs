using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using TMPro;

public class LoadLevelMenuBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject savePanel;

    public GameObject content;
    public GameObject prefab_item;

    public GameObject nameInput;
    public GameObject descriptionInput;

    public GameObject savelevelpanel;


    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = defaultColor;
    }

    private bool checkIfContaint(string name)
    {
        foreach (var item in SelectedStatic.levels)
        {
            if (item.name == name)
            {
                return true;
            }
        }
        return false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {


        gameObject.GetComponent<Image>().color = clickedColor;

        savePanel = GameObject.Find("Canvas").transform.Find("Panel_load_level").gameObject;



        string destination = Application.persistentDataPath;

        var info = new DirectoryInfo(destination);
        var fileInfo = info.GetFiles();
        foreach (var file in fileInfo){
            if (file.Name.Contains(".dat"))
            {
                 FileStream f = file.OpenRead();
                 BinaryFormatter bf = new BinaryFormatter();
                 Level lvl = (Level)bf.Deserialize(f);

                if (SelectedStatic.levels.Count == 0)
                {
                    GameObject temp = Instantiate(prefab_item, new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    temp.transform.Find("Name_text").GetComponent<TextMeshProUGUI>().text = lvl.name;
                    temp.transform.Find("Date_text").GetComponent<TextMeshProUGUI>().text = lvl.date.ToString();

                    temp.GetComponent<LevelSelector>().lvl = lvl;
                    temp.name = "lvl_prefab" + lvl.name;
                    SelectedStatic.levels.Add(lvl);

                    content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, content.GetComponent<RectTransform>().sizeDelta.y + temp.GetComponent<RectTransform>().sizeDelta.y);

                }
                if (!checkIfContaint(lvl.name))
                {
                    GameObject temp = Instantiate(prefab_item, new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    temp.transform.Find("Name_text").GetComponent<TextMeshProUGUI>().text = lvl.name;
                    temp.transform.Find("Date_text").GetComponent<TextMeshProUGUI>().text = lvl.date.ToString();

                    temp.GetComponent<LevelSelector>().lvl = lvl;
                    temp.name = "lvl_prefab" + lvl.name;
                    SelectedStatic.levels.Add(lvl);

                    content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, content.GetComponent<RectTransform>().sizeDelta.y + temp.GetComponent<RectTransform>().sizeDelta.y);

                }

            }
        }

        nameInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Level name...";

        nameInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.black;

        descriptionInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().text = "Level description";

        descriptionInput.GetComponent<TMP_InputField>().placeholder.GetComponent<TextMeshProUGUI>().color = Color.black;



        if (savePanel.active == false)
        {
            if (savelevelpanel.active == true)
            {
                savelevelpanel.SetActive(false);
            }
            savePanel.SetActive(true);
        }
        else
        {
            savePanel.SetActive(false);
        }
        gameObject.GetComponent<Image>().color = defaultColor;

    }
}
