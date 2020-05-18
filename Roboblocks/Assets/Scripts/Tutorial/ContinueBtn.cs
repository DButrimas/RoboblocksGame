using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ContinueBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public GameObject textToChange;

    public GameObject dropDown;

    public GameObject rightInp;

    public int clicked = 0;

    public Vector3 lastpos;
    public Vector3 newpos;

    public GameObject speechBubble;

    public GameObject[] openThis;


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
        if (clicked == 0)
        {
            gameObject.GetComponent<Image>().color = clickedColor;

            textToChange.GetComponent<TextMeshProUGUI>().text = "To change movement direction click on dropdown and select forward direction.";

            dropDown.GetComponent<Animator>().SetBool("play_anim", true);

            gameObject.GetComponent<Image>().color = defaultColor;

            clicked++;

            gameObject.transform.position = newpos;

        }else if (clicked == 1)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            foreach (var item in openThis)
            {
                item.SetActive(true);
            }
            speechBubble.SetActive(true);




            gameObject.GetComponent<Image>().color = clickedColor;

        }

    }
    void Start()
    {
        lastpos = gameObject.transform.position;
        newpos = new Vector3(10000,10000,10000);
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked == 1)
        {
            if (dropDown.GetComponent<TMP_Dropdown>().options[dropDown.GetComponent<TMP_Dropdown>().value].text == "forward")
            {
                gameObject.transform.position = lastpos;

                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Close";

            }
        }

        
    }
}
