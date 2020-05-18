using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfElseBlock : MonoBehaviour
{
    public GameObject upper;
    public GameObject middle;
    public GameObject upperLeft;
    public GameObject bottomLeft;
    public GameObject bottom;

    public GameObject else_bottom;
    public GameObject else_left;
    public GameObject empty_spot_else;
    public GameObject current_empty_spot_else;
    public List<GameObject> emptySpots_else;


    public GameObject empty_spot_if;
    public GameObject current_empty_spot_body;
    public List<GameObject> emptySpots_body;
    public GameObject Empty_Spot_prefab;

  

    void Start()
    {
        emptySpots_body.Add(current_empty_spot_body);
        emptySpots_else.Add(current_empty_spot_else);
    }
    public void removeEmptySpot(GameObject remove)
    {
        if (remove != current_empty_spot_body && remove.name != "Empty_spot_if")
        {
            emptySpots_body.Remove(remove);
            GameObject.Destroy(remove);
        }
    }
    public void removeEmptySpotElse(GameObject remove)
    {
        if (remove != current_empty_spot_else && remove.name != "Empty_spot_if")
        {
            emptySpots_else.Remove(remove);
            GameObject.Destroy(remove);
        }
    }

    public void resizing()
    {
        RectTransform temp = current_empty_spot_body.GetComponent<RectTransform>();
        Vector3 pos = current_empty_spot_body.transform.position;
        pos.y -= ((temp.rect.height) / 2) + bottom.GetComponent<RectTransform>().sizeDelta.y / 2;
        pos.x = middle.transform.position.x;
        bottom.transform.position = pos;

        Vector3 asd;
        if (emptySpots_body.Count == 1)
        {
            asd = middle.transform.position;
            asd.y -= (middle.GetComponent<RectTransform>().sizeDelta.y * middle.transform.localScale.y) / 2;
            asd.y -= (current_empty_spot_body.GetComponent<RectTransform>().sizeDelta.y * current_empty_spot_body.gameObject.transform.localScale.y) / 2;
            asd.x = (bottomLeft.transform.position.x + bottomLeft.GetComponent<RectTransform>().sizeDelta.x / 2) + current_empty_spot_body.GetComponent<RectTransform>().sizeDelta.x / 2;
            current_empty_spot_body.transform.position = asd;
        }
        else
        {
            asd = middle.transform.position;
            asd.y -= (middle.GetComponent<RectTransform>().sizeDelta.y * middle.transform.localScale.y) / 2;
            asd.y -= (emptySpots_body[0].GetComponent<RectTransform>().sizeDelta.y * emptySpots_body[0].gameObject.transform.localScale.y) / 2;
            asd.x = bottomLeft.transform.position.x + (emptySpots_body[0].GetComponent<RectTransform>().sizeDelta.x / 2) + bottomLeft.GetComponent<RectTransform>().sizeDelta.x / 2;
            emptySpots_body[0].transform.position = asd;

            for (int i = 1; i < emptySpots_body.Count; i++)
            {
                asd = emptySpots_body[i - 1].transform.position;
                asd.y -= (emptySpots_body[i - 1].GetComponent<RectTransform>().sizeDelta.y * emptySpots_body[i - 1].transform.localScale.y) / 2;
                asd.y -= (emptySpots_body[i].GetComponent<RectTransform>().sizeDelta.y * emptySpots_body[i].gameObject.transform.localScale.y) / 2;
                asd.x = bottomLeft.transform.position.x + (emptySpots_body[i].GetComponent<RectTransform>().sizeDelta.x / 2) + bottomLeft.GetComponent<RectTransform>().sizeDelta.x / 2;
                emptySpots_body[i].transform.position = asd;

            }
        }


        bottomLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(bottomLeft.GetComponent<RectTransform>().sizeDelta.x, Mathf.Abs(bottom.transform.localPosition.y - middle.transform.localPosition.y));
        bottomLeft.transform.position = new Vector3(bottomLeft.transform.position.x, middle.transform.position.y - bottomLeft.GetComponent<RectTransform>().sizeDelta.y / 2);

        asd = upper.transform.position;
        asd.y -= (upper.GetComponent<RectTransform>().sizeDelta.y * upper.transform.localScale.y) / 2;
        asd.y -= (empty_spot_if.GetComponent<RectTransform>().sizeDelta.y * empty_spot_if.gameObject.transform.localScale.y) / 2;
        asd.x = (upperLeft.transform.position.x + upperLeft.GetComponent<RectTransform>().sizeDelta.x / 2) + empty_spot_if.GetComponent<RectTransform>().sizeDelta.x / 2;
        empty_spot_if.transform.position = asd;

        asd = empty_spot_if.transform.position;
        asd.y -= (empty_spot_if.GetComponent<RectTransform>().sizeDelta.y * empty_spot_if.transform.localScale.y) / 2;
        asd.y -= (middle.GetComponent<RectTransform>().sizeDelta.y * middle.gameObject.transform.localScale.y) / 2;
        asd.x = upper.transform.position.x;
        middle.transform.position = asd;



        upperLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(upperLeft.GetComponent<RectTransform>().sizeDelta.x, empty_spot_if.GetComponent<RectTransform>().sizeDelta.y + 6);
        upperLeft.transform.position = new Vector3(bottomLeft.transform.position.x + bottomLeft.GetComponent<RectTransform>().sizeDelta.x / 2, upper.transform.position.y - upperLeft.GetComponent<RectTransform>().sizeDelta.y / 2);

        else_left.GetComponent<RectTransform>().sizeDelta = new Vector2(else_left.GetComponent<RectTransform>().sizeDelta.x, Mathf.Abs(else_bottom.transform.localPosition.y - bottom.transform.localPosition.y)); // REIKIA PATAISYTI MATHF
        else_left.transform.position = new Vector3(else_left.transform.position.x, bottom.transform.position.y - else_left.GetComponent<RectTransform>().sizeDelta.y / 2); // gal dar atimt puse bottomo jei bus negerai


        if (emptySpots_else.Count == 1)
        {
            asd = bottom.transform.position;
            asd.y -= (bottom.GetComponent<RectTransform>().sizeDelta.y * bottom.transform.localScale.y) / 2;
            asd.y -= (current_empty_spot_else.GetComponent<RectTransform>().sizeDelta.y * current_empty_spot_else.gameObject.transform.localScale.y) / 2;
            asd.x = (else_left.transform.position.x + else_left.GetComponent<RectTransform>().sizeDelta.x / 2) + current_empty_spot_else.GetComponent<RectTransform>().sizeDelta.x / 2;
            current_empty_spot_else.transform.position = asd;
        }
        else
        {
            asd = bottom.transform.position;
            asd.y -= (bottom.GetComponent<RectTransform>().sizeDelta.y * bottom.transform.localScale.y) / 2;
            asd.y -= (emptySpots_else[0].GetComponent<RectTransform>().sizeDelta.y * emptySpots_else[0].gameObject.transform.localScale.y) / 2;
            asd.x = else_left.transform.position.x + (emptySpots_else[0].GetComponent<RectTransform>().sizeDelta.x / 2) + else_left.GetComponent<RectTransform>().sizeDelta.x / 2;//+ emptySpots_body[i - 1].GetComponent<RectTransform>().sizeDelta.x / 2;
            emptySpots_else[0].transform.position = asd;

            for (int i = 1; i < emptySpots_else.Count; i++)
            {
                asd = emptySpots_else[i - 1].transform.position;
                asd.y -= (emptySpots_else[i - 1].GetComponent<RectTransform>().sizeDelta.y * emptySpots_else[i - 1].transform.localScale.y) / 2;
                asd.y -= (emptySpots_else[i].GetComponent<RectTransform>().sizeDelta.y * emptySpots_else[i].gameObject.transform.localScale.y) / 2;
                asd.y -= 4;
                asd.x = else_left.transform.position.x + (emptySpots_else[i].GetComponent<RectTransform>().sizeDelta.x / 2) + else_left.GetComponent<RectTransform>().sizeDelta.x / 2;//+ emptySpots_body[i - 1].GetComponent<RectTransform>().sizeDelta.x / 2;
                emptySpots_else[i].transform.position = asd;

            }
        }


        else_bottom.transform.position = new Vector2(else_bottom.transform.position.x, current_empty_spot_else.transform.position.y - (else_bottom.GetComponent<RectTransform>().sizeDelta.y / 2) - current_empty_spot_else.GetComponent<RectTransform>().sizeDelta.y / 2);
    }

        void Update()
    {
        resizing();
    }

    public void createNewEmptySpot()
    {

        current_empty_spot_body = Instantiate(Empty_Spot_prefab, new Vector3(current_empty_spot_body.transform.position.x, current_empty_spot_body.transform.position.y - current_empty_spot_body.GetComponent<RectTransform>().sizeDelta.y - 5), Quaternion.identity, current_empty_spot_body.transform.parent);
        emptySpots_body.Add(current_empty_spot_body);
        current_empty_spot_body.name = "Empty_spot_body";
        resizing();
        resizeHeight();
    }
    public void createNewEmptySpotElse()
    {


        current_empty_spot_else = Instantiate(Empty_Spot_prefab, new Vector3(current_empty_spot_else.transform.position.x, current_empty_spot_else.transform.position.y - current_empty_spot_else.GetComponent<RectTransform>().sizeDelta.y - 5), Quaternion.identity, current_empty_spot_else.transform.parent);
        emptySpots_else.Add(current_empty_spot_else);
        current_empty_spot_else.name = "Empty_spot_else";
        resizing();
        resizeHeight();
    }


    public void resizeHeight()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, Mathf.Abs(upper.transform.localPosition.y) + Mathf.Abs(else_bottom.transform.localPosition.y) + upper.GetComponent<RectTransform>().sizeDelta.y);

    }
    public void resizeHeight(float sizeToRemove)
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y - sizeToRemove);

    }
    public void resizeHeightAdd(float sizeToAdd)
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y + sizeToAdd);

    }
}
