using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentForTestingDebug : MonoBehaviour
{
  public  float Place;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LaunchedState.IsLoaunched)
        {
            transform.Translate(0, 1f * Time.deltaTime, 0);
            Place = transform.position.y;
        }
    }
}
