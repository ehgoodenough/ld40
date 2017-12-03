using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlesController : MonoBehaviour {

	private Text ui;

	private const int MAXIMUM_TITLES = 10;
	private Dictionary<string, bool> titles = new Dictionary<string, bool>();

	void Start() {
		this.ui = transform.Find("Text").GetComponent<Text>();
	}

	void Update() {
		this.ui.text = titles.Count + "/" + MAXIMUM_TITLES;
	}

	public void earnTitle(string title) {
		if(!titles.ContainsKey(title)) {
			titles.Add(title, true);
		}
	}
}
