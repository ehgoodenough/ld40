﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBoxer : MonoBehaviour {
    GameObject titles;

	// Use this for initialization
	void Start () {
        titles = GameObject.Find("Titles");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Protag")
        {
            titles.GetComponent<TitlesController>().win();
        }
    }
}
