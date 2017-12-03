using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCounterController : MonoBehaviour {
	public TextAsset dialogue;
	private Dialogue dialogueUI;
	private TitlesController titles;
	private Rigidbody rigidbody;

	private bool isWithinRange = false;
	private bool hasBeenDefeated = false;

	void Start() {
		dialogueUI = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update() {
		if(isWithinRange) {
			if(Input.GetKeyDown("space")) {

				if(titles.getTitleCount() >= 3) {
					if(hasBeenDefeated == false) {
						hasBeenDefeated = true;
						rigidbody.isKinematic = false;
						rigidbody.AddTorque(Vector3.up * 50f);
		   				rigidbody.AddTorque(Vector3.right * 300f);
						rigidbody.AddForce((Vector3.back * -1000f));
					}
					Debug.Log("Good!!");
				} else {
					Debug.Log("Not yet :\\");
				}
			}
		}
	}

	void OnTriggerEnter(Collider collider) {
        if(collider.name == "Protag") {
			dialogueUI.LoadDialogueAsset(dialogue);
			isWithinRange = true;
        }
    }

	void OnTriggerExit(Collider collider) {
        if(collider.name == "Protag") {
			dialogueUI.UnloadDialogueAsset();
			isWithinRange = false;
        }
    }
}
