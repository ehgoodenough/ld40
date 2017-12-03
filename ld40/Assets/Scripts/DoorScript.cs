using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    Component[] bodies;

    // Use this for initialization
    void Start () {
        bodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody body in bodies)
        {
            body.isKinematic = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void unlock()
    {
        foreach(Rigidbody body in bodies)
        {
            body.isKinematic = false;
        }
    }
}
