using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown;

    public VariablesManager manager;

    public void update_values()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(manager.GetVariableKeys());
        dropdown.RefreshShownValue();
    }

    void Start()
    {
        manager = GameObject.Find("var_list").GetComponent<VariablesManager>();
    }

    void Update()
    {

    }
}
