using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUnlocker : MonoBehaviour
{

    public Color defColor;
    public static void WriteString(string levelName)
    {
        StreamWriter sw = new StreamWriter("unlocked.txt",true);

        sw.WriteLine(levelName);

        sw.Close();

    }

    static bool ReadString(string levelname)
    {
        StreamReader sw = new StreamReader("unlocked.txt", true);

        string line;

        while ((line = sw.ReadLine()) != null)
        {
            if (line == levelname)
            {
                return true;
            }
        }
        sw.Close();

        return false;
    }


    void Start()
    {

        if (ReadString(gameObject.name))
        {
            Destroy(gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject);
            gameObject.GetComponent<SelectedLevelLoader>().locked = false;

            gameObject.transform.GetChild(1).GetComponent<Image>().color = defColor;
        }

    }

    void Update()
    {
 
    }
}
