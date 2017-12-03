using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBlockController : MonoBehaviour {

	public GameObject biglBlock;
	public GameObject uBlock;

	public GameObject biglBlockExpected;
	public GameObject uBlockExpected;

	private TitlesController titles;

	void Start() {
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
	}

	void Update() {
		// Get the position relative to this small-l-block.
		Vector3 biglDifference = biglBlock.transform.position - transform.position;
		Vector3 uDifference = uBlock.transform.position - transform.position;

		// Get the difference between these blocks and the expected blocks.
		biglDifference = biglBlockExpected.transform.localPosition - biglDifference;
		uDifference = uBlockExpected.transform.localPosition - uDifference;

		if(Mathf.Abs(biglDifference.x) < 0.25
		&& Mathf.Abs(biglDifference.z) < 0.25
		&& Mathf.Abs(uDifference.x) < 0.25
		&& Mathf.Abs(uDifference.z) < 0.25) {
			titles.earnTitle("Master Crest Builder");

			// Destroy(GetComponent<Rigidbody>());
			// Destroy(biglBlock.GetComponent<Rigidbody>());
			// Destroy(uBlock.GetComponent<Rigidbody>());
		}
	}
}
