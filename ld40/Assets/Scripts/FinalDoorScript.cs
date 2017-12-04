using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorScript : MonoBehaviour {
    Rigidbody[] bodies;

	// Use this for initialization
	void Start () {
        bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody body in bodies)
        {
            body.isKinematic = true;
        }
        foreach (Renderer childRend in transform.GetComponentsInChildren<Renderer>())
        {
            childRend.material.color = new Color(0, 0, 0, 1);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Unlock()
    {
        foreach (Rigidbody body in bodies)
        {
            body.isKinematic = false;
        }
        foreach (Renderer childRend in transform.GetComponentsInChildren<Renderer>())
        {
            childRend.material.color = new Color(1, 1, 1, 1);
        }
    }
}
