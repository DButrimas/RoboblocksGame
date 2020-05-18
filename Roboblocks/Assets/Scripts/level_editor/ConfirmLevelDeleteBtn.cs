using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class ConfirmLevelDeleteBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public GameObject LoadLevelPanel;
    public GameObject ConfirmLevelDeletePanel;
    public GameObject LevelDeleteSuccesPanel;

    public GameObject content;

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

        ConfirmLevelDeletePanel.SetActive(false);


        string destination = Application.persistentDataPath + "/" + SelectedStatic.selected_lvl.name + ".dat";

        if (File.Exists(destination)) File.Delete(destination);

        foreach (Level lvl in SelectedStatic.levels)
        {
            if (lvl.name == SelectedStatic.selected_lvl.name)
            {
                Destroy(content.transform.Find("lvl_prefab" + lvl.name).gameObject);
                SelectedStatic.selected_lvl = null;
                SelectedStatic.levels.Remove(lvl);
                break;
            }
        }

        LevelDeleteSuccesPanel.SetActive(true);

        gameObject.GetComponent<Image>().color = defaultColor;
    }
}