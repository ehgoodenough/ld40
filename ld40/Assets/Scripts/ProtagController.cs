using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagController : MonoBehaviour {
    Rigidbody body;
    float moveForce;
    float maxVelocity;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        maxVelocity = 30f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        Vector3 inputVelocity = Vector3.zero;
        Vector3 moveDirection = Vector3.zero;
        inputVelocity += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = inputVelocity.normalized;
        float moveForce = Mathf.Max((maxVelocity - body.velocity.magnitude), 0);
        if (inputVelocity.magnitude > 0.99f)
        {
            body.drag = 1;
            body.AddForce(inputVelocity*moveForce);
        } else
        {
            body.drag = 4;
        }
        if(body.velocity.magnitude > 0.1f)
        {
            transform.LookAt(transform.position + body.velocity);
        }
    }
}
