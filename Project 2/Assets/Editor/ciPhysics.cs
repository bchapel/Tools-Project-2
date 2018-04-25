using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(physicsInspector))]
public class ciPhysics : Editor
{

    private static float defaultBounciness = 0f;
    private static string defaultMat = "pmatBouncy";
    private GameObject selectedObj;
    private float objBounciness = 0f;

    public override void OnInspectorGUI()
    {
        //Float that user manipulates.
        objBounciness = EditorGUILayout.FloatField("Bounciness: ", objBounciness);
        selectedObj = Selection.activeGameObject;
        Debug.Log("Game Object: " + selectedObj);
        //objBounciness = bounciness;
        //base.OnInspectorGUI();

        //Shortcut for referring to the physics material of the object.
        PhysicsMaterial2D mat = selectedObj.GetComponent<Collider2D>().sharedMaterial;
        Debug.Log("Physics Material Name: " + mat.name);

        //Check if Mat's name IS the default material.
        if (objBounciness != defaultBounciness && mat.name == defaultMat)
        { 


            PhysicsMaterial2D mat2 = new PhysicsMaterial2D(selectedObj.name);
            AssetDatabase.CreateAsset(mat2, "Assets/Resources/Materials/Physics/" + mat2.name + ".physicMaterial");
            selectedObj.GetComponent<Collider2D>().sharedMaterial = mat2;
            Debug.Log(AssetDatabase.GetAssetPath(mat2));
            mat2.bounciness = objBounciness;
            
        }
        else if (objBounciness == defaultBounciness && mat.name != defaultMat)
        {
            Debug.Log(Application.dataPath + "/Resources/Materials/Physics/");
           //Delete old physics material"
            FileUtil.DeleteFileOrDirectory(Application.dataPath + "/Resources/Materials/Physics/" + mat.name + ".physicMaterial");
            //Set selected Object's material back to default material.
            selectedObj.GetComponent<Collider2D>().sharedMaterial = Resources.Load("Materials/Physics/" + defaultMat) as PhysicsMaterial2D;

        }
        else if (objBounciness != mat.bounciness)
        {
            mat.bounciness = objBounciness;

        }
    }
}

