using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseBreaker : MonoBehaviour {

	private TitlesController titles;
    public GameObject door;
    bool complete;

	// Use this for initialization
	void Start () {
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
        complete = false;
	}

	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision theCollision)
    {
        if (!complete)
        {
            if (theCollision.collider.name != "Pedestal")
            {
                titles.earnTitle("Breaker of Vases");
                door.GetComponent<DoorScript>().unlock();
                GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                complete = true;
            }
        }
    }
}
