


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Dragable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{


    public Collider2D Other;
    public GameObject Panel;
    public Collider2D attachedTo;

    public bool Draging;
    public bool Dropable;
    public bool enteredTrigger;
    public bool exitedTrigger;
    public bool haveMoved;

    public GameObject testavimas;
    public GameObject testavimas2;

    public Color emptySpotDefault;
    public Color emptySpotHighlighted;
    public Color textInputColor;
    public Color trashcanDefault;


    public GameObject If_prefab;
    public GameObject move_prefab;
    public GameObject If_else_prefab;
    public GameObject While_prefab;
    public GameObject Set_prefab;
    public GameObject Create_var_prefab;
    public GameObject Equal_prefab;
    public GameObject Var_prefab;
    public GameObject Minus_prefab;
    public GameObject Wait_prefab;
    public GameObject Less_prefab;
    public GameObject Greater_prefab;
    public GameObject Shoot_Prefab;
    public GameObject Rotate_prefab;
    public GameObject Stop_Prefab;

    public GameObject var_list;



    public GameObject TrashCan;

    public bool delete_block;
    public bool canDelete;


    public bool test;

    void Start()
    {
        Panel = GameObject.Find("Panel");

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            TrashCan = GameObject.Find("Canvas2").gameObject.transform.Find("trashcan").gameObject;
        }
        else
        {
            TrashCan = GameObject.Find("Canvas").gameObject.transform.Find("trashcan").gameObject;

        }
        trashcanDefault = new Color(TrashCan.GetComponent<Image>().color.r, TrashCan.GetComponent<Image>().color.g, TrashCan.GetComponent<Image>().color.b, emptySpotHighlighted.a);
        var_list = GameObject.Find("var_list").gameObject;


    }

    void Update()
    {


    }

    public void ResizeHierarchy(string s)
    {
        if (s == "Begin_end")
        {
            attachedTo.transform.parent.gameObject.GetComponent<BeginEndBlock>().setCreate();
        }
        else if (s == "If")
        {
            if (this.gameObject.name == "Equal" || this.gameObject.name == "Greater" || this.gameObject.name == "Less")
            {

                EnableEmptySpots();

                return;
            }

            attachedTo.transform.parent.gameObject.GetComponent<IfBlock>().createNewEmptySpot();
        }
        else if (s == "While")
        {
            attachedTo.transform.parent.gameObject.GetComponent<WhileBlock>().createNewEmptySpot();
        }
        else if (s == "If_else")
        {
            if (attachedTo.gameObject.name == "Empty_spot_body")
            {
                attachedTo.transform.parent.gameObject.transform.GetComponent<IfElseBlock>().createNewEmptySpot();

            }
            else if (attachedTo.gameObject.name == "Empty_spot_else")
            {
                attachedTo.transform.parent.gameObject.transform.GetComponent<IfElseBlock>().createNewEmptySpotElse();
            }
        }
        if (test)
        {
            int cnt = 0;

            GameObject temp = attachedTo.transform.parent.gameObject;

            bool stop = false;

            while (!stop)
            {
                if (temp.gameObject.transform.parent.name == "Panel")
                {
                    if (temp.name == "If")
                    {
                        temp.gameObject.GetComponent<IfBlock>().resizeHeightAdd(gameObject.transform.GetComponent<RectTransform>().sizeDelta.y);
                        temp.transform.Find("Empty_spot_body").GetComponent<RectTransform>().sizeDelta = temp.transform.Find("Empty_spot_body").transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
                        temp.transform.Find("Empty_spot_body").transform.GetChild(0).transform.position = temp.transform.Find("Empty_spot_body").transform.position;

                    }
                    else if (temp.name == "Begin_end")
                    {
                        temp.transform.Find("Empty_spot").GetComponent<RectTransform>().sizeDelta = temp.transform.Find("Empty_spot").transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
                        temp.transform.Find("Empty_spot").transform.GetChild(0).transform.position = temp.transform.Find("Empty_spot").transform.position;
                    }
                    else if (temp.name == "If_else")
                    {
                        temp.gameObject.GetComponent<IfElseBlock>().resizeHeightAdd(gameObject.GetComponent<RectTransform>().sizeDelta.y);
                    }
                    else if (temp.name == "While")
                    {
                        temp.gameObject.GetComponent<WhileBlock>().resizeHeightAdd(gameObject.transform.GetComponent<RectTransform>().sizeDelta.y);
                    }

                    stop = true;
                    break;
                }

                if (temp.name == "If")
                {


                    if (cnt > 0)
                    {
                        temp.gameObject.GetComponent<IfBlock>().resizeHeightAdd(gameObject.transform.GetComponent<RectTransform>().sizeDelta.y);
                    }

                    cnt++;


                    temp.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = temp.gameObject.GetComponent<RectTransform>().sizeDelta;
                    temp.gameObject.transform.position = temp.transform.parent.gameObject.transform.position;





   



                }
                else if (temp.name == "Begin_end")
                {
                    temp.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = temp.gameObject.GetComponent<RectTransform>().sizeDelta;
                }
                else if (temp.name == "If_else")
                {
                    if (cnt > 0)
                    {
                        temp.gameObject.GetComponent<IfElseBlock>().resizeHeightAdd(gameObject.transform.GetComponent<RectTransform>().sizeDelta.y);
                    }

                    temp.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = temp.gameObject.GetComponent<RectTransform>().sizeDelta;
                    temp.gameObject.transform.position = temp.transform.parent.gameObject.transform.position;
                    cnt++;
                }
                else if (temp.name == "While")
                {
                    if (cnt > 0)
                    {
                        temp.gameObject.GetComponent<WhileBlock>().resizeHeightAdd(gameObject.transform.GetComponent<RectTransform>().sizeDelta.y);
                    }


                    temp.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = temp.gameObject.GetComponent<RectTransform>().sizeDelta;
                    temp.gameObject.transform.position = temp.transform.parent.gameObject.transform.position;
                    cnt++;

                }


                temp = temp.transform.parent.gameObject.transform.parent.gameObject;
            }
            test = false;
        }

    }





    public void DisableEmptySpots()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name.Contains("Empty_spot") || eachChild.name.Contains("_inp") || eachChild.name.Contains("input"))
            {
                eachChild.GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    public void EnableEmptySpots()
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name.Contains("Empty_spot") && eachChild.childCount == 0 || eachChild.name.Contains("_inp") || eachChild.name.Contains("input"))
            {
                eachChild.GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DisableEmptySpots();
        Draging = true;


        if (haveMoved == false)
        {
            if (gameObject.name == "If")
            {
                GameObject temp = Instantiate(If_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                this.gameObject.transform.SetParent(Panel.transform);
                temp.name = "If";
                gameObject.GetComponent<IfBlock>().enabled = true;

                foreach (Transform item in temp.transform)
                {
                    if (!item.name.Contains("Empty"))
                    {
                        item.GetComponent<Image>().color = new Color(item.GetComponent<Image>().color.r, item.GetComponent<Image>().color.g - 0.1f, item.GetComponent<Image>().color.b, item.GetComponent<Image>().color.a);
                    }
                }

            }
            else if (gameObject.name == "move")
            {
                GameObject temp = Instantiate(move_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "move";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "wait")
            {
                GameObject temp = Instantiate(Wait_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "wait";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "rotate")
            {
                GameObject temp = Instantiate(Rotate_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "rotate";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "shoot")
            {
                GameObject temp = Instantiate(Shoot_Prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "shoot";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "stop")
            {
                GameObject temp = Instantiate(Stop_Prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "stop";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "If_else")
            {
                GameObject temp = Instantiate(If_else_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "If_else";
                this.gameObject.transform.SetParent(Panel.transform);
                gameObject.GetComponent<IfElseBlock>().enabled = true;

                foreach (Transform item in temp.transform)
                {
                    if (!item.name.Contains("Empty"))
                    {
                        item.GetComponent<Image>().color = new Color(item.GetComponent<Image>().color.r, item.GetComponent<Image>().color.g, item.GetComponent<Image>().color.b - 0.1f, item.GetComponent<Image>().color.a);
                    }
                }
            }
            else if (gameObject.name == "While")
            {
                GameObject temp = Instantiate(While_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "While";
                this.gameObject.transform.SetParent(Panel.transform);
                gameObject.GetComponent<WhileBlock>().enabled = true;

                foreach (Transform item in temp.transform)
                {
                    if (!item.name.Contains("Empty"))
                    {
                        item.GetComponent<Image>().color = new Color(item.GetComponent<Image>().color.r, item.GetComponent<Image>().color.g - 0.1f, item.GetComponent<Image>().color.b - 0.1f, item.GetComponent<Image>().color.a);
                    }
                }
            }
            else if (gameObject.name == "Set")
            {
                GameObject temp = Instantiate(Set_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                this.gameObject.transform.SetParent(Panel.transform);
                temp.name = "Set";
                var_list.GetComponent<VariablesManager>().dropdown_managers.Add(temp);
            }
            else if (gameObject.name == "Create_var")
            {
                GameObject temp = Instantiate(Create_var_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "Create_var";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "Equal")
            {
                GameObject temp = Instantiate(Equal_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "Equal";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "Less")
            {
                GameObject temp = Instantiate(Less_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "Less";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "Greater")
            {
                GameObject temp = Instantiate(Greater_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "Greater";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "Var")
            {
                GameObject temp = Instantiate(Var_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "Var";
                this.gameObject.transform.SetParent(Panel.transform);
                var_list.GetComponent<VariablesManager>().dropdown_managers.Add(temp);
            }
            else if (gameObject.name == "Var_distance")
            {
                GameObject temp = Instantiate(Var_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "Var";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            else if (gameObject.name == "Minus")
            {
                GameObject temp = Instantiate(Minus_prefab, transform.position, Quaternion.identity, this.gameObject.transform.parent);
                temp.name = "Minus";
                this.gameObject.transform.SetParent(Panel.transform);
            }
            haveMoved = true;
        }

    }

    public void ResizeHierarchyDown(string s, bool stick)
    {
        if (s == "Equal" || s == "Greater" || s == "Less")
        {
            if (stick)
            {
                this.transform.SetParent(Other.transform);

                Snap();
                return;
            }
            foreach (Transform eachChild in attachedTo.transform)
            {
                if (eachChild.name.Contains("InputField"))
                {
                    eachChild.gameObject.SetActive(true);
                    eachChild.gameObject.GetComponent<Image>().color = textInputColor;
                }
            }


            this.gameObject.transform.SetParent(Panel.transform);
            attachedTo.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(29.5f, 16.8f);
            if (attachedTo.gameObject)
            {

            }
            attachedTo.GetComponent<Collider2D>().enabled = true;

            return;
        }
        else if (s == "While")
        {
            if (!stick)
            {
                this.gameObject.transform.SetParent(Panel.transform);
                attachedTo.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(58.1f, 15f);
                attachedTo.GetComponent<Collider2D>().enabled = true;
                attachedTo.transform.parent.gameObject.transform.GetComponent<WhileBlock>().removeEmptySpot(attachedTo.gameObject);
                if (gameObject.name == "Equal" || gameObject.name == "Less" || gameObject.name == "Greater")
                {

                }
                else
                {
                    attachedTo.transform.parent.gameObject.transform.GetComponent<WhileBlock>().resizeHeight(this.gameObject.GetComponent<RectTransform>().sizeDelta.y);

                }

            }
            else
            {
                this.transform.SetParent(Other.transform);
                attachedTo.transform.parent.gameObject.transform.GetComponent<WhileBlock>().removeEmptySpot(attachedTo.gameObject);
                attachedTo.transform.parent.gameObject.transform.GetComponent<WhileBlock>().resizeHeight(this.gameObject.GetComponent<RectTransform>().sizeDelta.y);
                attachedTo = Other;

                Snap();
                return;
            }
        }
        else if (s == "Set")
        {
            if (!stick)
            {
                this.gameObject.transform.SetParent(Panel.transform);
                foreach (Transform eachChild in attachedTo.transform)
                {
                    if (eachChild.name.Contains("InputField"))
                    {
                        eachChild.gameObject.SetActive(true);
                        eachChild.gameObject.GetComponent<Image>().color = textInputColor;
                        SetTrueActiveState(eachChild.gameObject, true);
                    }
                }
                attachedTo.GetComponent<Collider2D>().enabled = true;
                attachedTo.GetComponent<RectTransform>().sizeDelta = new Vector2(31.6f, 14.9f);
            }
            else
            {
                this.gameObject.transform.SetParent(Other.transform);

                Snap();

            }

            return;
        }
        if (s == "Begin_end")
        {
            if (stick)
            {
                this.transform.SetParent(Other.transform);

                attachedTo.transform.parent.gameObject.transform.GetComponent<BeginEndBlock>().removeEmptySpot(attachedTo.gameObject);

                attachedTo = Other;

                Snap();

            }
            else
            {
                this.transform.SetParent(GameObject.Find("Panel").transform);

                attachedTo.transform.parent.gameObject.transform.GetComponent<BeginEndBlock>().removeEmptySpot(attachedTo.gameObject);

            }
            return;
        }
        else if (s == "If")
        {
            if (this.gameObject.name == "Equal" || this.gameObject.name == "Less" || this.gameObject.name == "Greater")
            {
                if (stick)
                {
                    this.transform.SetParent(Other.transform);
                }

                attachedTo.GetComponent<Collider2D>().enabled = true;

                if (gameObject.name == "Equal" || gameObject.name == "Less" || gameObject.name == "Greater")
                {

                }
                else
                {
                    attachedTo.transform.parent.gameObject.transform.GetComponent<IfBlock>().resizeHeight(this.gameObject.GetComponent<RectTransform>().sizeDelta.y);
                }

                this.gameObject.transform.SetParent(Panel.transform);

                return;
            }
            else
            {
                if (stick)
                {
                    this.transform.SetParent(Other.transform);
                }
                float sizeToRemove = this.gameObject.GetComponent<RectTransform>().sizeDelta.y;

                attachedTo.transform.parent.gameObject.transform.GetComponent<IfBlock>().removeEmptySpot(attachedTo.gameObject);

                attachedTo.transform.parent.gameObject.transform.GetComponent<IfBlock>().resizeHeight(sizeToRemove);



            }
        }
        else if (s == "If_else")
        {
            if (attachedTo.gameObject.name == "Empty_spot_body")
            {
                if (stick)
                {
                    this.transform.SetParent(Other.transform);
                }

                float sizeToRemove = attachedTo.GetComponent<RectTransform>().sizeDelta.y;

                attachedTo.transform.parent.gameObject.transform.GetComponent<IfElseBlock>().removeEmptySpot(attachedTo.gameObject);

                if (gameObject.name == "Equal" || gameObject.name == "Less" || gameObject.name == "Greater")
                {

                }
                else
                {
                    attachedTo.transform.parent.gameObject.transform.GetComponent<IfElseBlock>().resizeHeight(sizeToRemove);
                }


            }
            else if (attachedTo.gameObject.name == "Empty_spot_else")
            {
                if (stick)
                {
                    this.transform.SetParent(Other.transform);
                }

                float sizeToRemove = attachedTo.GetComponent<RectTransform>().sizeDelta.y;

                attachedTo.transform.parent.gameObject.transform.GetComponent<IfElseBlock>().removeEmptySpotElse(attachedTo.gameObject);

                attachedTo.transform.parent.gameObject.transform.GetComponent<IfElseBlock>().resizeHeight(sizeToRemove);

            }
        }

        if (attachedTo.transform.parent.gameObject.transform.parent.gameObject.name != "Panel")
        {


            attachedTo.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = attachedTo.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta;
        }

        attachedTo.transform.parent.gameObject.transform.GetComponent<Dragable>().EnableEmptySpots();

        bool stop = false;
        GameObject temp = attachedTo.gameObject.transform.parent.gameObject;

        int cnt = 0;


        while (!stop)
        {

            if (temp.name.Contains("Empty_spot"))
            {
                temp.GetComponent<Image>().color = Color.red;
                stop = true;
                break;
            }

            if (temp.transform.parent.name == "Panel" || temp.transform.parent.name == "Canvas")
            {
                stop = true;
                break;
            }
            if (temp.transform.parent.name == "Begin_end")
            {
                temp.GetComponent<RectTransform>().sizeDelta = temp.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
                temp.transform.GetChild(0).transform.position = temp.transform.position;
                stop = true;
                break;
            }

            temp = temp.transform.parent.gameObject;

            temp.GetComponent<RectTransform>().sizeDelta = temp.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
            temp.transform.GetChild(0).transform.position = temp.transform.position;
            if (temp.transform.parent.name == "If")
            {
                temp.transform.parent.GetComponent<IfBlock>().resizeHeight(gameObject.GetComponent<RectTransform>().sizeDelta.y);
            }
            if (temp.transform.parent.name == "While")
            {
                temp.transform.parent.GetComponent<WhileBlock>().resizeHeight(gameObject.GetComponent<RectTransform>().sizeDelta.y);
            }
            temp = temp.transform.parent.gameObject;


        }
        if (stick)
        {
            attachedTo = Other;

            test = true;

            Snap();
        }

    }
    public bool CheckIfCollidingWithTextInput(Collider2D col)
    {
        if (col.name == "left_inp" || col.name == "right_inp" || col.name == "input_set")
        {
            return true;
        }
        return false;
    }
    public void Snap()
    {
        if (CheckIfCollidingWithTextInput(Other))
        {
            if (attachedTo.name == "left_inp" && Other.name == "right_inp" || attachedTo.name == "right_inp" && Other.name == "left_inp"
                || attachedTo.name == "right_inp" && Other.name == "input_set" || attachedTo.name == "left_inp" && Other.name == "input_set"
                || attachedTo.name == "input_set" && Other.name == "left_inp" || attachedTo.name == "input_set" && Other.name == "right_inp" ||
               attachedTo.name == "right_inp" && Other.name == "right_inp" || attachedTo.name == "left_inp" && Other.name == "right_set")
            {

                foreach (Transform eachChild in attachedTo.transform)
                {
                    if (eachChild.name.Contains("InputField"))
                    {
                        eachChild.gameObject.SetActive(true);
                        eachChild.gameObject.GetComponent<Image>().color = textInputColor;
                        SetTrueActiveState(eachChild.gameObject, true);
                    }
                }

                foreach (Transform eachChild in Other.transform)
                {
                    if (eachChild.name.Contains("InputField"))
                    {
                        eachChild.gameObject.SetActive(false);
                        SetTrueActiveState(eachChild.gameObject, false);
                    }
                }

                attachedTo.GetComponent<RectTransform>().sizeDelta = new Vector2(29.5f, 16.8f);

                Other.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta;

                this.transform.SetParent(Other.transform);

                this.gameObject.transform.position = Other.transform.position;

                attachedTo.GetComponent<Collider2D>().enabled = true;

                attachedTo = Other;

                Other.GetComponent<Collider2D>().enabled = false;

                EnableEmptySpots();
            }
            else
            {
                foreach (Transform eachChild in attachedTo.transform)
                {
                    if (eachChild.name.Contains("InputField"))
                    {
                        eachChild.gameObject.SetActive(false);
                        SetTrueActiveState(eachChild.gameObject, false);
                    }
                }

                Other.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
                this.gameObject.transform.position = Other.transform.position;
                this.transform.SetParent(Other.transform);
                EnableEmptySpots();
                attachedTo.GetComponent<Collider2D>().enabled = false;
            }
        }
        else
        {
            if (this.gameObject.name == "Equal" || this.gameObject.name == "Greater" || this.gameObject.name == "Less")
            {

                Other.GetComponent<Image>().color = Color.clear;
                this.transform.SetParent(Other.transform);
                foreach (Transform eachChild in attachedTo.transform)
                {
                    if (eachChild.name.Contains("InputField"))
                    {
                        eachChild.gameObject.SetActive(true);
                    }
                }
                if (attachedTo.gameObject.name == "Empty_spot_while")
                {
                    Other.GetComponent<RectTransform>().sizeDelta = this.gameObject.GetComponent<RectTransform>().sizeDelta;

                    attachedTo.GetComponent<Collider2D>().enabled = true;
                    this.gameObject.transform.position = Other.transform.position;
                    attachedTo = Other;
                    Other.GetComponent<Collider2D>().enabled = false;


                }
                else if (attachedTo.gameObject.name == "Empty_spot_if")
                {
                    Other.GetComponent<RectTransform>().sizeDelta = this.gameObject.GetComponent<RectTransform>().sizeDelta;
                    this.gameObject.transform.position = Other.transform.position;
                    attachedTo = Other;
                    Other.GetComponent<Collider2D>().enabled = false;
                    ResizeHierarchy("If");
                    return;
                }
                else
                {
                    attachedTo.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(29.5f, 16.8f);
                    attachedTo.GetComponent<Collider2D>().enabled = true;
                    this.gameObject.transform.position = Other.transform.position;
                    attachedTo = Other;
                    Other.GetComponent<Collider2D>().enabled = false;
                }
                EnableEmptySpots();
                return;
            }
            else if (this.gameObject.name == "Minus")
            {
                this.gameObject.transform.position = Other.transform.position;
                Other.GetComponent<Image>().color = Color.clear;
                this.transform.SetParent(Other.transform);
                Other.GetComponent<Collider2D>().enabled = false;
                EnableEmptySpots();
                return;
            }
            else if (this.gameObject.name == "Set")
            {

                Other.GetComponent<RectTransform>().sizeDelta = this.gameObject.GetComponent<RectTransform>().sizeDelta;
                this.gameObject.transform.position = Other.transform.position;
                Other.GetComponent<Image>().color = Color.clear;
                this.transform.SetParent(Other.transform);
                Other.GetComponent<Collider2D>().enabled = false;
                EnableEmptySpots();

                if (attachedTo.transform.parent.name == "If")
                {
                    ResizeHierarchy("If");
                }
                else if (attachedTo.transform.parent.name == "Begin_end")
                {
                    ResizeHierarchy("Begin_end");
                }
                else if (attachedTo.transform.parent.name == "If_else")
                {
                    ResizeHierarchy("If_else");
                }
                else if (attachedTo.transform.parent.name == "While")
                {
                    ResizeHierarchy("While");
                }

                return;
            }
            else if (this.gameObject.name == "Create_var")
            {
                this.gameObject.transform.position = Other.transform.position;
                Other.GetComponent<Image>().color = Color.clear;
                Other.GetComponent<RectTransform>().sizeDelta = this.gameObject.GetComponent<RectTransform>().sizeDelta;
                this.transform.SetParent(Other.transform);
                Other.GetComponent<Collider2D>().enabled = false;
                EnableEmptySpots();

                if (attachedTo.transform.parent.name == "If")
                {
                    ResizeHierarchy("If");
                }
                else if (attachedTo.transform.parent.name == "Begin_end")
                {
                    ResizeHierarchy("Begin_end");
                }
                else if (attachedTo.transform.parent.name == "If_else")
                {
                    ResizeHierarchy("If_else");
                }
                else if (attachedTo.transform.parent.name == "While")
                {
                    ResizeHierarchy("While");
                }

                return;
            }

            else
            {
                Other.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
                this.gameObject.transform.position = Other.transform.position;
                Other.GetComponent<Image>().color = Color.clear;
                this.transform.SetParent(Other.transform);
                EnableEmptySpots();
                Other.GetComponent<Collider2D>().enabled = false;

                if (attachedTo.transform.parent.name == "If")
                {
                    ResizeHierarchy("If");
                }
                else if (attachedTo.transform.parent.name == "Begin_end")
                {
                    ResizeHierarchy("Begin_end");
                }
                else if (attachedTo.transform.parent.name == "If_else")
                {
                    ResizeHierarchy("If_else");
                }
                else if (attachedTo.transform.parent.name == "While")
                {
                    ResizeHierarchy("While");
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDelete == true) {
            TrashCan.GetComponent<Image>().color = trashcanDefault;
            Destroy(gameObject);
        }


        delete_block = true;
        if (enteredTrigger && Dropable && attachedTo == null)
        {
            if (Other.transform.parent.transform.parent != Panel.transform)
            {
                test = true;
            }

            attachedTo = Other;
            Snap();
        }

        else if (Dropable && attachedTo != Other)
        {
            if (attachedTo.transform.parent.name == "If")
            {
                ResizeHierarchyDown("If", true);

            }
            else if (attachedTo.transform.parent.name == "Begin_end")
            {
                ResizeHierarchyDown("Begin_end", true);

            }
            else if (attachedTo.transform.parent.name == "If_else")
            {
                ResizeHierarchyDown("If_else", true);
            }
            else if (attachedTo.transform.parent.name == "Equal" || attachedTo.transform.parent.name == "Minus" || attachedTo.transform.parent.name == "Greater" || attachedTo.transform.parent.name == "Less")
            {
                ResizeHierarchyDown("Equal", true);
            }
            else if (attachedTo.transform.parent.name == "Set")
            {
                ResizeHierarchyDown("Set", true);
            }
            else if (attachedTo.transform.parent.name == "While")
            {
                ResizeHierarchyDown("While", true);
            }

        }
        else if (Dropable && attachedTo == Other && exitedTrigger)
        {
            this.gameObject.transform.position = Other.transform.position;
            EnableEmptySpots();
        }
        else
        {
            transform.SetParent(Panel.transform);
            EnableEmptySpots();


            if (attachedTo != null)
            {
                if (attachedTo.transform.parent.name == "If")
                {
                    ResizeHierarchyDown("If", false);
                }
                else if (attachedTo.transform.parent.name == "Begin_end")
                {
                    ResizeHierarchyDown("Begin_end", false);

                }
                else if (attachedTo.transform.parent.name == "If_else")
                {
                    ResizeHierarchyDown("If_else", false);
                }
                else if (attachedTo.transform.parent.name == "Equal" || attachedTo.transform.parent.name == "Minus" || attachedTo.transform.parent.name == "Greater" || attachedTo.transform.parent.name == "Less")
                {
                    ResizeHierarchyDown("Equal", false);
                }
                else if (attachedTo.transform.parent.name == "Set")
                {
                    ResizeHierarchyDown("Set", false);
                }
                else if (attachedTo.transform.parent.name == "While")
                {
                    if (gameObject.name != "Equal")
                    {
                        ResizeHierarchyDown("While", false);
                    }
                    else
                    {
                        attachedTo.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(58.1f, 15f);
                        attachedTo.GetComponent<Collider2D>().enabled = true;
                    }
                }
            }


            Dropable = false;
            attachedTo = null;
        }

        exitedTrigger = false;
        Draging = false;

    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position += new Vector3(eventData.delta.x, eventData.delta.y);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "trashcan")
        {
            TrashCan.GetComponent<Image>().color = new Color(0,0,0,255);
            canDelete = true;
        }
        if (haveMoved && other.name != "Content")
        {
            if (check(other.name) && Draging)
            {
                if (Other != null)
                {

                }
                else
                {
                    if (CheckIfCollidingWithTextInput(other))
                    {
                        other.GetComponentInChildren<Image>().color = emptySpotHighlighted;
                    }
                    else
                    {
                        other.GetComponent<Image>().color = emptySpotHighlighted;
                    }

                    enteredTrigger = true;
                    Dropable = true;
                    Other = other;
                }
            }
        }
        if (other.name == "Content" && delete_block)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (canDelete == true)
        {
            TrashCan.GetComponent<Image>().color = trashcanDefault;
            canDelete = false;
        }


        if (other == Other && Draging)
        {
            if (other.name != "left_inp" && other.name != "right_inp" && other.name != "input_set")
            {
                Other.GetComponent<Image>().color = emptySpotDefault;
            }
            else
            {
                foreach (Transform eachChild in Other.transform)
                {
                    if (eachChild.name.Contains("InputField"))
                    {
                        eachChild.GetComponentInChildren<Image>().color = textInputColor;
                    }
                }
            }

            exitedTrigger = true;
            Dropable = false;
            enteredTrigger = false;
            Other = null;
        }
    }


    bool check(string other_name)
    {
        if (this.name == "If" && other_name == "Empty_spot_body" || this.name == "If" && other_name == "Empty_spot" || this.name == "If" && other_name == "Empty_spot_else")
        {
            return true;
        }
        else if (this.name == "Less" && other_name == "Empty_spot_if")
        {
            return true;
        }
        else if (this.name == "move" && other_name == "Empty_spot_body" || this.name == "move" && other_name == "Empty_spot" || this.name == "move" && other_name == "Empty_spot_else")
        {
            return true;
        }
        else if (this.name == "If_else" && other_name == "Empty_spot_body" || this.name == "If_else" && other_name == "Empty_spot" || this.name == "If_else" && other_name == "Empty_spot_else")
        {
            return true;
        }
        else if (this.name == "Var" && other_name == "left_inp" || this.name == "Var" && other_name == "right_inp" || this.name == "Var" && other_name == "input_set")
        {
            return true;
        }
        else if (this.name == "While" && other_name == "Empty_spot_body" || this.name == "While" && other_name == "Empty_spot_else" || this.name == "While" && other_name == "Empty_spot")
        {
            return true;
        }
        else if (this.name == "Equal" && other_name == "Empty_spot_if" || this.name == "Equal" && other_name == "right_inp" || this.name == "Equal" && other_name == "left_inp" || this.name == "Equal" && other_name == "Empty_spot_while")
        {
            return true;
        }
        else if (this.name == "Less" && other_name == "Empty_spot_if" || this.name == "Less" && other_name == "right_inp" || this.name == "Less" && other_name == "left_inp" || this.name == "Less" && other_name == "Empty_spot_while")
        {
            return true;
        }
        else if (this.name == "Greater" && other_name == "Empty_spot_if" || this.name == "Greater" && other_name == "right_inp" || this.name == "Greater" && other_name == "left_inp" || this.name == "Greater" && other_name == "Empty_spot_while")
        {
            return true;
        }
        else if (this.name == "Minus" && other_name == "input_set" || this.name == "Minus" && other_name == "right_inp" || this.name == "Minus" && other_name == "left_inp")
        {
            return true;
        }
        else if (this.name == "Set" && other_name == "Empty_spot_else" || this.name == "Set" && other_name == "Empty_spot_body" || this.name == "Set" && other_name == "Empty_spot")
        {
            return true;
        }
        else if (this.name == "Create_var" && other_name == "Empty_spot_else" || this.name == "Create_var" && other_name == "Empty_spot_body" || this.name == "Create_var" && other_name == "Empty_spot")
        {
            return true;
        }
        else if (this.name == "Var_distance" && other_name == "left_inp" || this.name == "Var_distance" && other_name == "right_inp")
        {
            return true;
        }
        else if (this.name == "wait" && other_name == "Empty_spot_body" || this.name == "wait" && other_name == "Empty_spot" || this.name == "wait" && other_name == "Empty_spot_else")
        {
            return true;
        }
        else if (this.name == "rotate" && other_name == "Empty_spot_body" || this.name == "rotate" && other_name == "Empty_spot" || this.name == "rotate" && other_name == "Empty_spot_else")
        {
            return true;
        }
        else if (this.name == "shoot" && other_name == "Empty_spot_body" || this.name == "shoot" && other_name == "Empty_spot" || this.name == "shoot" && other_name == "Empty_spot_else")
        {
            return true;
        }
        else if (this.name == "stop" && other_name == "Empty_spot_body" || this.name == "stop" && other_name == "Empty_spot" || this.name == "stopF" && other_name == "Empty_spot_else")
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    void SetTrueActiveState(GameObject gameObject, bool state) {
        try
        {
            gameObject.GetComponent<InputState>().ChangeRealActiveState(state);

        }
        catch {

          
        }
    }
}