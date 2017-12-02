using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Socializer : MonoBehaviour {
    Dialogue screenTextAsset;

	// Use this for initialization
	void Start () {
        screenTextAsset = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
