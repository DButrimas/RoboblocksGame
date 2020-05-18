using Assets.Scripts.Online_Level_Play;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovementManager : MonoBehaviour
{
    public bool movement;
    public GameObject pipe;
    public GameObject cabin;
    public float speed = 2f;
    public float movementSpeed = 0.1f;

    public GameObject sphere;

    public int current = 0;
    public int last = 0;
    bool reverse;
    public float health = 2;

    void Start()
    {

    }

    void Update()
    {
        if (movement == true)
        {
            followWayPoints();
        }
        if (health <= 0)
        {
            pipe.GetComponent<Rigidbody>().isKinematic = false;

            Destroy(sphere.GetComponent<TankShootManager>());
            Destroy(gameObject.GetComponent<TankMovementManager>());
        }


    }


    private void followWayPoints()
    {

        if (current <= TankPropsStatic.waypoints.Count)
        {
            gameObject.transform.parent.position = Vector3.MoveTowards(gameObject.transform.parent.position, new Vector3(TankPropsStatic.waypoints[current].posX, gameObject.transform.parent.position.y, TankPropsStatic.waypoints[current].posZ), movementSpeed * Time.deltaTime);

            Vector3 D2 = new Vector3(TankPropsStatic.waypoints[current].posX, TankPropsStatic.waypoints[current].posY, TankPropsStatic.waypoints[current].posZ) - gameObject.transform.parent.position;
            Quaternion rot2 = Quaternion.Slerp(gameObject.transform.parent.rotation, Quaternion.LookRotation(D2), speed * Time.deltaTime);
            gameObject.transform.parent.rotation = rot2;
            gameObject.transform.parent.eulerAngles = new Vector3(0, gameObject.transform.parent.eulerAngles.y, 0);

        }

    }
    private bool test;
    private void OnTriggerExit(Collider other)
    {
        test = true;
    }

    public Collider lastCol;

    private void OnTriggerEnter(Collider other)
    {

            //if (other.name.Contains("Bullet"))
            //{
            //    health -= 1;
            //    other.name = "Bullet1";
            //}


        if (lastCol != other && other.name.Contains("waypoint"))
        {
            lastCol = other;

            if (current == 0 && reverse == true && other.name.Contains("waypoint"))
            {
                reverse = false;
                current += 1;
                return;
            }
            if (other.name.Contains("waypoint") && current == TankPropsStatic.waypoints.Count - 1)
            {
                last = current;
                reverse = true;
                current -= 1;
                return;

            }
            if (other.name.Contains("waypoint") && current != TankPropsStatic.waypoints.Count - 1 && reverse == true)
            {
                current -= 1;
                return;

            }
            if (other.name.Contains("waypoint") && current < TankPropsStatic.waypoints.Count - 1 && reverse == false)
            {
                current += 1;
                return;

            }
        }


    }
}
