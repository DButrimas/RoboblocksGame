using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SelectedObj : MonoBehaviour
{
    public GameObject color_panel;
    public GameObject step_panel;


    public Material ghost;
    public bool canEdit;
    public GameObject deleteConfirmPanel;
    public float step = 1f;
    public float rotation_def = 30;
    public Material defaultMat;

    public Material arduino_wheel;
    public Material arduino_body;
    public Material arduino_wires;

    public Material bridge;

    public Material door;
    public Material tankMat;

    public Material lamp_glass;
    public Material lamp;



    public GameObject rotation;
    public GameObject step_size;

    public GameObject tank_waypoints_panel;

    public GameObject tank_speed_panel;


    // Start is called before the first frame update
    void Start()
    {
        deleteConfirmPanel = GameObject.Find("Canvas").transform.FindChild("Delete_confirm_panel").gameObject;

        step_panel = GameObject.Find("Canvas").transform.FindChild("Step_select").gameObject;

        color_panel = GameObject.Find("Canvas").transform.FindChild("Color_select").gameObject;

        tank_waypoints_panel = GameObject.Find("Canvas").transform.FindChild("tank_waypoints_panel").gameObject;

        tank_speed_panel = GameObject.Find("Canvas").transform.FindChild("tank_rotation_panel").gameObject;

    }
    public void delete()
    {
        Destroy(gameObject);
        deleteConfirmPanel.SetActive(false);
        color_panel.SetActive(false);
        step_panel.SetActive(false);
        tank_waypoints_panel.SetActive(false);
        tank_speed_panel.SetActive(false);
    }
    public void cancel()
    {
        deleteConfirmPanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (canEdit)
        {

            if (SelectedStatic.selected.name.Contains("Wall") && color_panel.active == false)
            {
                color_panel.SetActive(true);
                step_panel.SetActive(true);

            }
            else if (SelectedStatic.selected.name.Contains("ramp") && color_panel.active == false)
            {
                color_panel.SetActive(true);
                step_panel.SetActive(true);
            }
            else if (SelectedStatic.selected.name.Contains("tank") && color_panel.active == false)
            {
                tank_waypoints_panel.SetActive(true);
                step_panel.SetActive(true);
                tank_speed_panel.SetActive(true);


            }
            else
            {
                step_panel.SetActive(true);
            }
            rotation = GameObject.Find("InputField rot");
            step_size = GameObject.Find("InputField step");
            try
            {
                step = float.Parse(step_size.GetComponent<TMP_InputField>().text.ToString());
                rotation_def = float.Parse(rotation.GetComponent<TMP_InputField>().text.ToString());
            }
            catch
            {
                step = float.Parse(step_size.GetComponent<TMP_InputField>().text.ToString().Replace('.', ','));
                rotation_def = float.Parse(rotation.GetComponent<TMP_InputField>().text.ToString().Replace('.', ','));
            }
            if (SelectedStatic.selected != gameObject || Input.GetKeyDown(KeyCode.Return))
            {
                color_panel.SetActive(false);
                step_panel.SetActive(false);
                tank_waypoints_panel.SetActive(false);
                tank_speed_panel.SetActive(false);

                if (gameObject.name.Contains("robot"))
                {
                    gameObject.GetComponent<Renderer>().material = arduino_body;

                }
                else if (gameObject.name.Contains("bridge"))
                {
                    foreach (Transform child in gameObject.transform)
                    {
                        child.GetComponent<Renderer>().material = bridge;
                    }
                }
                else if (gameObject.name.Contains("lamp"))
                {
                    gameObject.GetComponent<Renderer>().material = lamp;
                }
                else if (gameObject.name.Contains("tank"))
                {

                    gameObject.transform.FindChild("Sphere").gameObject.SetActive(false);

                }

                else
                {
                    if (gameObject.name.Contains("Wall") || gameObject.name.Contains("ramp"))
                    {

                        float r = gameObject.GetComponent<Renderer>().material.color.r;
                        float g = gameObject.GetComponent<Renderer>().material.color.g;
                        float b = gameObject.GetComponent<Renderer>().material.color.b;

                        if (gameObject.name.Contains("ramp"))
                        {
                            r = gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color.r;
                            g = gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color.g;
                            b = gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color.b;

                            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = defaultMat;
                            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(r, g, b, 255);
                        }
                        else
                        {
                            gameObject.GetComponent<Renderer>().material = defaultMat;
                            gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b, 255);
                        }

                        color_panel.SetActive(false);
                        step_panel.SetActive(false);
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material = defaultMat;


                    }
                }
                foreach (Transform child in gameObject.transform)
                {
                    if (child.name.Contains("wheel"))
                    {
                        child.GetComponent<Renderer>().material = arduino_wheel;
                    }
                    else if (child.name.Contains("wires"))
                    {
                        foreach (Transform child2 in child.transform)
                        {
                            child2.GetComponent<Renderer>().material = arduino_wires;
                        }

                    }
                    else if (child.name.Contains("door"))
                    {
                        child.GetComponent<Renderer>().material = door;
                    }
                    else if (child.name.Contains("Point"))
                    {
                    }
                    else if (child.name.Contains("Cylinder") && !gameObject.name.Contains("bridge"))
                    {
                        child.GetComponent<Renderer>().material = arduino_body;
                    }
                    else if (child.name.Contains("cabin") || child.name.Contains("pipe"))
                    {

                        child.GetComponent<Renderer>().material = tankMat;
                        child.transform.GetChild(0).GetComponent<Renderer>().material = tankMat;
                    }
                    else if (child.name.Contains("Cube") && !child.transform.parent.name.Contains("bridge"))
                    {
                        if (gameObject.name.Contains("tank"))
                        {
                            child.GetComponent<Renderer>().material = tankMat;

                        }
                        else
                        {
                            child.GetComponent<Renderer>().material = defaultMat;

                        }
                    }
                    else if (child.name.Contains("lamp"))
                    {
                        child.GetComponent<Renderer>().material = lamp_glass;
                    }


                }
                canEdit = false;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (gameObject.name.Contains("robot"))
                {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z + rotation_def);
                }
                else if (gameObject.name.Contains("Wall"))
                {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + rotation_def, gameObject.transform.eulerAngles.z);

                }
                else if (gameObject.name.Contains("ramp"))
                {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + rotation_def, gameObject.transform.eulerAngles.z);

                }
                else if (gameObject.name.Contains("finish_line"))
                {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + rotation_def, gameObject.transform.eulerAngles.z);
                }
                else if (gameObject.name.Contains("door"))
                {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + rotation_def, gameObject.transform.eulerAngles.z);

                }
                else if (gameObject.name.Contains("bridge"))
                {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + rotation_def, gameObject.transform.eulerAngles.z);

                }
                else if (gameObject.name.Contains("lamp"))
                {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + rotation_def, gameObject.transform.eulerAngles.z);

                }
                else if (gameObject.name.Contains("tank"))
                {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + rotation_def, gameObject.transform.eulerAngles.z);

                }
            }
            if (gameObject.name.Contains("finish_line") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) ||
                gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z + step);
            }
            if (gameObject.name.Contains("finish_line") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S) && gameObject.transform.localScale.z > 1 ||
                gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z - step);

            }
            if (gameObject.name.Contains("finish_line") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D) ||
                gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + step, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

            }
            if (gameObject.name.Contains("finish_line") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A) && gameObject.transform.localScale.x > 1 ||
                gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - step, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }


            if (gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q) && gameObject.transform.localScale.y > 1)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y - step, gameObject.transform.localScale.z);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - step / 2, gameObject.transform.position.z);
            }
            if (gameObject.name.Contains("Wall") && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.E))
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y + step, gameObject.transform.localScale.z);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + step / 2, gameObject.transform.position.z);

            }


            if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + step);
            }
            if (Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - step);
            }
            if (Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - step, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + step, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                deleteConfirmPanel.SetActive(true);
                SelectedStatic.selected = gameObject;
            }

            if (Input.GetKeyDown(KeyCode.Q) && !Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - step, gameObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.E) && !Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + step, gameObject.transform.position.z);
            }
        }
    }
    void OnMouseDown()
    {
        SelectedStatic.selected = gameObject;

        if (SelectedStatic.selected.gameObject == gameObject)
        {
            canEdit = true;
            if (gameObject.name.Contains("Wall") || gameObject.name.Contains("ramp"))
            {
                float r = gameObject.GetComponent<Renderer>().material.color.r;
                float g = gameObject.GetComponent<Renderer>().material.color.g;
                float b = gameObject.GetComponent<Renderer>().material.color.b;

                if (gameObject.name.Contains("ramp"))
                {
                    float r1 = gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color.r;
                    float g1 = gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color.g;
                    float b1 = gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color.b;

                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material = ghost;
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(r1, g1, b1, ghost.color.a);

                }
                else
                {
                    gameObject.GetComponent<Renderer>().material = ghost;
                    gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b, ghost.color.a);

                }


            }
            else
            {
                gameObject.GetComponent<Renderer>().material = ghost;
                if (gameObject.name.Contains("tank"))
                {
                    gameObject.transform.FindChild("Sphere").gameObject.SetActive(true);
                }

            }
            foreach (Transform child in gameObject.transform)
            {
                if (!child.name.Contains("wires") && !child.name.Contains("Point"))
                {
                    if (child.name.Contains("Bullet_spawn") && child.name.Contains("dir"))
                    {

                    }
                    else
                    {
                        child.GetComponent<MeshRenderer>().enabled = true;
                        child.GetComponent<Renderer>().material = ghost;
                        if (child.name.Contains("cabin"))
                        {
                            child.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                            child.transform.GetChild(0).GetComponent<Renderer>().material = ghost;

                        }
                    }
                }

            }
        }
    }
}
