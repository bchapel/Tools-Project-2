using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(obstacleEngine))]
public class obstacleEditor : Editor  {

    private SerializedProperty serStartPos;
    private SerializedProperty serEndPos;
    private GameObject thisObj;

    private void OnEnable()
    {
        serStartPos = this.serializedObject.FindProperty("startPos");
        serEndPos = this.serializedObject.FindProperty("endPos");
        thisObj = (GameObject) this.serializedObject.targetObject;
    }


    public override void OnInspectorGUI()
    {

        serStartPos.vector3Value = thisObj.transform.position;
        Debug.Log(serStartPos);
        //serStartPos.vector3Value.x = thisObj.transform.position.x - defaultDistance;
        serEndPos.vector3Value = thisObj.transform.position;
        Debug.Log(serEndPos);
        //serEndPos.x = go.transform.position.x + defaultDistance;
        base.OnInspectorGUI();
    }
}
