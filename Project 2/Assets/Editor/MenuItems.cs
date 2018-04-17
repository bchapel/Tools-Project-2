using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems {


    [MenuItem("Tools/Level Creator/ Show Level Editor")]
	private static void LevelEditor()
    {
        LevelEditorWindow.ShowWindow();
    }
}
