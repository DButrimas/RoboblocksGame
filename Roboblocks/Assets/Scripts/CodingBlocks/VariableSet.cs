using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableSet : MonoBehaviour
{

    public TMPro.TMP_Dropdown dropdown;

    public VariablesManager manager;

    public void SetVar(string val)
    {
        string key = dropdown.options[dropdown.value].text;
        manager.AddVariable(key,int.Parse(val));
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
