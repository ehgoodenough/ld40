using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverController : MonoBehaviour {

	public GameObject otherLover;
	private float TRIGGER_DISTANCE = 5f;

	private TitlesController titles;
	private Dialogue dialogueUI;

	public TextAsset firstDialogue;
	public TextAsset secondDialogue;

	private bool hasBeenTalkedToByThem = false;

	void Start() {
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
		dialogueUI = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
	}

	void Update() {
		if(Vector3.Distance(otherLover.transform.position, transform.position) < TRIGGER_DISTANCE) {
			hasBeenTalkedToByThem = true;
            LoverController otherScript = otherLover.GetComponent<LoverController>();
            removeAlert();
            otherScript.removeAlert();
			titles.earnTitle("Master Matchmaker");
		}
	}

	void OnTriggerEnter(Collider other) {
        if(other.name == "Protag") {
			if(hasBeenTalkedToByThem == false) {
				dialogueUI.LoadDialogueAsset(firstDialogue);
			}
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.name == "Protag") {
            dialogueUI.UnloadDialogueAsset();
        }
    }

    public void removeAlert()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
