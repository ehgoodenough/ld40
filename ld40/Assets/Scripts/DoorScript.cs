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
        foreach(Renderer childRend in transform.GetComponentsInChildren<Renderer>())
        {
            childRend.material.color = new Color(0, 0, 0, 1);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void unlock()
    {
        keysSoFar += 1;
        if(keysSoFar >= keysRequired)
        {
            foreach (Rigidbody body in bodies)
            {
                body.isKinematic = false;
            }
            foreach (Renderer childRend in transform.GetComponentsInChildren<Renderer>())
            {
                childRend.material.color = new Color(1, 1, 1, 1);
            }
            GameObject.Find("TitleCounter").transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
