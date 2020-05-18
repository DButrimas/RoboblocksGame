using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedStatic : MonoBehaviour
{
    public static GameObject selected;
    public bool changed;

    public static List<Level> levels = new List<Level>();

    public static Level selected_lvl;

    public static GameObject selected_lvl_parent_item;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
