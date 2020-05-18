using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodePart : MonoBehaviour
{
    public string PartOfCode = "";
    public bool IsIF;
    public bool IsWhile;
    private float left;
    private float right;
    private string Logictype;
    private int _direction = 0;
    private float _speed;

    public bool FormatLogic(GameObject gameObject)
    {
        LeftIsSet = false;
        RightIsSet = false;
        SetLeftRight(gameObject);
        if (Logictype.Equals("Equal"))
        {
            return left == right;
        }
        if (Logictype.Equals("Less"))
        {
            return left < right;
        }
        if (Logictype.Equals("Greater"))
        {
            return left > right;
        }



        return false;
    }
    bool rightHaveSomthing;
    private void SetRight(GameObject parent)
    {
        if (RightIsSet)
        {
            return;
        }
        try
        {
            if (parent.name.Equals("Var_distance"))
            {
                right = LaunchedState.DistanceFrontToObject;
                RightIsSet = true;
                bool rightHaveSomthing =false;

            }
            else if (parent.name.Equals("Dropdown"))
            {
                string text = parent.GetComponent<TMP_Dropdown>().captionText.text.ToString();
                foreach (var item in LaunchedState.Variables)
                {
                    if (item.Name.Equals(text))
                    {
                        right = item.Value;
                    }

                }
                RightIsSet = true;
                 rightHaveSomthing = false;
            }
            else if(!rightHaveSomthing)
            {
                right = float.Parse(parent.GetComponent<TMP_InputField>().text);
                RightIsSet = true;
            }

        }
        catch
        {

        }


        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.name.Equals("Var") || parent.transform.GetChild(i).gameObject.name.Equals("Var_distance"))
            {
                 rightHaveSomthing = true;
            } 
        }
       
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject children = parent.transform.GetChild(i).gameObject;
            SetRight(children);
        }
    }
    bool leftHaveSomthing = false;
    private void SetLeft(GameObject parent)
    {
        if (RightIsSet)
        {
            return;
        }
        try
        {
            if (parent.name.Equals("Var_distance"))
            {
                left = LaunchedState.DistanceFrontToObject;
                LeftIsSet = true; leftHaveSomthing = false;
            }
            else if (parent.name.Equals("Dropdown"))
            {
                string text = parent.GetComponent<TMP_Dropdown>().captionText.text.ToString();
                foreach (var item in LaunchedState.Variables)
                {
                    if (item.Name.Equals(text))
                    {
                        left = item.Value;
                    }
                }
                LeftIsSet = true;
                leftHaveSomthing = false;
            }
            else if (!leftHaveSomthing)
            {
                left = float.Parse(parent.GetComponent<TMP_InputField>().text);
                LeftIsSet = true;
            }

        }
        catch
        {
            
        }
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.name.Equals("Var") || parent.transform.GetChild(i).gameObject.name.Equals("Var_distance"))
            {
                leftHaveSomthing = true;
            }
        }
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject children = parent.transform.GetChild(i).gameObject;
            SetLeft(children);
        }
    }
    bool LeftIsSet;
    bool RightIsSet;

    private void SetLeftRight(GameObject parent)
    {

        if (LeftIsSet && RightIsSet)
        {
            return;
        }
        if (parent.name.Equals("Equal"))
        {
            Logictype = "Equal";
        }
        if (parent.name.Equals("Less"))
        {
            Logictype = "Less";
        }
        if (parent.name.Equals("Greater"))
        {
            Logictype = "Greater";
        }
        if (parent.name.Equals("Minus") )
        {
            Logictype = "Minus";
        }

        if (parent.name.Equals("left_inp"))
        {
            SetLeft(parent);
        }
        else if (parent.name.Equals("right_inp"))
        {
            SetRight(parent);
        }
        else
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                GameObject children = parent.transform.GetChild(i).gameObject;
                SetLeftRight(children);
            }
        }

    }


    public void Movement(GameObject gameObject)
    {

        SetDirectionAndSpeed(gameObject);
        switch (_direction)
        {
            case 0://"forward":
                LaunchedState.x = 1;
                LaunchedState.y = 0;
                LaunchedState.z = 0;
                break;
            case 1://"backward":
                LaunchedState.x = -1;
                LaunchedState.y = 0;
                LaunchedState.z = 0;
                break;
            case 2://"left":
                LaunchedState.x = 0;
                LaunchedState.y = 0;
                LaunchedState.z = _speed * -1;
                break;
            case 3:// "right":
                LaunchedState.x = 0;
                LaunchedState.y = 0;
                LaunchedState.z = _speed;
                break;
        }

    }
    public void Rotate(GameObject gameObject)
    {

        SetDirectionAndSpeed(gameObject);
        try
        {
            LaunchedState.Rotation = GameObject.Find("robot_arduino_1").transform.rotation.eulerAngles.y + _speed;
        }
        catch {

            LaunchedState.Rotation = GameObject.Find("robot_arduino_1(Clone)").transform.rotation.eulerAngles.y + _speed;
        }


    }
    public float GetValue(GameObject gameObject) {
        LeftIsSet = false;
        RightIsSet = false;
        SetLeftRight(gameObject);

        if (Logictype.Equals("Minus"))
        {
            return left - right;
        }
        return -1;
      
    }
    private void SetDirectionAndSpeed(GameObject parent)
    {
        depth++;
        if (parent.name.Equals("Dropdown"))
        {
            SetDirection(parent);
        }
        else if (parent.name.Equals("InputField_right"))
        {
            SetSpeed(parent);
        }
        else
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                GameObject children = parent.transform.GetChild(i).gameObject;
                SetDirectionAndSpeed(children);
            }
        }
    }
    int depth = 0;
    private void SetDirection(GameObject parent)
    {
        depth++;

        try
        {
            _direction = parent.GetComponent<TMP_Dropdown>().value;

        }
        catch
        {

        }
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject children = parent.transform.GetChild(i).gameObject;
            SetDirection(children);
        }

    }
    private void SetSpeed(GameObject parent)
    {

        try
        {
            _speed = float.Parse(parent.GetComponent<TMP_InputField>().text);
        }
        catch
        {
        }
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject children = parent.transform.GetChild(i).gameObject;
            SetSpeed(children);
        }

    }

}