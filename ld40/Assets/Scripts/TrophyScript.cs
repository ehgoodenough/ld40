using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyScript : MonoBehaviour {

    private TitlesController titles;
    public GameObject finalCanvas;
    private bool complete;

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
        if (theCollision.collider.name.StartsWith("Protag") && !complete)
        {
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            finalCanvas.GetComponent<CanvasGroup>().alpha = 1;
            finalCanvas.GetComponent<CanvasGroup>().interactable = true;
            complete = true;
            titles.win();
            foreach(Renderer rend in GetComponentsInChildren<Renderer>())
            {
                rend.enabled = false;
            }
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 3f);
        }
    }
}
