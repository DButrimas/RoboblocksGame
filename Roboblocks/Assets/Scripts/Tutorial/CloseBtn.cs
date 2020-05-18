using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public GameObject[] closeThis;
    public GameObject speechBubble;
    public GameObject Run_btn;

    public GameObject closeSpeechBubble;


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

        foreach (var item in closeThis)
        {
            item.SetActive(false);
        }

        speechBubble.SetActive(true);

        Run_btn.SetActive(true);

        Run_btn.GetComponent<Animator>().SetBool("play_anim",true);

        gameObject.GetComponent<Image>().color = defaultColor;

        closeSpeechBubble.SetActive(false);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
