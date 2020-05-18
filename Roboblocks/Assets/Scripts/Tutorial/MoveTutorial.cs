using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveTutorial : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public GameObject speech_bubble;
    public GameObject old_speech_bubble;
    public GameObject close_editor_speech;

    
    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        old_speech_bubble.SetActive(false);
        speech_bubble.SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.parent.name == "Empty_spot")
        {
            speech_bubble.SetActive(false);
            close_editor_speech.SetActive(true);
        }
        
    }
}
