using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

public class LevelEditorWindow : EditorWindow {

    private static LevelEditorWindow instance;
	//String name of ojbect(s) to search for
    public string objectSearch = "";

    public static void ShowWindow()
    {
        instance = EditorWindow.GetWindow<LevelEditorWindow>();
        instance.titleContent = new GUIContent("Level Editor");
    }

    private float currentX;


    //Fetch the asset's GUID
    private void OnGUI()
    {
        GUILayout.Label("Hello World");

        //Search for object name?
        GUILayout.BeginHorizontal();
        GUILayout.Label("Object Name: ", GUILayout.MaxWidth(90));
        objectSearch = GUILayout.TextField(objectSearch, 25);
        GUILayout.EndHorizontal();
        //
        if (GUILayout.Button("Search Object!"))
        {
			int popupIndex = 0;
            string[] objectGuids = AssetDatabase.FindAssets(objectSearch);

            EditorWindow popup = GetWindow(typeof(EditorGUILayout));
            popup.Show();
            StringBuilder guidBuilder = new StringBuilder();
            foreach (string objectGuid in objectGuids)
            {
                guidBuilder.AppendLine(objectGuid);
            }
            //UnityEngine.MonoBehaviour.print(guidBuilder.ToString());
            if (objectGuids.Length > 0)
            {
                Debug.Log("ObjectGuids is greater than 0");
                EditorGUILayout.Space();
				popupIndex = EditorGUILayout.Popup (popupIndex, objectGuids);

				//Selected Object = array value of objectGuids.  Change 0 to listbox item!
				string trueObjectGuid = objectGuids[popupIndex];
				//string trueObjectGuid = objectGuids[0];

                //Get the asset's path from the GUID.
                string assetPath = AssetDatabase.GUIDToAssetPath(trueObjectGuid);
                UnityEngine.MonoBehaviour.print(assetPath);

				if (GUILayout.Button ("Create Object")) {
					
					//3 Fetch the object itself
					GameObject objectTemplate = AssetDatabase.LoadAssetAtPath (assetPath, typeof(GameObject)) as GameObject;

					GameObject newObject = GameObject.Instantiate (objectTemplate);
					newObject.name = objectTemplate.name;
				}
                //Funsies - Spawn in a line along X 
                //Vector3 newObjectPosition = newObject.transform.position;
                //newObjectPosition.x = currentX;
                //newObject.transform.position = newObjectPosition;

                //currentX += 1f;
            }
        }
    }
}
