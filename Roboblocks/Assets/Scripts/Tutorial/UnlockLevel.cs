using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    public string UnlockedLevel;
    // Start is called before the first frame update
    void Start()
    {
        LevelsUnlocker.WriteString(UnlockedLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
