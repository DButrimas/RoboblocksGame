using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Tank"))
        {
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<TankMovementManager>().health -= 1;
            gameObject.name = "Bullet1";
        }
    }
}
