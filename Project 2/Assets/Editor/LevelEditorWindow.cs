﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

public class LevelEditorWindow : EditorWindow
{

    private static LevelEditorWindow instance;
    //String name of ojbect(s) to search for
    public string objectSearch = "";
    private float defaultSpeed;
    private float trackLength;

    public static void ShowWindow()
    {
        instance = EditorWindow.GetWindow<LevelEditorWindow>();
        instance.titleContent = new GUIContent("Level Editor");
    }

    private float currentX;


    //Fetch the asset's GUID
    private void OnGUI()
    {

        //Search for object name?
        GUILayout.BeginHorizontal();


        GUILayout.BeginVertical();
        if (GUILayout.Button("Create Obstacle"))

        {

            GameObject obstacle = Instantiate(Resources.Load("Prefabs/obstacleHolder", typeof(GameObject))) as GameObject;
            GameObject startPos = obstacle.transform.GetChild(1).gameObject;
            GameObject endPos = obstacle.transform.GetChild(2).gameObject;
            Debug.Log(obstacle);
            obstacle.transform.position = new Vector3(0, 0, 0);
            obstacle.transform.GetChild(0).GetComponent<obstacleEngine>().obstacleDistance = trackLength;
            obstacle.transform.GetChild(0).GetComponent<obstacleEngine>().moveSpeed = defaultSpeed;
            obstacle.name = "Obstacle Holder";

            startPos.transform.position = obstacle.transform.position + new Vector3(trackLength, 0, 0);
            endPos.transform.position = obstacle.transform.position - new Vector3(trackLength, 0, 0);
            //startPos.transform.position -= trackLength;
        }

        defaultSpeed = EditorGUILayout.FloatField("Default Speed", defaultSpeed);
        trackLength = EditorGUILayout.FloatField("Track Length", trackLength);

        GUILayout.EndVertical();


        if (GUILayout.Button("Create Target!"))
        {
            GameObject target = Instantiate(Resources.Load("Prefabs/Target", typeof(GameObject))) as GameObject;
            target.transform.position = new Vector3(0, 0, 0);
            target.name = "Target";
        }
        if (GUILayout.Button("Create Crossbow!"))
        {
            GameObject crossbow = Instantiate(Resources.Load("Prefabs/Crossbow", typeof(GameObject))) as GameObject;
            crossbow.transform.position = new Vector3(0, 0, 0);
            crossbow.name = "Crossbow";
        }

        GUILayout.EndHorizontal();



    }
}
