using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginEndBlock : MonoBehaviour
{
    public GameObject bottom;
    public GameObject left;
    public GameObject current_empty_spot;
    public GameObject upper;
    public List<GameObject> Empty_spots;
    public GameObject prev_empty_spot;

    public GameObject Empty_Spot_prefab;

    public bool createTest;


    public void removeEmptySpot(GameObject remove)
    {
        if (remove != current_empty_spot)
        {
            Empty_spots.Remove(remove);
            GameObject.Destroy(remove);
        }
    }
    public void setCreate()
    {
        createTest = true;
    }
    void Start()
    {
        Empty_spots.Add(current_empty_spot);
    }

    void Update()
    {
        if (createTest)
        {
            createNewEmptySpot();
        }

        RectTransform temp = current_empty_spot.GetComponent<RectTransform>();
        Vector3 pos = current_empty_spot.transform.position;
        pos.y -= (temp.rect.height / 2) + 7;
        pos.x = upper.transform.position.x;
        bottom.transform.position = pos;

        Vector3 asd;
        if (Empty_spots.Count == 1)
        {
            asd = upper.transform.position;
            asd.y -= (upper.GetComponent<RectTransform>().sizeDelta.y * upper.transform.localScale.y) / 2;
            asd.y -= (current_empty_spot.GetComponent<RectTransform>().sizeDelta.y * current_empty_spot.gameObject.transform.localScale.y) / 2;
            asd.x = left.transform.position.x + (left.GetComponent<RectTransform>().sizeDelta.x / 2) + current_empty_spot.GetComponent<RectTransform>().sizeDelta.x / 2;
            current_empty_spot.transform.position = asd;
        }
        else
        {
            asd = upper.transform.position;
            asd.y -= (upper.GetComponent<RectTransform>().sizeDelta.y * upper.transform.localScale.y) / 2;
            asd.y -= (Empty_spots[0].GetComponent<RectTransform>().sizeDelta.y * Empty_spots[0].gameObject.transform.localScale.y) / 2;
            asd.x = left.transform.position.x + (Empty_spots[0].GetComponent<RectTransform>().sizeDelta.x / 2) + left.GetComponent<RectTransform>().sizeDelta.x / 2;
            Empty_spots[0].transform.position = asd;

            for (int i = 1; i < Empty_spots.Count; i++)
            {
                asd = Empty_spots[i-1].transform.position;
                asd.y -= (Empty_spots[i - 1].GetComponent<RectTransform>().sizeDelta.y * Empty_spots[i - 1].transform.localScale.y) / 2;
                asd.y -= (Empty_spots[i].GetComponent<RectTransform>().sizeDelta.y * Empty_spots[i].gameObject.transform.localScale.y) / 2;
                asd.x = left.transform.position.x + (Empty_spots[i].GetComponent<RectTransform>().sizeDelta.x / 2) + left.GetComponent<RectTransform>().sizeDelta.x / 2;
                Empty_spots[i].transform.position = asd;

            }

        }


        left.GetComponent<RectTransform>().sizeDelta = new Vector2(left.GetComponent<RectTransform>().sizeDelta.x, Mathf.Abs(upper.transform.localPosition.y) + Mathf.Abs(bottom.transform.localPosition.y));
        left.transform.position = new Vector3(left.transform.position.x, upper.transform.position.y - (upper.GetComponent<RectTransform>().sizeDelta.y / 2) - (left.GetComponent<RectTransform>().sizeDelta.y / 2) + 2);
    }

    public void createNewEmptySpot()
    {

        current_empty_spot = Instantiate(Empty_Spot_prefab, new Vector3(left.transform.position.x + (left.GetComponent<RectTransform>().sizeDelta.x / 2) + current_empty_spot.GetComponent<RectTransform>().sizeDelta.x / 2, (current_empty_spot.transform.position.y - current_empty_spot.GetComponent<RectTransform>().sizeDelta.y) - 5), Quaternion.identity,current_empty_spot.transform.parent);
        current_empty_spot.name = "Empty_spot";
        Empty_spots.Add(current_empty_spot);
        createTest = false;
    }
}
