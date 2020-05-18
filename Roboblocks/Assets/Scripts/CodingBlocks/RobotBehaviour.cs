using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotBehaviour : MonoBehaviour
{
  
    public Vector3 direction ;
    public RaycastHit hit;
    public float MaxDistance = 100;
    public LayerMask LayerMask;
    GameObject gameObjectFrom;
    GameObject gameObjectTo;
    public float Distance;
    Rigidbody _Rigidbody;


    //Tutorial level
    public GameObject finishTutorialPanel;
    public GameObject speechBoxQuit;
    public GameObject quit_btn;
    public GameObject start_btn;
    public GameObject edit_btn;
    public GameObject stop_btn;
    //


    public GameObject GameOverPanel;
    public GameObject VictoryPanel;

  

    void Start()
    {
       gameObjectFrom = GameObject.Find("robot_arduino_wheel (3)");
         gameObjectTo = GameObject.Find("robot_arduino_wheel (2)");
        _Rigidbody = gameObject.GetComponent<Rigidbody>();
    }
   public void SetRobotBehaviourRigidbodyKinematic(bool isKinematic) {
        gameObject.GetComponent<Rigidbody>().isKinematic = isKinematic;      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            gameObject.GetComponent<PlayerController>().health -= 1;
        }
        if (collision.gameObject.name.Contains("finish_line"))
        {

            LaunchedState.LevelCompleted =true;

            Scene scene = SceneManager.GetActiveScene();

            // Check if the name of the current Active Scene is your first Scene.
            if (scene.name == "Player_level")
            {
                GameOverPanel = GameObject.Find("Canvas2").transform.FindChild("Game_Over_panel").gameObject;
                VictoryPanel = GameObject.Find("Canvas2").transform.FindChild("Victory_text").gameObject;

                GameOverPanel.SetActive(true);
                VictoryPanel.SetActive(true);
                LaunchedState.x = 0;
                LaunchedState.y = 0;
                LaunchedState.z = 0;


                GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Stop();



                GameObject.Find("Manager").GetComponent<OnlineGameManager>().victory = true;

               
            }else if (scene.name == "Tutorial")
            {

                finishTutorialPanel.SetActive(true);
                speechBoxQuit.SetActive(true);
                quit_btn.GetComponent<Animator>().SetBool("play_anim",true);
                LaunchedState.x = 0;
                LaunchedState.y = 0;
                LaunchedState.z = 0;
            }
            else if ( scene.name == "Level 1")
            {

                finishTutorialPanel.SetActive(true);
                LaunchedState.x = 0;
                LaunchedState.y = 0;
                LaunchedState.z = 0;
                

                if (stop_btn != null)
                {
                    stop_btn.SetActive(false);

                }
                start_btn.SetActive(false);
                edit_btn.SetActive(false);
            }

        }
    }
   
    void FixedUpdate()
    {
        if (LaunchedState.Rotation != 0)
        {
            float rotSpeed = 100;

            _Rigidbody.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(270, LaunchedState.Rotation, 0), rotSpeed * Time.deltaTime);

            if (LaunchedState.Rotation == _Rigidbody.rotation.y)
            {
                LaunchedState.Rotation = 0;
            }

        }

        gameObjectFrom = GameObject.Find("robot_arduino_wheel (3)");
        gameObjectTo = GameObject.Find("robot_arduino_wheel (2)");
        direction = gameObjectFrom.transform.position - gameObjectTo.transform.position;
        if (LaunchedState.MoveRobot)
        {
            if (LaunchedState.x == 1)
            {
                _Rigidbody.MovePosition(transform.position + (_Rigidbody.transform.rotation * new Vector3(3, 0, 0) * Time.deltaTime)); //forvard
            }
            if (LaunchedState.x == -1)
            {
                _Rigidbody.MovePosition(transform.position + (_Rigidbody.transform.rotation * new Vector3(-3, 0, 0) * Time.deltaTime));//back
            }

        }


    }
    void Update()
    {

        if (Physics.Raycast(transform.position, direction, out hit))
        {   
            LaunchedState.DistanceFrontToObject = hit.distance;
               Distance = hit.distance;
        }     
    }
}