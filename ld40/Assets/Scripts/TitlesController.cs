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

	public bool hasEarnedTitle(string title) {
		return titles.ContainsKey(title);
	}

	public void earnTitle(string title) {
		if(hasEarnedTitle(title) == false) {
			titles.Add(title, true);
		}
	}
}
