using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ToolboxItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject If_prefab;
    public GameObject move_fwd_prefab;
    public GameObject ToolBox_panel;
    public GameObject if_else_prefab;
    public string name;
    private bool Dropable;
    private Collider2D Other;
    private bool test;

    void Start()
    {
        ToolBox_panel = GameObject.Find("ToolBox_panel");

        foreach (Transform eachChild in transform)
        {
            if (eachChild.name.Contains("Empty_spot"))
            {
                eachChild.GetComponent<Collider2D>().enabled = false;
                
            }
        }

    }
    public void Snap()
    {
        Other.gameObject.GetComponent<RectTransform>().sizeDelta = this.gameObject.GetComponent<RectTransform>().sizeDelta;
        this.gameObject.transform.position = Other.transform.position;
        Other.GetComponent<Image>().color = Color.clear;
        this.transform.SetParent(Other.transform);
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name.Contains("Empty_spot"))
            {
                eachChild.GetComponent<Collider2D>().enabled = true;
            }
        }

        if (Other.gameObject.transform.parent.name == "If")
        {
            Other.gameObject.transform.parent.gameObject.transform.GetComponent<IfBlock>().createNewEmptySpot();

            if (test)
            {
                GameObject temp = Other.gameObject.transform.parent.gameObject;

                bool stop = false;

                while (!stop)
                {
                    if (temp.gameObject.transform.parent.name == "Panel")
                    {
                        if (temp.name == "If")
                        {
                            temp.gameObject.GetComponent<IfBlock>().resizeHeightAdd(gameObject.GetComponent<RectTransform>().sizeDelta.y);
                        }
                        else if (temp.name == "Begin_end")
                        {

                        }

                        stop = true;
                        break;
                    }

                    if (temp.name == "If")
                    {
                        temp.gameObject.GetComponent<IfBlock>().resizeHeightAdd(gameObject.GetComponent<RectTransform>().sizeDelta.y);
                        temp.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = temp.gameObject.GetComponent<RectTransform>().sizeDelta;
                    }
                    else if (temp.name == "Begin_end")
                    {
                        temp.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = temp.gameObject.GetComponent<RectTransform>().sizeDelta;
                    }

                    temp = temp.transform.parent.gameObject.transform.parent.gameObject;
                }
                test = false;
            }

        }
        else if (Other.gameObject.transform.parent.name == "Begin_end")
        {

            Other.gameObject.transform.parent.gameObject.GetComponent<BeginEndBlock>().setCreate();

            if (test)
            {
                GameObject temp = Other.gameObject.transform.parent.gameObject;

                bool stop = false;

                while (!stop)
                {
                    if (temp.gameObject.transform.parent.name == "Panel")
                    {
                        if (temp.name == "If")
                        {
                            temp.gameObject.GetComponent<IfBlock>().resizeHeightAdd(gameObject.GetComponent<RectTransform>().sizeDelta.y);
                        }
                        else if (temp.name == "Begin_end")
                        {

                        }

                        stop = true;
                        break;
                    }

                    if (temp.name == "If")
                    {
                        temp.gameObject.GetComponent<IfBlock>().resizeHeightAdd(gameObject.GetComponent<RectTransform>().sizeDelta.y);
                        temp.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = temp.gameObject.GetComponent<RectTransform>().sizeDelta;
                    }
                    else if (temp.name == "Begin_end")
                    {
                        temp.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = temp.gameObject.GetComponent<RectTransform>().sizeDelta;
                    }

                    temp = temp.transform.parent.gameObject.transform.parent.gameObject;
                }
                test = false;
            }
        }


    }


    // Update is called once per frame
    void Update()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (name == "if")
        {
            GameObject temp = Instantiate(If_prefab, transform.position, Quaternion.identity, ToolBox_panel.transform);
            temp.name = "If";
        }
        else if (name == "move_fwd")
        {
            GameObject temp = Instantiate(move_fwd_prefab, transform.position, Quaternion.identity, ToolBox_panel.transform);
            temp.name = "move_fwd";
        }else if (name == "if_else")
        {
            GameObject temp = Instantiate(if_else_prefab, transform.position, Quaternion.identity, ToolBox_panel.transform);
            temp.name = "If_else";
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (Dropable)
        {
            if (Other.transform.parent.transform.parent.name != "Panel")
            {
                test = true;
            }
            Snap();
            Dropable = false;
        }
        else
        {
            this.gameObject.transform.SetParent(GameObject.Find("Panel").transform);
        }

        foreach (Transform eachChild in transform)
        {
            if (eachChild.name.Contains("Empty_spot"))
            {
                eachChild.GetComponent<Collider2D>().enabled = true;
            }
        }

        if (name == "if")
        {
            gameObject.GetComponent<IfBlock>().enabled = true;
            gameObject.GetComponent<Dragable>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;


            gameObject.GetComponent<ToolboxItem>().enabled = false;
            Destroy(gameObject.GetComponent<ToolboxItem>());
        }
        else if (name == "move_fwd")
        {
            gameObject.GetComponent<Dragable>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;

            gameObject.GetComponent<ToolboxItem>().enabled = false;
        }else if (name == "if_else")
        {
            gameObject.GetComponent<Dragable>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;

            gameObject.GetComponent<ToolboxItem>().enabled = false;
        }


        Destroy(gameObject.GetComponent<ToolboxItem>());


    }
    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (check(other.name))
        {
            if (Other != null)
            {
            }
            else
            {
                other.GetComponent<Image>().color = Color.green;
                Dropable = true;
                Other = other;
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
    }


    void OnTriggerExit2D(Collider2D other)
    {
        Other = null;
    }
        bool check(string other_name)
    {
        if (this.name == "if" && other_name == "Empty_spot_body" || this.name == "if" && other_name == "Empty_spot")
        {
            return true;
        }
        else if (this.name == "Less" && other_name == "Empty_spot_if")
        {
            return true;
        }
        else if (this.name == "move_fwd" && other_name == "Empty_spot_body" || this.name == "move_fwd" && other_name == "Empty_spot")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}


