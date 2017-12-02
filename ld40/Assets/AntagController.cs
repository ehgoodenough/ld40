using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntagController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
    }
}
