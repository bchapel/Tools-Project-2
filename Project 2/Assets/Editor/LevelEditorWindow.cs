using System.Collections;
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

        if (GUILayout.Button("Create Obstacle"))
        
        {
            GameObject obstacle = Instantiate(Resources.Load("Prefabs/obstacleHolder", typeof(GameObject))) as GameObject;
            obstacle.transform.position = new Vector3(0, 0, 0);
            obstacle.transform.parent.position = new Vector3(0, 0, 0);
            obstacle.GetComponent<obstacleEngine>().moveSpeed = defaultSpeed;
        }

        if (GUILayout.Button("Create Target!"))
        {
            GameObject target = Instantiate(Resources.Load("Prefabs/Target", typeof(GameObject))) as GameObject;
            target.transform.position = new Vector3(0, 0, 0);
        }
        if (GUILayout.Button("Create Crossbow!"))
        {
            GameObject crossbow = Instantiate(Resources.Load("Prefabs/Crossbow", typeof(GameObject))) as GameObject;
            crossbow.transform.position = new Vector3(0, 0, 0);
        }

        GUILayout.EndHorizontal();
        GUILayout.BeginVertical();
        defaultSpeed = EditorGUILayout.FloatField("Default Speed", defaultSpeed);
    }
}
