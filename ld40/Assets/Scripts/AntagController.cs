using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntagController : MonoBehaviour {
    public TextAsset myDialogue;
    Dialogue screenTextAsset;

    // Use this for initialization
    void Start () {
        screenTextAsset = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Protag")
        {
            ActivateDialogue();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Protag")
        {
            DeactivateDialogue();
        }
    }

    public void ActivateDialogue()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        screenTextAsset.LoadDialogueAsset(myDialogue);
    }
    public void DeactivateDialogue()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        screenTextAsset.UnloadDialogueAsset();
    }
}
