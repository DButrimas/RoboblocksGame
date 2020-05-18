using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ToolBoxItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject itemPrefab;
    public Image itemImage;
    public GameObject instantietePoint;
    public Color def;
    public Color highlighted;

    public GameObject Draggable;

    public GameObject InfoPanel;

    public bool countdown;

    public void OnPointerDown(PointerEventData eventData)
    {
        SelectedStatic.selected = null;


        GameObject temp = Instantiate(itemPrefab, instantietePoint.transform.position, Quaternion.identity, null);
        temp.transform.position = new Vector3(1000, 1000, 1000);
        if (temp.name.Contains("robot"))
        {
            temp.transform.eulerAngles = new Vector3(270, 0, 0);
        }
        else
        {
            temp.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        Draggable = temp;
        Draggable.GetComponent<Draggable>().dragging = true;
        Draggable.GetComponent<Draggable>().dragable_prefab = temp;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Draggable.GetComponent<Draggable>().dragging = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = highlighted;

        InfoPanel.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = def;

        InfoPanel.SetActive(false);

    }

    void Start()
    {
        InfoPanel = gameObject.transform.GetChild(0).gameObject;
        InfoPanel.transform.position = new Vector2(gameObject.transform.position.x + InfoPanel.transform.GetComponent<RectTransform>().sizeDelta.x + 2, InfoPanel.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
