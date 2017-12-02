using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        Vector3 velocity = Vector3.zero;
        Vector3 moveDirection = Vector3.zero;
        float maxMoveVelocity = 0.2f;
        if (Input.GetKey("a")){
            moveDirection += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            moveDirection += new Vector3(1, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            moveDirection += new Vector3(0, 0, 1);
        }
        if (Input.GetKey("s"))
        {
            moveDirection += new Vector3(0, 0, -1);
        }
        velocity += moveDirection.normalized * maxMoveVelocity;
        position += velocity;
        transform.Translate(position - transform.position);
	}
}
