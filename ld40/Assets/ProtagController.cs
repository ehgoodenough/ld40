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
        if (Input.GetKey("a")){
            velocity += new Vector3(-0.2f, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            velocity += new Vector3(0.2f, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            velocity += new Vector3(0, 0, 0.2f);
        }
        if (Input.GetKey("s"))
        {
            velocity += new Vector3(0, 0, -0.2f);
        }
        position += velocity;
        transform.Translate(position - transform.position);
	}
}
