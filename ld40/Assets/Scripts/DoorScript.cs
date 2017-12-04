using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    Component[] bodies;
    public int keysRequired;
    private int keysSoFar;

    // Use this for initialization
    void Start () {
        keysSoFar = 0;
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
        keysSoFar++;
        if(keysSoFar >= keysRequired)
        {
            foreach (Rigidbody body in bodies)
            {
                body.isKinematic = false;
            }
        }
    }
}
