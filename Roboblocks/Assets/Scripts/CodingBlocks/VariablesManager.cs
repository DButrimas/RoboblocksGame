using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class VariablesManager : MonoBehaviour
{
    public Dictionary<string, int> variables = new Dictionary<string, int>();

    [SerializeField]
    public List<GameObject> dropdown_managers = new List<GameObject>();


    public void AddVarWithoutValue(string key)
    {
        if (variables.ContainsKey(key))
        {
            return;
        }
        variables.Add(key,0);

        foreach (var manager in dropdown_managers)
        {
            manager.GetComponent<DropdownManager>().update_values();
        }
    }
    public void AddVariable(string key, int val)
    {
        variables.Add(key, val);
    }
    public void RemoveVariable(string key)
    {
        variables.Remove(key);
    }
    public List<string> GetVariableKeys()
    {
        return variables.Keys.ToList();
    }
    public void ChangeVariable(string key, int newVal)
    {
        variables[key] = newVal;
    }





}
