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
        if (Input.GetKey("A")){

        }
        position += velocity;
        transform.Translate(position - transform.position);
	}
}
