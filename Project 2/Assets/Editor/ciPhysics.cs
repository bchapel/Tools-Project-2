using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(physicsInspector))]
public class ciPhysics : Editor
{

    private static float defaultBounciness = 0f;
    private static string defaultMat = "defaultMaterial";
    private GameObject selectedObj;
    private float objBounciness = 0f;

    public override void OnInspectorGUI()
    {
          objBounciness = EditorGUILayout.FloatField("Bounciness: ", objBounciness);
        selectedObj = Selection.activeGameObject;
        //objBounciness = bounciness;
        //base.OnInspectorGUI();

        Debug.Log("Obj Bounciness: " + objBounciness);
        PhysicMaterial mat = selectedObj.GetComponent<Collider>().material;
        if (objBounciness != defaultBounciness && mat.name != defaultMat)
        {
            Debug.Log("Creating new physics object");
            PhysicMaterial mat2 = new PhysicMaterial(selectedObj.name);
;
            AssetDatabase.CreateAsset(mat2, "Assets/Materials/Physics/" + mat2.name + ".physicMaterial");
            Debug.Log(AssetDatabase.GetAssetPath(mat2));
            mat = mat2;
            mat2.bounciness = objBounciness;
            Debug.Log("Mat2 Bounciness: " + mat2.bounciness);
            Debug.Log("Mat1 Bounciness: " + mat.bounciness);
        }
        else if (objBounciness == defaultBounciness && mat.name != defaultMat)
        {
            Debug.Log("Mat 2 name: " + mat.name);
            Debug.Log("Deleting old physics material");
            FileUtil.DeleteFileOrDirectory("Assets/Materials/Physics/" + mat.name);
            mat = Resources.Load("Materials/Physics/defaultMaterial") as PhysicMaterial;
        }
    }
}

