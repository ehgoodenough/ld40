using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseBreaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision theCollision)
    {
        if(theCollision.collider.name != "Pedestal")
        {
            GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
    }
}
