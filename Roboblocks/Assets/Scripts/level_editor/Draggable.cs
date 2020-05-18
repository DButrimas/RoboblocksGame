using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool dragging;
    public GameObject dragable_prefab;
    public GameObject raycastObject;
    public bool test = false;
    public Material ghost;
    public Vector3 rayDir;
    public float height;
    public float step = 1f;




    void Start()
    {
        height = 0.0f;
    }

    public void raycast()
    {
 
    }


    void Update()
    {
        if (dragging)
        {

            if (test == false)
            {
                raycastObject = Instantiate(raycastObject, null);

                if (dragable_prefab.name.Contains("robot"))
                {
                    raycastObject.transform.position = new Vector3(GameObject.Find("Ground").transform.position.x, GameObject.Find("Ground").transform.position.y + 0.9f, GameObject.Find("Ground").transform.position.z);

                }
                else if (dragable_prefab.name.Contains("Wall"))
                {
                    raycastObject.transform.position = new Vector3(GameObject.Find("Ground").transform.position.x, GameObject.Find("Ground").transform.position.y + 1.5f, GameObject.Find("Ground").transform.position.z);

                }
                else if (dragable_prefab.name.Contains("ramp"))
                {
                    raycastObject.transform.position = new Vector3(GameObject.Find("Ground").transform.position.x, GameObject.Find("Ground").transform.position.y + 1.4f, GameObject.Find("Ground").transform.position.z);

                }
                else if (dragable_prefab.name.Contains("finish_line"))
                {
                    raycastObject.transform.position = new Vector3(GameObject.Find("Ground").transform.position.x, GameObject.Find("Ground").transform.position.y + 0.7f, GameObject.Find("Ground").transform.position.z);

                }
                else if (dragable_prefab.name.Contains("lamp"))
                {
                    raycastObject.transform.position = new Vector3(GameObject.Find("Ground").transform.position.x, GameObject.Find("Ground").transform.position.y + 0.7f, GameObject.Find("Ground").transform.position.z);

                }
                else if (dragable_prefab.name.Contains("door"))
                {
                    raycastObject.transform.position = new Vector3(GameObject.Find("Ground").transform.position.x, GameObject.Find("Ground").transform.position.y + 0.7f, GameObject.Find("Ground").transform.position.z);

                }
                else if (dragable_prefab.name.Contains("bridge"))
                {
                    raycastObject.transform.position = new Vector3(GameObject.Find("Ground").transform.position.x, GameObject.Find("Ground").transform.position.y + 0.7f, GameObject.Find("Ground").transform.position.z);

                }
                else if (dragable_prefab.name.Contains("tank") || dragable_prefab.name.Contains("Tank"))
                {
                    raycastObject.transform.position = new Vector3(GameObject.Find("Ground").transform.position.x, GameObject.Find("Ground").transform.position.y + 0.7f, GameObject.Find("Ground").transform.position.z);
                }
                raycastObject.tag = "ignore";
                raycastObject.GetComponent<Draggable>().enabled = false;

                raycastObject.GetComponent<MeshRenderer>().enabled = true;
                raycastObject.GetComponent<Renderer>().material = ghost;
                foreach (Transform child in raycastObject.transform)
                {
                    if (!child.name.Contains("wires") && !child.name.Contains("Point") && !child.name.Contains("Bullet_spawn") && !child.name.Contains("dir"))
                    {
                        child.GetComponent<MeshRenderer>().enabled = true;
                        child.GetComponent<Renderer>().material = ghost;
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }

                }

                test = true;
            }


            raycast();

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (dragable_prefab.name.Contains("robot"))
                {
                    raycastObject.transform.eulerAngles = new Vector3(raycastObject.transform.eulerAngles.x, raycastObject.transform.eulerAngles.y, raycastObject.transform.eulerAngles.z + 30);
                }
                else if (dragable_prefab.name.Contains("Wall"))
                {
                    raycastObject.transform.eulerAngles = new Vector3(raycastObject.transform.eulerAngles.x, raycastObject.transform.eulerAngles.y + 30, raycastObject.transform.eulerAngles.z);

                }
                else if (dragable_prefab.name.Contains("ramp"))
                {
                    raycastObject.transform.eulerAngles = new Vector3(raycastObject.transform.eulerAngles.x, raycastObject.transform.eulerAngles.y + 30, raycastObject.transform.eulerAngles.z);

                }
                else if (dragable_prefab.name.Contains("finish_line"))
                {
                    raycastObject.transform.eulerAngles = new Vector3(raycastObject.transform.eulerAngles.x, raycastObject.transform.eulerAngles.y + 30, raycastObject.transform.eulerAngles.z);
                }
                else if (dragable_prefab.name.Contains("door"))
                {
                    raycastObject.transform.eulerAngles = new Vector3(raycastObject.transform.eulerAngles.x, raycastObject.transform.eulerAngles.y + 30, raycastObject.transform.eulerAngles.z);

                }
                else if (dragable_prefab.name.Contains("bridge"))
                {
                    raycastObject.transform.eulerAngles = new Vector3(raycastObject.transform.eulerAngles.x, raycastObject.transform.eulerAngles.y + 30, raycastObject.transform.eulerAngles.z);

                }
                else if (dragable_prefab.name.Contains("lamp"))
                {
                    raycastObject.transform.eulerAngles = new Vector3(raycastObject.transform.eulerAngles.x, raycastObject.transform.eulerAngles.y + 30, raycastObject.transform.eulerAngles.z);
                }
                else if (dragable_prefab.name.Contains("tank") || dragable_prefab.name.Contains("Tank"))
                {
                    raycastObject.transform.eulerAngles = new Vector3(raycastObject.transform.eulerAngles.x, raycastObject.transform.eulerAngles.y + 30, raycastObject.transform.eulerAngles.z);

                }
            }
            if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
            {
                dragable_prefab.transform.position = new Vector3(dragable_prefab.transform.position.x, dragable_prefab.transform.position.y, dragable_prefab.transform.position.z + step);
                raycastObject.transform.position = new Vector3(raycastObject.transform.position.x, raycastObject.transform.position.y, raycastObject.transform.position.z + step);

            }
            if (Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
            {
                dragable_prefab.transform.position = new Vector3(dragable_prefab.transform.position.x, dragable_prefab.transform.position.y, dragable_prefab.transform.position.z - step);
                raycastObject.transform.position = new Vector3(raycastObject.transform.position.x, raycastObject.transform.position.y, raycastObject.transform.position.z - step);

            }
            if (Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
            {
                dragable_prefab.transform.position = new Vector3(dragable_prefab.transform.position.x - step, dragable_prefab.transform.position.y, dragable_prefab.transform.position.z);
                raycastObject.transform.position = new Vector3(raycastObject.transform.position.x - step, raycastObject.transform.position.y, raycastObject.transform.position.z);

            }
            if (Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
            {
                dragable_prefab.transform.position = new Vector3(dragable_prefab.transform.position.x + step, dragable_prefab.transform.position.y, dragable_prefab.transform.position.z);
                raycastObject.transform.position = new Vector3(raycastObject.transform.position.x + step, raycastObject.transform.position.y, raycastObject.transform.position.z);

            }



            if (Input.GetKeyDown(KeyCode.Q) && !Input.GetKey(KeyCode.LeftShift))
            {
                height -= 0.2f;
                raycastObject.transform.position = new Vector3(raycastObject.transform.position.x, raycastObject.transform.position.y - 0.2f, raycastObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.E) && !Input.GetKey(KeyCode.LeftShift))
            {
                height += 0.2f;
                raycastObject.transform.position = new Vector3(raycastObject.transform.position.x, raycastObject.transform.position.y + 0.2f, raycastObject.transform.position.z);
            }




            if (gameObject.name.Contains("finish_line") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) ||
     gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
            {
                raycastObject.transform.localScale = new Vector3(raycastObject.transform.localScale.x, gameObject.transform.localScale.y, raycastObject.transform.localScale.z + step);
            }
            if (gameObject.name.Contains("finish_line") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S) && gameObject.transform.localScale.z > 1 ||
                gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
            {
                raycastObject.transform.localScale = new Vector3(raycastObject.transform.localScale.x, raycastObject.transform.localScale.y, raycastObject.transform.localScale.z - step);

            }
            if (gameObject.name.Contains("finish_line") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D) ||
                gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
            {
                raycastObject.transform.localScale = new Vector3(raycastObject.transform.localScale.x + step, raycastObject.transform.localScale.y, raycastObject.transform.localScale.z);

            }
            if (gameObject.name.Contains("finish_line") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A) && gameObject.transform.localScale.x > 1 ||
                gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A))
            {
                raycastObject.transform.localScale = new Vector3(raycastObject.transform.localScale.x - step, raycastObject.transform.localScale.y, raycastObject.transform.localScale.z);
            }


            if (gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q) && gameObject.transform.localScale.y > 1)
            {
                raycastObject.transform.localScale = new Vector3(raycastObject.transform.localScale.x, raycastObject.transform.localScale.y - step, raycastObject.transform.localScale.z);
                raycastObject.transform.position = new Vector3(raycastObject.transform.position.x, raycastObject.transform.position.y - step / 2, raycastObject.transform.position.z);
                dragable_prefab.transform.position = new Vector3(dragable_prefab.transform.position.x, dragable_prefab.transform.position.y - step / 2, dragable_prefab.transform.position.z);

            }
            if (gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.E))
            {
                raycastObject.transform.localScale = new Vector3(raycastObject.transform.localScale.x, gameObject.transform.localScale.y + step, raycastObject.transform.localScale.z);
                raycastObject.transform.position = new Vector3(raycastObject.transform.position.x, gameObject.transform.position.y + step / 2, raycastObject.transform.position.z);
                dragable_prefab.transform.position = new Vector3(dragable_prefab.transform.position.x, dragable_prefab.transform.position.y + step / 2, dragable_prefab.transform.position.z);

            }








        }
        else if (dragable_prefab != null && raycastObject != null)
        {

            dragable_prefab.transform.position = new Vector3(raycastObject.transform.position.x, raycastObject.transform.position.y, raycastObject.transform.position.z);
            dragable_prefab.transform.localScale = raycastObject.transform.localScale;      
            dragable_prefab.transform.eulerAngles = raycastObject.transform.eulerAngles;
            Destroy(raycastObject);
            raycastObject = null;
            dragable_prefab.GetComponent<MeshRenderer>().enabled = true;

            if (dragable_prefab.name.Contains("tank") || dragable_prefab.name.Contains("Tank"))
            {
                gameObject.transform.FindChild("Sphere").gameObject.SetActive(false);
            }

            foreach (Transform child in dragable_prefab.transform)
            {
                if (!child.name.Contains("wires") && !child.name.Contains("Point") && !child.name.Contains("Bullet_spawn") && !child.name.Contains("dir"))
                {
                    child.GetComponent<MeshRenderer>().enabled = true;

                }
                else
                {
                    if (child.name.Contains("Bullet_spawn") && child.name.Contains("dir"))
                    {

                    }
                    else
                    {
                        child.transform.gameObject.SetActive(true);

                    }
                }
            }
            dragable_prefab.GetComponent<SelectedObj>().enabled = true;
        }

    }
}
