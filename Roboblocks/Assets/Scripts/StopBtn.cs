using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StopBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Color defaultColor;
    public Color clickedColor;
    public Color hoverColor;

    public GameObject run_btn;
    public GameObject edit_btn;

    public GameObject player;
    public Vector3 playerStartingPos;
    public Vector3 playerStartingRot;

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
        if (!LaunchedState.IsLoaunched)
        {
            return;
        }
        gameObject.GetComponent<Image>().color = clickedColor;


        GameObject go = GameObject.Find("LauncherHolder");
        go.GetComponent<Launcher>().Execute();
        gameObject.GetComponent<Image>().color = defaultColor;

        gameObject.SetActive(false);
        run_btn.SetActive(true);
        edit_btn.SetActive(true);

        if (isTutorialLevel == true && player != null)
        {
            player.transform.position = playerStartingPos;
            player.transform.rotation = Quaternion.Euler(playerStartingRot);
        }

    }
}
