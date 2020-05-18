using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialEditBtn : MonoBehaviour, IPointerClickHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickedColor;

    public GameObject edit_btn;
    public GameObject textbox;

    public GameObject speech_bubble;

    public GameObject move_tutorial_panel;


    public void OnPointerClick(PointerEventData eventData)
    {        textbox.SetActive(false);



        edit_btn.GetComponent<Animator>().SetBool("play_anim", false);
        move_tutorial_panel.SetActive(true);
        gameObject.SetActive(false);
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
