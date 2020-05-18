using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 3;
    public bool gameOver;
    int temp = 0;

    public float force = 5f;


    public bool test;

    public GameObject GameOverPanel;
    public GameObject LoseText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameOver = true;
        }
        if (gameOver == true && temp == 0)
        {
            Method();
            test = true;
        }
        if (test)
        {
            Test();
        }

    }
    public void Test()
    {
        foreach (Transform item in gameObject.transform)
        {
            if (item.gameObject.name.Contains("wheel"))
            {
                    item.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
            }
        }

    }
    public void Method()
    {
        foreach (Transform item in gameObject.transform)
        {
            if (item.gameObject.name.Contains("wheel"))
            {
                if (item.gameObject.GetComponent<Rigidbody>() != null)
                {
                    item.gameObject.GetComponent<Rigidbody>().isKinematic = false;

                }
            }
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        temp = 1;
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Player_level")
        {
            GameOverPanel = GameObject.Find("Canvas2").transform.FindChild("Game_Over_panel").gameObject;
            LoseText = GameObject.Find("Canvas2").transform.FindChild("Lose_text").gameObject;

            GameOverPanel.SetActive(true);
            LoseText.SetActive(true);
            LaunchedState.x = 0;
            LaunchedState.y = 0;
            LaunchedState.z = 0;

            GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Stop();

            GameObject.Find("Manager").GetComponent<OnlineGameManager>().gameover = true;


        }
    }
    public void OpenGameOverPanel()
    {

    }

}
