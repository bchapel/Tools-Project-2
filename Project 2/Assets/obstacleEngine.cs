using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleEngine : MonoBehaviour
{
    [Tooltip("Distance from center of track to track end points.")]
    public float defaultDistance = 3f;
    [HideInInspector]
    public GameObject startPos ;
    [HideInInspector]
    public GameObject endPos;
    [HideInInspector]
    public float moveSpeed = 2f;
    [Tooltip("Starting Direction of travel.")]
    public bool startDir;


    // Use this for initialization
    [ExecuteInEditMode]
    void Start()
    {
        startPos = transform.parent.GetChild(1).gameObject;
        endPos = transform.parent.GetChild(2).gameObject;
    }

    private void OnDrawGizmos()
    {
        startPos = transform.parent.GetChild(1).gameObject;
        endPos = transform.parent.GetChild(2).gameObject;
        if (startDir)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPos.transform.position, 0.25f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(endPos.transform.position, 0.25f);
        }

        else if (!startDir)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(endPos.transform.position, 0.25f);

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(startPos.transform.position, 0.25f);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (startDir)
        {
            Debug.Log("Moving To start");
            transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(startPos.transform.position, transform.position) <= 0.1f)
            {
                startDir = false;
            }

        }
        else if (!startDir)
        {
            Debug.Log("Moving to End");
            transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(endPos.transform.position, transform.position) <= 0.1f)
                startDir = true;
        }
    }
}
