using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventCatcher))]
public class EventCatcherEditor : Editor
{
    public string modeSelected = "MoveObject";

    private static float rotationAmount = 1.0f;
    private static float movementAmount = 0.05f;
    private static float scaleAmount = 0.1f;
    private static float speedMode = 3f;
    private static float slowMode = 0.5f;
    private GameObject selectedObj;


    //Mutually exclusive toggle buttons from here: https://gamedev.stackexchange.com/questions/98920/how-do-i-create-a-toggle-button-in-unity-inspector
    private static GUIStyle ToggleButtonStyleNormal = null;
    private static GUIStyle ToggleButtonStyleToggled = null;



    //This method condenses all our detections into one method, and it is called both when User has an open inspector or is in the scene window.
    //This allows user's hotkey presses to give them real-time feedback rather than relying on them clicking back on the menu.
    public void DetectAction()
    {
        if(Selection.activeObject)
        selectedObj = Selection.activeGameObject;


        Debug.Log(selectedObj);
        Event currentEvent = Event.current;

        Transform objTransform = selectedObj.transform;
            GameObject parent = selectedObj.transform.parent.gameObject;




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
                    switch (modeSelected)
                    {
                        case "MoveObject":

                            selectedObj.transform.position = selectedObj.transform.position + Vector3.up * movementAmount;
                            if (selectedObj.CompareTag("Obstacle"))
                            parent.transform.position = parent.transform.position + Vector3.up * movementAmount;

                            //selectedObj.transform.position += 
                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.down * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(0, scaleAmount, 0);
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
                            if (selectedObj.CompareTag("Obstacle"))
                                parent.transform.position = parent.transform.position + Vector3.left * movementAmount;

                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.left * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(-scaleAmount, 0, 0);
                            break;
                        case "MoveObstacle":
                            selectedObj.transform.position = Vector3.MoveTowards(selectedObj.transform.position, selectedObj.GetComponent<obstacleEngine>().endPos.transform.position, selectedObj.GetComponent<obstacleEngine>().moveSpeed / 2);
                            break;
                        case "RotateObstacle":
                            parent.transform.Rotate(Vector3.back * rotationAmount);
                            selectedObj.transform.Rotate(Vector3.forward * rotationAmount);
                            break;
                        case "MovePath":
                            parent.transform.GetChild(1).transform.LookAt(parent.transform.GetChild(0));
                            parent.transform.GetChild(1).transform.localPosition += Vector3.left * movementAmount;
                            parent.transform.GetChild(2).transform.LookAt(parent.transform.GetChild(0));
                            parent.transform.GetChild(2).transform.localPosition +=
                                Vector3.right * movementAmount;
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
                            if (selectedObj.CompareTag("Obstacle"))
                                parent.transform.position = parent.transform.position + Vector3.right * movementAmount;
                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.right * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(scaleAmount, 0, 0);
                            break;
                        case "MoveObstacle":
                            selectedObj.transform.position = Vector3.MoveTowards(selectedObj.transform.position, selectedObj.GetComponent<obstacleEngine>().startPos.transform.position, selectedObj.GetComponent<obstacleEngine>().moveSpeed / 2);
                            break;
                        case "RotateObstacle":
                            parent.transform.Rotate(Vector3.forward * rotationAmount);
                            selectedObj.transform.Rotate(Vector3.back * rotationAmount);
                            break;
                        case "MovePath":
                            parent.transform.GetChild(1).transform.LookAt(parent.transform.GetChild(0));
                            parent.transform.GetChild(1).transform.localPosition += Vector3.right * movementAmount;
                            parent.transform.GetChild(2).transform.LookAt(parent.transform.GetChild(0));
                            parent.transform.GetChild(2).transform.localPosition +=
                                Vector3.left * movementAmount;
                            break;
                    }
                }
                //Move back, scale down on X. Rotate up.
                if (Event.current.keyCode == (KeyCode.DownArrow) || Event.current.keyCode == (KeyCode.S))
                {
                    switch (modeSelected)
                    {
                        case "MoveObject":
                            selectedObj.transform.position = selectedObj.transform.position + Vector3.down * movementAmount;
                            if (selectedObj.CompareTag("Obstacle"))
                                parent.transform.position = parent.transform.position + Vector3.down * movementAmount;

                            break;

                        case "RotateObject":

                            selectedObj.transform.Rotate(Vector3.up * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(0, -scaleAmount, 0);

                            break;
                    }
                }
                //Move down, scale up on Y.  Roll left.
                if (Event.current.keyCode == (KeyCode.RightControl) || Event.current.keyCode == (KeyCode.Q))
                {
                    switch (modeSelected)
                    {
                        case "MoveObject":
                            //selectedObj.transform.position = selectedObj.transform.position + Vector3.back * movementAmount;

                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.forward * rotationAmount);

                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(0, 0, scaleAmount);

                            break;
                    }
                }

                //Move up, scale up on Y.  Roll right.
                if (Event.current.keyCode == (KeyCode.Insert) || Event.current.keyCode == (KeyCode.E))
                {
                    switch (modeSelected)
                    {
                        case "MoveObject":
                            //selectedObj.transform.position = selectedObj.transform.position + Vector3.forward * movementAmount;

                            break;

                        case "RotateObject":
                            selectedObj.transform.Rotate(Vector3.back * rotationAmount);
                            break;

                        case "ScaleObject":
                            selectedObj.transform.localScale += new Vector3(0, 0, scaleAmount);
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
                else if (Event.current.keyCode == (KeyCode.R))
                {
                    modeSelected = "ScaleObject";
                }
                else if (Event.current.keyCode == (KeyCode.T))
                {
                    modeSelected = "MoveObject";
                }
                else if (Event.current.keyCode == (KeyCode.O))
                {
                    modeSelected = "MoveObstacle";
                }
                else if (Event.current.keyCode == (KeyCode.P))
                {
                    modeSelected = "RotateObstacle";
                }

                else if (Event.current.keyCode == (KeyCode.I))
                {
                    modeSelected = "MovePath";
                }
                break;

        }
        Repaint();
    }


    public override void OnInspectorGUI()
    {
        if (ToggleButtonStyleNormal == null)
        {
            ToggleButtonStyleNormal = "Button";
            ToggleButtonStyleToggled = new GUIStyle(ToggleButtonStyleNormal);
            ToggleButtonStyleToggled.normal.background = ToggleButtonStyleToggled.active.background;
        }

        GUILayout.BeginHorizontal();

        //if (GUILayout.Button(SetAmountFieldContent, _setValue ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
        //{
        //    _setValue = true;
        //    _smoothValue = false;
        //}
        if (GUILayout.Button("Move (T)", modeSelected == "MoveObject" ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
        {
            modeSelected = "MoveObject";

            //Put movement commands here.
        }

        if (GUILayout.Button("Rotate (Y)", modeSelected == "RotateObject" ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
        {
            modeSelected = "RotateObject";
            //Put rotation commands here
        }

        if (GUILayout.Button("Scale (R)", modeSelected == "ScaleObject" ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
        {
            modeSelected = "ScaleObject";
            //Put scale commands here
        }

        //Debug.Log(modeSelected);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (selectedObj.CompareTag("Obstacle"))
        {
            if (GUILayout.Button("Move Obstacle (O)", modeSelected == "MoveObstacle" ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
            {
                modeSelected = "MoveObstacle";
                //Obstacle Movement Commands here
            }

            if (GUILayout.Button("Rotate Path (P)", modeSelected == "RotateObstacle" ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
            {
                modeSelected = "RotateObstacle";
                //Obstacle Rotation Commands here
            }

            if (GUILayout.Button("Move Path (I)", modeSelected == "MovePath" ? ToggleButtonStyleToggled : ToggleButtonStyleNormal))
            {
                modeSelected = "MovePath";
                //Obstacle Path movement commands here.
            }
        }
        GUILayout.EndHorizontal();

        DetectAction();
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
        DetectAction();
    }


}
