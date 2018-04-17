using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventCatcher))]
public class EventCatcherEditor : Editor {
    public string modeSelected;

    private static float rotationAmount = 1.0f;
    private static float movementAmount = 0.05f;
    private static float scaleAmount = 0.1f;
    private static float speedMode = 3f;
    private static float slowMode = 0.5f;
    private GameObject selectedObj;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    //Provided by Class:  Enables user to click on object in hierarchy and it will react to commands below in OnSceneGUI.  
    //If at least one scene window exists, it will set the first one as the current scene.
    private void OnEnable()
    {
        {
            ArrayList sceneViews = SceneView.sceneViews;
            if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();
        }
    }

    private void OnSceneGUI()
    {
        selectedObj = Selection.activeGameObject;
        Event currentEvent = Event.current;
        Transform objTransform = selectedObj.transform;

        //UnityEngine.MonoBehaviour.print("Event picked up: " + currentEvent.type);
        switch (currentEvent.type)
        {

            case EventType.KeyDown:
                if (currentEvent.keyCode != KeyCode.None)
                    
                //{
                //    UnityEngine.MonoBehaviour.print("Key Down: " + currentEvent.keyCode);
                //}
                currentEvent.Use();

                //Move Forwards, Scale X.  Rotate down.
                if (Event.current.keyCode == (KeyCode.UpArrow) || Event.current.keyCode == (KeyCode.W))
                {
                    switch(modeSelected)
                    {
                        case "MoveObject":
                            
                                selectedObj.transform.position = selectedObj.transform.position + Vector3.forward * movementAmount;
                            
                            //selectedObj.transform.position += 
                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.down * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(scaleAmount, 0, 0);
                            break;
                    }
                }
                //Move left, scale down on Z. Rotate left.
                if (Event.current.keyCode == (KeyCode.LeftArrow) || Event.current.keyCode == (KeyCode.A))
                {
                    switch (modeSelected)
                    {
                        case "MoveObject":
                            selectedObj.transform.position = selectedObj.transform.position + Vector3.left * movementAmount;

                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.left * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(0, 0, -scaleAmount);
                            break;
                    }
                }
                //Move right, scale up on Z.  Rotate right.
                if (Event.current.keyCode == (KeyCode.RightArrow) || Event.current.keyCode == (KeyCode.D))
                {
                    switch (modeSelected)
                    {
                        case "MoveObject":
                            selectedObj.transform.position = selectedObj.transform.position + Vector3.right * movementAmount;
                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.right * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(0, 0, scaleAmount);
                            break;
                    }
                }
                //Move back, scale down on X. Rotate up.
                if (Event.current.keyCode == (KeyCode.DownArrow) || Event.current.keyCode == (KeyCode.S))
                {
                    switch (modeSelected)
                    {
                        case "MoveObject":
                            selectedObj.transform.position = selectedObj.transform.position + Vector3.back * movementAmount;

                            break;

                        case "RotateObject":

                            selectedObj.transform.Rotate(Vector3.up * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(-scaleAmount, 0, 0);

                            break;
                    }
                }
                //Move down, scale up on Y.  Roll left.
                if (Event.current.keyCode == (KeyCode.RightControl) || Event.current.keyCode == (KeyCode.Q))
                {
                    switch (modeSelected)
                    {
                        case "MoveObject":
                            selectedObj.transform.position = selectedObj.transform.position + Vector3.down * movementAmount;

                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.forward * rotationAmount);

                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(0, -scaleAmount, 0);

                            break;
                    }
                }

                //Move up, scale up on Y.  Roll right.
                if (Event.current.keyCode == (KeyCode.Insert) || Event.current.keyCode == (KeyCode.E))
                {
                    switch (modeSelected)
                    {
                        case "MoveObject":
                            selectedObj.transform.position = selectedObj.transform.position + Vector3.up * movementAmount;

                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.back * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(0, scaleAmount, 0);
                            break;
                    }
                }
                break;



            case EventType.KeyUp:
                //UnityEngine.MonoBehaviour.print("Key Up: " + currentEvent.keyCode);
                currentEvent.Use();

                if (Event.current.keyCode == (KeyCode.Y))
                {
                    modeSelected = "RotateObject";
                }
                else if(Event.current.keyCode == (KeyCode.R))
                    {
                    modeSelected = "ScaleObject";
                }
                else if (Event.current.keyCode == (KeyCode.T))
                {
                    modeSelected = "MoveObject";
                }
                break;

        }
    }

}
