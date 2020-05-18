using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualBlock : MonoBehaviour
{
    public GameObject left;
    public GameObject middle;
    public GameObject right;

    public GameObject left_input;
    public GameObject right_input;

    void Start()
    {
        
    }

    void Update()
    {
        left_input.transform.position = new Vector2(left.transform.position.x + (left.GetComponent<RectTransform>().sizeDelta.x / 2) + left_input.GetComponent<RectTransform>().sizeDelta.x / 2, left_input.transform.position.y);

        middle.transform.position = new Vector2(left_input.transform.position.x + (left_input.GetComponent<RectTransform>().sizeDelta.x / 2) + middle.GetComponent<RectTransform>().sizeDelta.x / 2, middle.transform.position.y);

        right_input.transform.position = new Vector2(middle.transform.position.x + (middle.GetComponent<RectTransform>().sizeDelta.x / 2) + right_input.GetComponent<RectTransform>().sizeDelta.x / 2, right_input.transform.position.y);

        right.transform.position = new Vector2(right_input.transform.position.x + (right_input.GetComponent<RectTransform>().sizeDelta.x / 2) + right.GetComponent<RectTransform>().sizeDelta.x / 2, right.transform.position.y);


    }
}
