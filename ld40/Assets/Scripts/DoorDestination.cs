using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestination : MonoBehaviour {
    private TitlesController titles;

    // Use this for initialization
    void Start () {
        titles = GameObject.Find("Titles").GetComponent<TitlesController>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Protag")
        {
            titles.earnTitle("The Threshold Traverser");
        }
    }
}
