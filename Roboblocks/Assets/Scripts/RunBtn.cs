using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RunBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject stop_btn;
    public GameObject edit_btn;

    public GameObject Quit_btn;
    public GameObject Restart_btn;

    public bool isTutorialLevel;


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
        if (LaunchedState.IsLoaunched)
        {
            return;
        }
        gameObject.GetComponent<Image>().color = clickedColor;


        GameObject go = GameObject.Find("LauncherHolder");
        go.GetComponent<Launcher>().Execute();
        gameObject.GetComponent<Image>().color = defaultColor;

       gameObject.SetActive(false);
        stop_btn.SetActive(true);
        if (edit_btn != null)
        {
            edit_btn.SetActive(false);

        }
        if (isTutorialLevel == false)
        {
            Quit_btn.transform.position = gameObject.transform.position;
            Restart_btn.transform.position = edit_btn.transform.position;
        }

    }
}
