using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour {

	public GameObject ball;
	private float TRIGGER_DISTANCE = 1f;
    bool complete;

	public string title;
	private TitlesController titles;

    public GameObject linkedDoor;

	void Start() {
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
        complete = false;
	}

	void Update() {
        //Debug.Log(complete);
        if (!complete)
        {
            if (Vector3.Distance(ball.transform.position, transform.position) < TRIGGER_DISTANCE)
            {
                ball.GetComponent<Rigidbody>().isKinematic = true;
                ball.transform.position = transform.position;
                ball.transform.localScale = new Vector3(2f, 2f, 2f);
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip, 1f);

                if (ball.name == "Purple Ball")
                {
                    RampBallController ballScript = ball.GetComponent<RampBallController>();
                    ballScript.Cease();
                }
                else
                {
                    DoorScript doorScript = linkedDoor.GetComponent<DoorScript>();
                    doorScript.unlock();
                }
                titles.earnTitle(title);
                complete = true;
            }
        }
	}
}
