using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Threading;
using System;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts.Online_Level_Play;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VariablesValuesNames
{
    public string Name;
    public float Value;

    public VariablesValuesNames()
    {
    }

    public VariablesValuesNames(string Name, float Value)
    {
        this.Name = Name;
        this.Value = Value;
    }
}

public static class LaunchedState {

  
    public static List<VariablesValuesNames> Variables = new List<VariablesValuesNames>();
    public static VariablesValuesNames newVariablesValuesNames;

    public static bool LevelCompleted = false;
    public static Level level;
    public static bool KillWhile = false;

    public static float DistanceFrontToObject;


    public static bool MoveRobot;
    public static bool LockMovement;
    public static float x;
    public static float y;
    public static float z;

    public static bool IsLoaunched;



    public static bool IsIfTemp;
    public static bool sincIsIf;
    public static GameObject GameObjectIsIf;

    public static bool IsWhileTemp;
    public static bool sincIsWhile;
    public static GameObject GameObjectIsWhile;

    public static bool sincDebug;
    public static GameObject GameObjectDebug;

    public static bool FormatedLogic;
    public static bool sincFormatedLogic;
    public static GameObject GameObjectFormatedLogic;

    public static bool FormatLogic(GameObject gameObject) {
        if (LaunchedState.KillWhile)
        {
            return false;
        }
        GameObjectFormatedLogic = gameObject;
        sincFormatedLogic = true;
        while (sincFormatedLogic)
        {
            Thread.Sleep(1);
        }

        return FormatedLogic;
    }

    public static void LockDebug(GameObject gameObject) {

        GameObjectDebug = gameObject;
        sincDebug = true;
        while (sincDebug)
        {
            Thread.Sleep(1);
        }
    }

    public static void SinkIsWhile(GameObject gameObject) {
        GameObjectIsWhile = gameObject;
        sincIsWhile = true;
        while (sincIsWhile)
        {
            Thread.Sleep(1);
        }
    }
    public static void SinkIsIf(GameObject gameObject)
    {
        GameObjectIsIf = gameObject;
        sincIsIf = true;
        while (sincIsIf)
        {
            Thread.Sleep(1);
        }
    }


    public static bool LockToGetName;
    public static GameObject GameObjectToGetName;
    public static string GameObjectName;
    public static string GetName(GameObject gameObject) {
        GameObjectToGetName = gameObject;
        LockToGetName = true;
        while (LockToGetName)
        {
            Thread.Sleep(1);
        }
        return GameObjectName;
    }
    public static bool LockRotate;
    public static float Rotation = 0;
    public static GameObject RotategameObject;
    public static void Rotate(GameObject gameObject)
    {
       // Debug.Log("Rotate");
        RotategameObject = gameObject;
       // Debug.Log("Rotate()");
        LockRotate = true;
        while (LockRotate)
        {
            Thread.Sleep(1);
        }
    }
    public static GameObject MoveGameObject;
    public static void Move(GameObject gameObject) {
       
       // Debug.Log("Move()");
        MoveGameObject = gameObject;
        MoveRobot = true;
        LockMovement = true;
    }
    public static GameObject SetVarGameObject;
    public static bool VarLock;
    public static void SetVar(GameObject gameObject)
    {
       // Debug.Log("  public static void SetVar(GameObject gameObject)");
        SetVarGameObject = gameObject;
        VarLock = true;
        while (VarLock)
        {
            Thread.Sleep(1);
        }
    }
    public static GameObject WaitObject;
    public static bool WaitLock;
    public static int Waittime;
    public static void Wait(GameObject gameObject)
    {
        WaitObject = gameObject;
        WaitLock = true;
        while (WaitLock)
        {
            Thread.Sleep(1);
        }
    }

    
    public static bool ShotLock;
    public static void Shot()
    {
        ShotLock = true;
      
    }


}
public class Launcher : MonoBehaviour
{
    public GameObject LoadBtn;
    public void ReloadLevel()
    {
        LaunchedState.ShotLock = false;
        LaunchedState. Variables = new List<VariablesValuesNames>();
        LaunchedState.x = 0;
        LaunchedState.y = 0;
        LaunchedState.z = 0;
        LaunchedState.Rotation = 0;
        TankPropsStatic.waypoints.Clear();
        try
        {
            foreach (Object item in LaunchedState.level.objects)
            {
               // Debug.Log(item.name + "  " + "sdfghjkl;lkjhgfdsdfghjkl;lkjhgfdsdfghjkl;lkjhgfdsasdfghjkl;lkjhgfdsdfghjkl;;lkjcxzdfghjkl;lkjhg");
                if (item.name.Contains("robot"))
                {
                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().robot_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = false;
                    temp.GetComponent<RobotBehaviour>().SetRobotBehaviourRigidbodyKinematic(false);//.isKinematic = false;//fall down
                }
                else if (item.name.Contains("Wall"))
                {
                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().wall_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<Renderer>().material.color = new Color(item.r, item.g, item.b);
                    temp.GetComponent<SelectedObj>().enabled = false;
                    temp.transform.localScale = new Vector3(item.scaleX, item.scaleY, item.scaleZ);
                }
                else if (item.name.Contains("ramp"))
                {

                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().ramp_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<Renderer>().material.color = new Color(item.r, item.g, item.b);
                    temp.GetComponent<SelectedObj>().enabled = false;
                }
                else if (item.name.Contains("lamp"))
                {
                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().lamp_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = false;
                }
                else if (item.name.Contains("doors"))
                {
                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().doors_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = false;
                }
                else if (item.name.Contains("bridge"))
                {
                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().bridge_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = false;
                }
                else if (item.name.Contains("finish"))
                {
                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().finish_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = false;
                }
                else if (item.name.Contains("tank"))
                {
                  //  Debug.LogError(LoadBtn.GetComponent<LoadBtn>().tank_prefab);
                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().tank_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);



                    Destroy(temp.transform.GetChild(0).GetComponent<SelectedObj>());
                    Destroy(temp.transform.GetChild(0).GetComponent<Draggable>());
                    Destroy(temp.transform.GetChild(0).GetComponent<TankTriggerManager>());
                }
                else if (item.name.Contains("waypoint"))
                {
                    GameObject temp = Instantiate(LoadBtn.GetComponent<LoadBtn>().waypoint_prefab, new Vector3(item.posX, item.posY, item.posZ), Quaternion.identity);
                    temp.transform.localEulerAngles = new Vector3(item.rotationX, item.rotationY, item.rotationZ);
                    temp.GetComponent<SelectedObj>().enabled = false;
                    Waypoint t = new Waypoint();
                    t.posX = item.posX;
                    t.posY = item.posY;
                    t.posZ = item.posZ;
                    TankPropsStatic.waypoints.Add(t);
                }
            }
        }
        catch { }
      //  Debug.LogError(TankPropsStatic.waypoints.Count);
    }
    void Start()
    {
       // Debug.Log("  void Start()");
        if (!SceneManager.GetActiveScene().name.Equals("Player_level"))
        {
      ReloadLevel();
        }
  

    }



    public GameObject Main;
    public string Code = "";
    int index = 0;
    int indexindex = 0;

   

    private void GetChildren(GameObject parent)
    {

        if (LaunchedState.KillWhile)
        {
            return;
        }
        index++;

        bool isLoop = false;
        bool Ifstate = false;
        bool NotWithLogic = true;
        try
        {
            string parentName = LaunchedState.GetName(parent);
            if (parentName.Equals("stop"))
            {
              //  Debug.Log("StopAllCoroutines");
                LaunchedState.x = 0;
                LaunchedState.y = 0;
                LaunchedState.z = 0;
                return;
            }
            if (parentName.Equals("rotate"))
            {
                LaunchedState.Rotate(parent);
                return;
            }
            if (parentName.Equals("shoot"))
            {
                LaunchedState.Shot();
                return;
            }
            if (parentName.Equals("wait"))
            {
                LaunchedState.Wait(parent);
             //   Debug.Log("Miega"+ LaunchedState.Waittime);
                Thread.Sleep(1000 * LaunchedState.Waittime);
             //   Debug.Log("atsibunda");
                return;
            }
            if (parentName.Equals("Set"))
            {
              //  Debug.Log("IS in set");
                IsInVariablesList = false;
                LaunchedState.newVariablesValuesNames = new VariablesValuesNames();
                LaunchedState.SetVar(parent);// Set(parent);
                if (IsInVariablesList)
                {
                    for (int i = 0; i < LaunchedState.Variables.Count; i++)
                    {
                        if (LaunchedState.Variables[i].Name.Equals(LaunchedState.newVariablesValuesNames.Name))
                        {
                            LaunchedState.Variables[i].Value = LaunchedState.newVariablesValuesNames.Value;
                            break;
                        }
                    }
                }
                else
                {
                    LaunchedState.Variables.Add(LaunchedState.newVariablesValuesNames);
                }
                IsInVariablesList = false;
                return;
            }
            if (parentName.Equals("move"))
            {
              //  Debug.Log("MoveDirection");
                LaunchedState.LockDebug(parent);
              //  Debug.Log("Lock");
                LaunchedState.MoveRobot = true;
                LaunchedState.Move(parent);
              //  Debug.Log("after move parent");
            }
            //  LaunchedState.LockDebug(parent);--------------------------------------------------------------------------------------------------------------------------------
            LaunchedState.SinkIsWhile(parent);
            if (LaunchedState.IsWhileTemp)
            {
                NotWithLogic = false;
                LaunchedState.IsWhileTemp = false;

                isLoop = true;
            }
            LaunchedState.SinkIsIf(parent);

            if (LaunchedState.IsIfTemp)//parent.GetComponent<CodePart>().IsIF)
            {
                NotWithLogic = false;
                LaunchedState.IsIfTemp = false;
                Ifstate = LaunchedState.FormatLogic(parent);

            }


            if (Ifstate || NotWithLogic)
            {

                GameObject[] thredchildrens = LockAndGetData(parent);
                for (int i = 0; i < thredchildrens.Length; i++)
                {
                    GameObject children = thredchildrens[i];
                    GetChildren(children);
                }
            }


            if (isLoop)//gets logic continue or brake loop
            {

              //  Debug.Log("________________Logic data = " + LaunchedState.FormatLogic(parent));
               // Debug.Log("LaunchedState.KillWhile" + LaunchedState.KillWhile);
                while (!LaunchedState.KillWhile && LaunchedState.FormatLogic(parent))//parent.GetComponent<CodePart>().FormatLogic(parent))
                {
                 //   Debug.Log("LaunchedState.KillWhile" + LaunchedState.KillWhile);

                    GameObject[] thredchildrens = LockAndGetData(parent);
                    for (int i = 0; i < thredchildrens.Length; i++)
                    {

                        GameObject children = thredchildrens[i];
                        GetChildren(children);
                    }
                }
                //    LaunchedState.IsLoaunched = false;
              //  Debug.Log("!!!!!!!!!!!!!!!!!!!!!!Steitas: " + LaunchedState.IsLoaunched);
                //       LaunchedState.IsLoaunched = false;
                isLoop = false;

            }
        }
        catch
        {

            GameObject[] thredchildrens = LockAndGetData(parent);

            for (int i = 0; i < thredchildrens.Length; i++)
            {

                GetChildren(thredchildrens[i]);
            }

        }
        index--;


    }
    private GameObject[] LockAndGetData(GameObject parent)
    {


        SleepFirstLoop = true;
        mainThredparent = parent;
        while (SleepFirstLoop)
        {
            Thread.Sleep(1);
        }

        return mainThredchildrens;

    }

    Thread thread;

    private bool SleepFirstLoop;
    public void KillWhile()
    {
        LaunchedState.KillWhile = true;
        LaunchedState.KillWhile = true;
        LaunchedState.KillWhile = true;
        LaunchedState.KillWhile = true;
        LaunchedState.KillWhile = true;
        try
        {
            thread.Abort();
        }
        catch { }
    }
  bool runing = false;
    public GameObject RunButton;

    //tutorial level var
    public GameObject speechBubbleToClose;

    //
    public void Execute()
    {
        Scene scene = SceneManager.GetActiveScene();

        // Check if the name of the current Active Scene is your first Scene.
        if (scene.name == "Player_level")
        {
            if (!runing)
            {

                LaunchedState.KillWhile = false;
                //Debug.Log("NPaleistas");
                LaunchedState.IsLoaunched = true;
                //  Debug.Log("Paledau");
                if (GameObject.Find("Tank_1(Clone)") != null)
                {



                    GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.GetComponent<TankMovementManager>().movement = true;
                    GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.transform.FindChild("Sphere").gameObject.GetComponent<TankShootManager>().movement = true;


                }

                if (GameObject.Find("robot_arduino_1(Clone)") != null)
                {
                    GameObject.Find("robot_arduino_1(Clone)").GetComponent<Rigidbody>().isKinematic = false;
                }

                if (GameObject.Find("Tank_1(Clone)") != null)
                {
                    GameObject.Find("Tank_1(Clone)").transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;

                }
                if (scene.name != "Level 1")
                {
                    GameObject.Find("Manager").GetComponent<OnlineGameManager>().sw.Start();

                }
                //Debug.Log("PoTanku");

                runing = true;

              //  Debug.Log("Viduje");
                thread = new Thread(() => GetChildren(Main));
                thread.Start();
               // Debug.Log("after start");

            }
            else
            {
                LaunchedState.IsLoaunched = false;
                LaunchedState.MoveRobot = false;
                LaunchedState.Rotation = 0;
                KillWhile();
                runing = false;
            }
           // Static_variables.sw = new System.Diagnostics.Stopwatch();
           // Static_variables.sw.Start();
        }
        else
        {


            //    Debug.Log("runing" + runing);
            if (runing)///sustabdau
            {
                if (scene.name == "Tutorial" || scene.name == "Level 1" || scene.name == "lastSave")
                {

                    LaunchedState.IsLoaunched = false;
                    LaunchedState.MoveRobot = false;


                    KillWhile();
                    runing = false;
                    return;
                }

              //  Debug.Log("sustabd=iau");
                LaunchedState.IsLoaunched = false;
                LaunchedState.MoveRobot = false;

                KillWhile();
                var gameObjects = GameObject.FindGameObjectsWithTag("savable");
                for (var i = 0; i < gameObjects.Length; i++)
                {
                    Destroy(gameObjects[i]);
                }
               // Debug.Log(" if (!runing)///sustabdau");
                ReloadLevel();
                runing = false;
            }
            else
        if (!runing)//paleižiu
            {
                if (scene.name == "Tutorial")
                {
                    speechBubbleToClose.SetActive(false);

                }
                LaunchedState.KillWhile = false;
               // Debug.Log("NPaleistas");
                LaunchedState.IsLoaunched = true;
                //  Debug.Log("Paledau");
                if (GameObject.Find("Tank_1(Clone)") != null)
                {
                    GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.GetComponent<TankMovementManager>().movement = true;
                    GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.transform.FindChild("Sphere").gameObject.GetComponent<TankShootManager>().movement = true;

                    if (TankPropsStatic.BarrelRotationSpeed != null)
                    {

                        GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.transform.FindChild("Sphere").GetComponent<TankShootManager>().speed = TankPropsStatic.BarrelRotationSpeed;
                        GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.transform.FindChild("Sphere").GetComponent<TankShootManager>().shootSpeed = TankPropsStatic.ShootingSpeed;
                        GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.GetComponent<TankMovementManager>().movementSpeed = TankPropsStatic.MovementSpeed;
                        GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.transform.FindChild("Sphere").transform.localScale = TankPropsStatic.Scale;
                    }

                }
                if (GameObject.Find("robot_arduino_1(Clone)") != null)
                {
                    GameObject.Find("robot_arduino_1(Clone)").GetComponent<Rigidbody>().isKinematic = false;
                }

                //Debug.Log("PoTanku");
                runing = true;

               // Debug.Log("Viduje");
                thread = new Thread(() => GetChildren(Main));
                thread.Start();
                //Debug.Log("after start");
            }


            //Cia as papildau, kai paspaudi pradejimo mygtuka tankas pradeda sekti taskus ir saudit i zaideja

            //GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.GetComponent<Tank_movement_manager>().movement = true;
            //GameObject.Find("Tank_1(Clone)").transform.GetChild(0).gameObject.transform.FindChild("Sphere").gameObject.GetComponent<Tank_shoot_manager>().movement = true;


            ////
            //LaunchedState.IsLoaunched = true;
            //Debug.Log("Viduje");
            //thread = new Thread(() => GetChildren(Main));
            //thread.Start();
            //Debug.Log("after start");
        }
    }


    bool IsInVariablesList;
    bool HaveMinus;
    private void Set(GameObject parent)
    {
        string text = "";
        float value = 0;
        //      Debug.Log(parent.name);
        if (parent.name.Equals("Dropdown"))
        {
            text = parent.GetComponent<TMP_Dropdown>().captionText.text.ToString();
            //   Debug.Log("Text++++" + text);
            for (int i = 0; i < LaunchedState.Variables.Count; i++)
            {
                if (LaunchedState.Variables[i].Name.Equals(text))
                {
                    IsInVariablesList = true;
                    break;
                }
            }
            LaunchedState.newVariablesValuesNames.Name = text;
        }
        try
        {
      //      Debug.Log("HaveMinus=" + HaveMinus);
            if (!HaveMinus)
            {
                value = float.Parse(parent.GetComponent<TMP_InputField>().text);
               // Debug.Log("value" + value);
                LaunchedState.newVariablesValuesNames.Value = value;
            }
            LaunchedState.newVariablesValuesNames.Value= parent.GetComponent<CodePart>().GetValue(parent);
           // Debug.Log("ALL OK");
        }
        catch
        {

        }

        //       Debug.Log("Value______:" + value);
        for (int i = 0; i < parent.transform.childCount; i++)
        {

            if (parent.transform.GetChild(i).gameObject.name.Equals("Minus"))
            {
                HaveMinus = true;
            }

        }
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            
            GameObject children = parent.transform.GetChild(i).gameObject;
            Set(children);
        }
    }
    GameObject mainThredparent = null;
    GameObject[] mainThredchildrens = null;
    void Update()
    {
        if (mainThredparent != null)
        {
            mainThredchildrens = new GameObject[mainThredparent.transform.childCount];
            for (int i = 0; i < mainThredparent.transform.childCount; i++)
            {
                mainThredchildrens[i] = mainThredparent.transform.GetChild(i).gameObject;
            }
            mainThredparent = null;
            SleepFirstLoop = false;
        }
        if (LaunchedState.sincDebug)
        {
            LaunchedState.sincDebug = false;
        }
        if (LaunchedState.sincIsWhile)
        {
            try
            {
                LaunchedState.IsWhileTemp = LaunchedState.GameObjectIsWhile.GetComponent<CodePart>().IsWhile;//null object reference  CodePart ignor
            }
            catch { }
            LaunchedState.sincIsWhile = false;
        }
        if (LaunchedState.sincIsIf)
        {
            try
            {
                LaunchedState.IsIfTemp = LaunchedState.GameObjectIsIf.GetComponent<CodePart>().IsIF;//null object reference  CodePart ignor
            }
            catch { }
            LaunchedState.sincIsIf = false;
        }
        if (LaunchedState.sincFormatedLogic)
        {
            try
            {
                LaunchedState.FormatedLogic = LaunchedState.GameObjectFormatedLogic.GetComponent<CodePart>().FormatLogic(LaunchedState.GameObjectFormatedLogic);
            }
            catch
            {
                LaunchedState.FormatedLogic = false;
            }
            //     Debug.Log("sincFormatedLogic = false and FormatedLogic="+ LaunchedState.FormatedLogic);
            LaunchedState.sincFormatedLogic = false;
        }
        if (LaunchedState.LockToGetName)
        {
            LaunchedState.GameObjectName = LaunchedState.GameObjectToGetName.name;
            LaunchedState.LockToGetName = false;
        }
        if (LaunchedState.LockMovement)
        {
           // Debug.Log("   if (LaunchedState.LockMovement)");
            LaunchedState.MoveGameObject.GetComponent<CodePart>().Movement(LaunchedState.MoveGameObject);
            LaunchedState.LockMovement = false;
        }
        if (LaunchedState.LockRotate)
        {
           // Debug.Log("       if (LaunchedState.LockRotate)");
            LaunchedState.RotategameObject.GetComponent<CodePart>().Rotate(LaunchedState.RotategameObject);
            LaunchedState.LockRotate = false;
        }
        if (LaunchedState.VarLock)
        {
           // Debug.Log("LaunchedState.VarLock");
            Set(LaunchedState.SetVarGameObject);
            LaunchedState.VarLock = false;
            //Debug.Log("FASE fal4");
        }
        if (LaunchedState.WaitLock)
        {
            GetTime(LaunchedState.WaitObject);
            LaunchedState.WaitLock = false;
        }
        if (LaunchedState.ShotLock)
        {
            StartShout();//jai nebenori kad 6suditu ()
LaunchedState.ShotLock =false;
        }
    }
    void StartShout() {

        GameObject gameObject = GameObject.Find("robot_arduino_1(Clone)");
        //TODO
        gameObject.GetComponent<PlayerShootManager>().Shoot();
       // Debug.Log("Bam bam");
    }
    void GetTime(GameObject parent)
    {

        int value = 0;
        try
        {
            value = int.Parse(parent.GetComponent<TMP_InputField>().text);
    //        Debug.Log("value" + value);
            LaunchedState.Waittime = value;
        }
        catch
        {
        }
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject children = parent.transform.GetChild(i).gameObject;
            GetTime(children);
        }

    }
}
