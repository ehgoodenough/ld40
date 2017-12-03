using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour {

	public GameObject ball;
	private float TRIGGER_DISTANCE = 1f;

	public string title;
	private TitlesController titles;

	void Start() {
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
	}

	void Update() {
		if(Vector3.Distance(ball.transform.position, transform.position) < TRIGGER_DISTANCE) {
			ball.GetComponent<Rigidbody>().isKinematic = true;
			ball.transform.position = transform.position;
			ball.transform.localScale = new Vector3(2f, 2f, 2f);

			titles.earnTitle(title);
		}
	}
}
