using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;


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

        GameObject go = GameObject.Find("LauncherHolder");
        go.GetComponent<Launcher>().Execute();

        SceneManager.LoadScene(2,LoadSceneMode.Single);

        gameObject.GetComponent<Image>().color = defaultColor;

    }
}