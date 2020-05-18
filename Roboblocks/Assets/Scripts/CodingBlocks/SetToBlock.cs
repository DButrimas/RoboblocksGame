using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToBlock : MonoBehaviour
{
    public GameObject left;
    public GameObject middle;


    public GameObject dropdown;
    public GameObject right_input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dropdown.transform.position = new Vector2(left.transform.position.x + (left.GetComponent<RectTransform>().sizeDelta.x / 2) + dropdown.GetComponent<RectTransform>().sizeDelta.x / 2, dropdown.transform.position.y);

        middle.transform.position = new Vector2(dropdown.transform.position.x + (dropdown.GetComponent<RectTransform>().sizeDelta.x / 2) + middle.GetComponent<RectTransform>().sizeDelta.x / 2, middle.transform.position.y);

        right_input.transform.position = new Vector2(middle.transform.position.x + (middle.GetComponent<RectTransform>().sizeDelta.x / 2) + right_input.GetComponent<RectTransform>().sizeDelta.x / 2, right_input.transform.position.y);


    }
}
