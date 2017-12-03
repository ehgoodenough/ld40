using System;
using System.Linq;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlesController : MonoBehaviour {

	private Text score;
	private Text status;

	private const int MAXIMUM_TITLES = 10;
	private Dictionary<string, bool> titles = new Dictionary<string, bool>();

	void Start() {
		this.score = transform.Find("Score").GetComponent<Text>();
		this.status = transform.Find("Status").GetComponent<Text>();
	}

	void Update() {
		this.score.text = titles.Count + "/" + MAXIMUM_TITLES;

		if(titles.Count == 0) {
			this.status.text = "Who are you?";
		} else {
			this.status.text = "You are ";
			this.status.text += String.Join(", ", titles.Keys.ToArray());
		}
	}

	public bool hasEarnedTitle(string title) {
		return titles.ContainsKey(title);
	}

	public void earnTitle(string title) {
		if(hasEarnedTitle(title) == false) {
			titles.Add(title, true);
		}
	}

	public int getTitleCount() {
		return titles.Count;
	}
}
