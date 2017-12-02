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
        transform.GetChild(0).gameObject.SetActive(true) ;
    }
    void OnTriggerExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
