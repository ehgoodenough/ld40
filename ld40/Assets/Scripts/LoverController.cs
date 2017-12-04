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

    private bool complete;

	private bool hasBeenTalkedToByThem = false;

	void Start() {
		titles = GameObject.Find("Titles").GetComponent<TitlesController>();
		dialogueUI = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
        complete = false;
	}

	void Update() {
		if(Vector3.Distance(otherLover.transform.position, transform.position) < TRIGGER_DISTANCE && !complete) {
			hasBeenTalkedToByThem = true;
            LoverController otherScript = otherLover.GetComponent<LoverController>();
            removeAlert();
            otherScript.removeAlert();
            Destroy(otherScript);
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip, 0.5f);
            complete = true;
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
