using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntagController : MonoBehaviour {
    Dialogue screenTextAsset;

    // Use this for initialization
    void Start () {
        screenTextAsset = GameObject.Find("Dialogue Text").GetComponent<Dialogue>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        activateDialogue();
    }
    void OnTriggerExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void activateDialogue()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void deactivateDialogue()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
