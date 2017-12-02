using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameGuesser : MonoBehaviour {

	Text title;
	bool isWaiting = false;

	void Start() {
		this.title = GetComponent<Text>();

		this.isWaiting = true;
		this.title.text = "YOU ARE\n";
	}

	void Update() {
		if(this.isWaiting) {
			if(Input.anyKeyDown) {
				this.isWaiting = false;
				this.title.text = "I am";
				this.title.text += "\n";
			}
		} else {
			if(Input.GetKeyDown("q")) {
				this.title.text += "Queen in the North";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("w")) {
				this.title.text += "Wisher of the Well";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("e")) {
				this.title.text += "Enemy of all Evil";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("r")) {
				this.title.text += "Regent of the Land";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("t")) {
				this.title.text += "True Knight";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("y")) {
				this.title.text += "Your Worst Nightmare";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("u")) {
				this.title.text += "Uuh";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("i")) {
				this.title.text += "Invoker of the Great Words";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("o")) {
				this.title.text += "Orator of Legends";
				this.title.text += "\n";
			}
			if(Input.GetKeyDown("p")) {
				this.title.text += "Pillar of Destiny";
				this.title.text += "\n";
			}
		}
	}
}
