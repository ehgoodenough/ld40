using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagController : MonoBehaviour {
    Rigidbody body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        Vector3 velocity = Vector3.zero;
        Vector3 moveDirection = Vector3.zero;
        float maxMoveVelocity = 14f;
        moveDirection += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        velocity += moveDirection.normalized * maxMoveVelocity;
        body.AddForce(velocity);
	}
}
