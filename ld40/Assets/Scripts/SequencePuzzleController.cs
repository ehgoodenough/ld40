using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePuzzleController : MonoBehaviour {
    bool[] pillarStates;
    private TitlesController titles;

    // Use this for initialization
    void Start () {
        pillarStates = new bool[] { false, false, false, false, false, false, false };
        titles = GameObject.Find("Titles").GetComponent<TitlesController>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ActivatePillar(int index)
    {
        bool trueSoFar = true;
        for(var i = 0; i < index; i++)
        {
            if (!pillarStates[i])
            {
                trueSoFar = false;
            }
        }
        if (trueSoFar)
        {
            pillarStates[index] = true;
            GetComponent<AudioSource>().pitch = index / 3.0f + 0.5f;
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
        else
        {
            ResetPillars();
        }


        bool allActive = true;
        foreach(bool state in pillarStates)
        {
            if (!state)
            {
                allActive = false;
            }
        }
        if (allActive)
        {
            titles.earnTitle("Savvy Sequencer");
        }
    }

    void ResetPillars()
    {
        pillarStates = new bool[] { false, false, false, false, false, false, false };
        PillarController[] childScripts = GetComponentsInChildren<PillarController>();
        foreach(PillarController script in childScripts)
        {
            script.Deactivate();
        }
    }
}
