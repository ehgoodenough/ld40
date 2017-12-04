using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCounterController : MonoBehaviour {
	public TextAsset dialogue;
	private Dialogue dialogueUI;
	private TitlesController titles;
	private Rigidbody body;

	private bool isWithinRange = false;
	private bool hasBeenDefeated = false;

	void Start() {
		dialogueUI = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
		body = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider collider) {
        if(collider.name == "Protag") {
			dialogueUI.LoadDialogueAsset(dialogue);
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.name == "Protag") {
			dialogueUI.UnloadDialogueAsset();
        }
    }

	public void OnDialogueDone() {
		if(titles.getTitleCount() >= 3) {
			if(hasBeenDefeated == false) {
				hasBeenDefeated = true;
				body.isKinematic = false;
				body.AddTorque(Vector3.up * 50f);
				body.AddTorque(Vector3.right * 300f);
				body.AddForce((Vector3.back * -1000f));
			}
		}
	}
}
