using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileBlock : MonoBehaviour
{
    public GameObject left;
    public GameObject upperLeft;
    public GameObject bottom;

    public GameObject empty_spot_while;
    public GameObject current_empty_spot_body;
    public List<GameObject> emptySpots_body;
    public GameObject Empty_Spot_prefab;

    void Start()
    {
        emptySpots_body.Add(current_empty_spot_body);
    }
    public void removeEmptySpot(GameObject remove)
    {
        if (remove != current_empty_spot_body && remove.name != "Empty_spot_while")
        {
            emptySpots_body.Remove(remove);
            GameObject.Destroy(remove);
        }
    }

    public void resizing()
    {
        RectTransform temp = current_empty_spot_body.GetComponent<RectTransform>();
        Vector3 pos = current_empty_spot_body.transform.position;
        pos.y -= ((temp.rect.height) / 2) + bottom.GetComponent<RectTransform>().sizeDelta.y / 2;
        pos.x = bottom.transform.position.x;
        bottom.transform.position = pos;


        Vector3 asd;
        if (emptySpots_body.Count == 1)
        {
            asd = upperLeft.transform.position;
            asd.y -= (upperLeft.GetComponent<RectTransform>().sizeDelta.y * upperLeft.transform.localScale.y) / 2;
            asd.y -= (current_empty_spot_body.GetComponent<RectTransform>().sizeDelta.y * current_empty_spot_body.gameObject.transform.localScale.y) / 2;
            asd.x = (left.transform.position.x + left.GetComponent<RectTransform>().sizeDelta.x / 2) + current_empty_spot_body.GetComponent<RectTransform>().sizeDelta.x / 2;
            current_empty_spot_body.transform.position = asd;
        }
        else
        {
            asd = upperLeft.transform.position;
            asd.y -= (upperLeft.GetComponent<RectTransform>().sizeDelta.y * upperLeft.transform.localScale.y) / 2;
            asd.y -= (emptySpots_body[0].GetComponent<RectTransform>().sizeDelta.y * emptySpots_body[0].gameObject.transform.localScale.y) / 2;
                asd.x = left.transform.position.x + (emptySpots_body[0].GetComponent<RectTransform>().sizeDelta.x / 2) + left.GetComponent<RectTransform>().sizeDelta.x / 2;//+ emptySpots_body[i - 1].GetComponent<RectTransform>().sizeDelta.x / 2;
            emptySpots_body[0].transform.position = asd;

            for (int i = 1; i < emptySpots_body.Count; i++)
            {
                asd = emptySpots_body[i - 1].transform.position;
                asd.y -= (emptySpots_body[i - 1].GetComponent<RectTransform>().sizeDelta.y * emptySpots_body[i - 1].transform.localScale.y) / 2;
                asd.y -= (emptySpots_body[i].GetComponent<RectTransform>().sizeDelta.y * emptySpots_body[i].gameObject.transform.localScale.y) / 2;
                asd.x = left.transform.position.x + (emptySpots_body[i].GetComponent<RectTransform>().sizeDelta.x / 2) + left.GetComponent<RectTransform>().sizeDelta.x / 2;//+ emptySpots_body[i - 1].GetComponent<RectTransform>().sizeDelta.x / 2;
                emptySpots_body[i].transform.position = asd;

            }
        }


        left.GetComponent<RectTransform>().sizeDelta = new Vector2(left.GetComponent<RectTransform>().sizeDelta.x, Mathf.Abs(bottom.transform.localPosition.y - upperLeft.transform.localPosition.y) - upperLeft.GetComponent<RectTransform>().sizeDelta.y / 2); // REIKIA PATAISYTI MATHF
        left.transform.position = new Vector3(left.transform.position.x, upperLeft.transform.position.y - bottom.GetComponent<RectTransform>().sizeDelta.y - (left.GetComponent<RectTransform>().sizeDelta.y / 2) + 1);

        empty_spot_while.transform.position = new Vector2(upperLeft.transform.position.x + (upperLeft.GetComponent<RectTransform>().sizeDelta.x / 2) + (empty_spot_while.GetComponent<RectTransform>().sizeDelta.x / 2) + 2, upperLeft.transform.position.y);
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
    public void resizeHeight()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, Mathf.Abs(upperLeft.transform.localPosition.y) + Mathf.Abs(bottom.transform.localPosition.y) + (upperLeft.GetComponent<RectTransform>().sizeDelta.y / 2) + bottom.GetComponent<RectTransform>().sizeDelta.y / 2); //+ upper.GetComponent<RectTransform>().sizeDelta.y);

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