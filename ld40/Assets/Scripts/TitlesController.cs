using System;
using System.Linq;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlesController : MonoBehaviour {

	private Text score;
	private Text status;

    public GameObject lastDoor;

	private const int MAXIMUM_TITLES = 10;
	private Dictionary<string, bool> titles = new Dictionary<string, bool>();

    ParticleSystem  celebrateGoodTimes;
    private float particleCooldown;


	void Start() {
		this.score = transform.Find("Score").GetComponent<Text>();
		this.status = transform.Find("Status").GetComponent<Text>();
        this.status.text = "Who are you?";
        celebrateGoodTimes = GameObject.Find("Main Camera").GetComponent<ParticleSystem>();
        celebrateGoodTimes.Pause();
    }


	void Update() {

        if(celebrateGoodTimes.isPlaying)
        {
            particleCooldown -= .05f * Time.deltaTime * 60;

            if(particleCooldown <= 0)
            {
                celebrateGoodTimes.Stop();
            }
        }
	}

	public bool hasEarnedTitle(string title) {
		return titles.ContainsKey(title);
	}

	public void earnTitle(string title) {
		if(hasEarnedTitle(title) == false) {
			titles.Add(title, true);

            celebrateGoodTimes.Play();
            particleCooldown = 10;

            foreach (Renderer rend in lastDoor.GetComponentsInChildren<Renderer>())
            {
                float value = Mathf.Max((getTitleCount() - 3)/10.0f, 0);
                rend.material.color = new Color(value, value, value, 1);
            }
            if (getTitleCount() >= 10)
            {
                lastDoor.GetComponent<FinalDoorScript>().Unlock();
            }
            this.score.text = titles.Count + "/" + MAXIMUM_TITLES;

            this.status.text = "You are\n";
            this.status.text += String.Join("\n", titles.Keys.ToArray());
        }


    }

    public int getTitleCount() {
		return titles.Count;
	}

    public void win()
    {
        this.status.text = "\n You are The Winner!";
        this.status.GetComponent<Text>().fontSize = 40;
    }
}
