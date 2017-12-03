using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCounterController : MonoBehaviour {
	public TextAsset dialogue;
	private Dialogue dialogueUI;

	void Start() {
		dialogueUI = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
	}

	void OnTriggerEnter(Collider collider) {
        if(collider.name == "Protag") {
            dialogueUI.LoadDialogueAsset(dialogue);
        }
    }
}
