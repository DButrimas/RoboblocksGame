using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour
{
    public bool RealActiveState;

    public void ChangeRealActiveState(bool state) {
        RealActiveState = state;
    }
    void Start()
    {
        RealActiveState = true;
    }

    void Update()
    {
        
    }
}
