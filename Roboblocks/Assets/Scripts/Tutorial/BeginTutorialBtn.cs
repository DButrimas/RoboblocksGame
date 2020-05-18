using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BeginTutorialBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public GameObject edit_btn;
    public GameObject textbox;


    


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

        gameObject.transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);

        edit_btn.SetActive(true);
        textbox.SetActive(true);

        edit_btn.GetComponent<Animator>().SetBool("play_anim",true);

        gameObject.GetComponent<Image>().color = defaultColor;

    }

    // Start is called before the first frame update
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
