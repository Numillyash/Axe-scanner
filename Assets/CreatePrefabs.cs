using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

public class CreatePrefabs : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 21; i++)
        {
            var obj = GameObject.Instantiate(prefab);

            obj.transform.position = new Vector3((i-10)*(18f/21), 0, 0);
            obj.name = string.Format("{0} axe", i);
            obj.GetComponent<Axes_test>().axeName = string.Format("{0}", i+1);
            obj.GetComponent<SpriteRenderer>().color = new Color(255*((i%3 == 1)? 1:0), 255 * ((i % 3 == 2) ? 1 : 0), 255 * ((i % 3 == 0) ? 1 : 0));
            Debug.LogWarning(obj.GetComponent<SpriteRenderer>().color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("21") > 0)
            Application.Quit();
        if (Input.GetAxis("Save") > 0)
            SaveStats();
    }

    void SaveStats() 
    {
        string fileName = "Stats.json";
        string jsonString = "";
        for (int i = 0; i < 21; i++)
        {
            var obj = GameObject.Find(string.Format("{0} axe", i));
            obj.GetComponent<Axes_test>().SetZero();
            jsonString += JsonConvert.SerializeObject(obj.GetComponent<Axes_test>().data) + "\n";
        }
        File.WriteAllText(fileName, jsonString);
        Debug.Log("Game data saved!");
    }
}

/*

1     => X axe
2     => Y axe
3-10  => 3-10 axes
11-20 => 0-9 buttons
21    => exit
 
 */
