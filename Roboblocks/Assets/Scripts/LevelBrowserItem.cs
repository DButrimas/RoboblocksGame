using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelBrowserItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject MenuManager;

    public GameObject content;

    public Level level;

    public void Start()
    {
        MenuManager = GameObject.Find("ButtonAndPanelManager").gameObject;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        if (MenuManager.GetComponent<MainMenuManager>().selectedBrowserLevel != gameObject)
        {
            for (int i = 0; i < 4; i++)
            {
                gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color.r, gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color.g, gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color.b, gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color.a - 50);
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MenuManager.GetComponent<MainMenuManager>().selectedBrowserLevel != gameObject)
        {
            for (int i = 0; i < 4; i++)
            {
                gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color = new Color(gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color.r, gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color.g, gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color.b, gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().color.a + 50);
            }
        }

    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (MenuManager.GetComponent<MainMenuManager>().selectedBrowserLevel == null)
        {
            MenuManager.GetComponent<MainMenuManager>().selectedBrowserLevel = gameObject;

            gameObject.transform.GetChild(4).gameObject.SetActive(true);

            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y + 100);

            LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.transform.parent.transform.GetComponent<RectTransform>());

            LevelBrowserSelectedLevel.selected = level;
        }
        else
        {
            if (MenuManager.GetComponent<MainMenuManager>().selectedBrowserLevel == gameObject)
            {
                MenuManager.GetComponent<MainMenuManager>().selectedBrowserLevel = null;

                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y - 100);

                gameObject.transform.GetChild(4).gameObject.SetActive(false);

                LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.transform.parent.transform.GetComponent<RectTransform>());

                LevelBrowserSelectedLevel.selected = level;

            }
            else
            {


            }
        }

    }
}
