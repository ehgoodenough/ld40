using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject protag;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = protag.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = protag.transform.position - offset;
	}
}
