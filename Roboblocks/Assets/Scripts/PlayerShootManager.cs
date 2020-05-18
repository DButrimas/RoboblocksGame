using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet_prefab;
    public GameObject Bullet_spawn;

    private Vector3 direction;

    public float speed = 45f;

    public GameObject target;

    public bool shoot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.transform.position - Bullet_spawn.transform.position;
        if (shoot == true)
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(Bullet_prefab, Bullet_spawn.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * speed, ForceMode.VelocityChange);
        shoot = false;
    }
}
