using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBlockController : MonoBehaviour {

	public GameObject biglBlock;
	public GameObject uBlock;

	public GameObject biglBlockExpected;
	public GameObject uBlockExpected;

    public AudioClip soundOnComplete;
    public AudioClip soundPreMatch;
    private AudioSource source;
    private bool complete;

	private TitlesController titles;

	void Start() {
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
        source = GetComponent<AudioSource>();
        complete = false;
	}

	void Update() {
		// Get the position relative to this small-l-block.
		Vector3 biglDifference = biglBlock.transform.position - transform.position;
		Vector3 uDifference = uBlock.transform.position - transform.position;

		// Get the difference between these blocks and the expected blocks.
		biglDifference = biglBlockExpected.transform.localPosition - biglDifference;
		uDifference = uBlockExpected.transform.localPosition - uDifference;

        if (!complete)
        {
            float sumDiff = Mathf.Abs(biglDifference.x) + Mathf.Abs(biglDifference.z) + Mathf.Abs(uDifference.x) + Mathf.Abs(uDifference.z);
            source.volume = Mathf.Max((4.0f - sumDiff), 0.0f) / 4.0f;
        }

        if (Mathf.Abs(biglDifference.x) < 0.25
		&& Mathf.Abs(biglDifference.z) < 0.25
		&& Mathf.Abs(uDifference.x) < 0.25
		&& Mathf.Abs(uDifference.z) < 0.25
        && !complete) {
			titles.earnTitle("Master Crest Builder");
            source.Stop();
            source.volume = 0.5f;
            source.PlayOneShot(soundOnComplete);
            complete = true;
			// Destroy(GetComponent<Rigidbody>());
			// Destroy(biglBlock.GetComponent<Rigidbody>());
			// Destroy(uBlock.GetComponent<Rigidbody>());
		}
	}
}
