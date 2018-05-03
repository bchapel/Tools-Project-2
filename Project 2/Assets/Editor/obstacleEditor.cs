using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(obstacleEngine))]
public class obstacleEditor : Editor
{

    private SerializedProperty serStartPos;
    private SerializedProperty serEndPos;
    private SerializedProperty serMoveSpeed;
    private GameObject thisObj;
    public float moveSpeed;

    private void OnEnable()
    {
        serStartPos = this.serializedObject.FindProperty("startPos");
        serEndPos = this.serializedObject.FindProperty("endPos");
        serMoveSpeed = this.serializedObject.FindProperty("moveSpeed");
        thisObj = Selection.activeGameObject;

        //thisObj.transform.root

        //serStartPos.vector3Value = thisObj.transform.position;
        //Debug.Log(serStartPos);
        //serStartPos.vector3Value.x = thisObj.transform.position.x - defaultDistance;
        //serEndPos.vector3Value = thisObj.transform.position;
        //Debug.Log(serEndPos);
        //serEndPos.x = go.transform.position.x + defaultDistance;
    }


    [ExecuteInEditMode]


    public override void OnInspectorGUI()
    {
        moveSpeed = thisObj.GetComponent<obstacleEngine>().moveSpeed;
        GUILayout.BeginHorizontal();
        moveSpeed = EditorGUILayout.FloatField(moveSpeed);
        thisObj.GetComponent<obstacleEngine>().moveSpeed = moveSpeed;

       if(GUILayout.Button("Update Default Movespeed"))
        {
            Debug.Log("Updating default movespeed!");
            serMoveSpeed = this.serializedObject.FindProperty("moveSpeed");
            moveSpeed = serMoveSpeed.floatValue;
        }
        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}



//  USE LOCAL POSITION CHANGES TO MANIPULATE TRACK DISTANCE!!! 
//(IE: startPos transform.localPosition = new Vector3(trackDistance, 0, 0);
//      endPos transform.localPosition = new Vector3(-trackDistance, 0 0);
//