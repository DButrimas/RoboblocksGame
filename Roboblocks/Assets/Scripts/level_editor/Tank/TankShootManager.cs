using Assets.Scripts.Online_Level_Play;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShootManager : MonoBehaviour
{
    public bool movement;
    public GameObject pipe;
    public GameObject cabin;
    public float speed = 2f;
    public float shootSpeed = 6f;

    public float targetTime;
    public float bullet_speed222;

    public GameObject Bullet_spawn;
    public GameObject Bullet_prefab;

    private Vector3 direction;

    public bool canShoot = false;


    public GameObject target;

    void Start()
    {
        bullet_speed222 = 25;
        if (shootSpeed != 0f)
        {
            targetTime = 60 / shootSpeed;

        }
        else
        {
            targetTime = 1;
        }
    }

    void Update()
    {
        direction = target.transform.position - Bullet_spawn.transform.position;


        if (canShoot)
        {
            if (movement)
            {
                targetTime -= Time.deltaTime;

                if (targetTime <= 0.0f)
                {
                    timerEnded();
                }
            }
        }
    }


    void timerEnded()
    {
        GameObject bullet = Instantiate(Bullet_prefab, Bullet_spawn.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * bullet_speed222,ForceMode.VelocityChange);

        if (shootSpeed != 0f)
        {
            targetTime = 60 / shootSpeed;

        }
        else
        {
            targetTime = 1;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (movement && other.name.Contains("robot"))
        {

            canShoot = true;

            Vector3 D = other.transform.position - cabin.transform.position;

            Quaternion rot = Quaternion.Slerp(cabin.transform.rotation, Quaternion.LookRotation(D), speed * Time.deltaTime);

            cabin.transform.rotation = rot;
            cabin.transform.eulerAngles = new Vector3(0, cabin.transform.eulerAngles.y, 0);



            Vector3 D2 = other.transform.position - pipe.transform.position;
            Quaternion rot2 = Quaternion.Slerp(pipe.transform.localRotation, Quaternion.LookRotation(D2), speed * Time.deltaTime);
            pipe.transform.localRotation = rot2;
            pipe.transform.localEulerAngles = new Vector3(pipe.transform.localEulerAngles.x, 0, 0);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (movement && other.name.Contains("robot"))
        {
            canShoot = false;

        }
    }
}
