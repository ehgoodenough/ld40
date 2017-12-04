using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestination : MonoBehaviour {
    private TitlesController titles;
    public GameObject linkedDoor;

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
            DoorScript doorScript = linkedDoor.GetComponent<DoorScript>();
            doorScript.unlock();
            titles.earnTitle("The Threshold Traverser");
            Destroy(gameObject);
        }
    }
}
