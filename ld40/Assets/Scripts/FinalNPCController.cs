using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNPCController : MonoBehaviour {
    public TextAsset dialogue;
    private Dialogue dialogueUI;


    // Use this for initialization
    void Start () {
        dialogueUI = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Protag")
        {
            dialogueUI.LoadDialogueAsset(dialogue);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Protag")
        {
            dialogueUI.UnloadDialogueAsset();
        }
    }
}
