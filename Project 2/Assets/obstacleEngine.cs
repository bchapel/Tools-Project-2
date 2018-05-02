using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleEngine : MonoBehaviour {

    public float defaultDistance = 3f;
    private Vector3 startPos;
    private Vector3 endPos;

    private GameObject go;

	// Use this for initialization
	void Start () {


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(startPos, 0.5f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(endPos, 0.4f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
