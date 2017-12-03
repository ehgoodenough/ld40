using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherPuzzleController : MonoBehaviour {

    public GameObject Roller;
    public float timeSinceRoller;
    public float timeBetweenRollers;
    public float score;
    private TitlesController titles;
    private bool complete;

    // Use this for initialization
    void Start () {
        timeSinceRoller = 0;
        timeBetweenRollers = 3;
        score = 0;
        titles = GameObject.Find("Titles").GetComponent<TitlesController>();
        complete = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!complete)
        {
            timeSinceRoller += Time.deltaTime;
            if (timeSinceRoller > timeBetweenRollers)
            {
                GameObject newRoller = Instantiate(Roller, transform.position + new Vector3(4.15f, 4, -1), Quaternion.identity);
                newRoller.transform.parent = transform;
                timeSinceRoller = 0;
            }
        }
	}

    public void incrementScore()
    {
        score++;
        if(score >= 5)
        {
            complete = true;
            titles.earnTitle("The Periodic Pusher");
        }
    }
}
