using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerController : MonoBehaviour {
    float age;
    float lifespan;
    bool saved;
    PusherPuzzleController puzzleScript;

	// Use this for initialization
	void Start () {
        age = 0;
        lifespan = 5;
        saved = false;
        puzzleScript = transform.parent.GetComponent<PusherPuzzleController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!saved)
        {
            age += Time.deltaTime;
            if (age > lifespan)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "TargetZone")
        {
            saved = true;
            GetComponent<Renderer>().material.color = new Color(.6f, .9f, 0, 1);
            puzzleScript.incrementScore();
        }
    }
}
