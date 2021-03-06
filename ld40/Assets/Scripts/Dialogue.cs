﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour {

    const float TRIGGER_DISTANCE = 2f;

    private Text _textComponent;

    public float scrollSpeed = 0.05f;
    public float speedupRate = 0.5f;

    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    private bool _isEndofDialogue = false;

    public GameObject continueText;
    public GameObject stopText;

    private GameObject dialoguePanel;


    private List<string> Strings = new List<string>();

	// Use this for initialization
	void Start () {
		_textComponent = GetComponent<Text>();
        _textComponent.text = " ";

        //// Try to read from the file, if one was given.
        //if(DialogueFile != "") {
        //    string line;
        //    StreamReader reader = new StreamReader(DialogueFile);
        //    while((line = reader.ReadLine()) != null) {
        //        Strings.Add(line);
        //    }
        //    reader.Close();
        //}
        transform.parent.transform.parent.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void LoadDialogueAsset (TextAsset asset) {
        Strings.Clear();
        transform.parent.transform.parent.GetComponent<CanvasGroup>().alpha = 1;
        string[] lines = asset.text.Split('\n');
        foreach(string line in lines) {
            if(line.Length > 0) {
                Strings.Add(line);
            }
        }
    }

    public void UnloadDialogueAsset ()
    {
        transform.parent.transform.parent.GetComponent<CanvasGroup>().alpha = 0;
        _isDialoguePlaying = false;
    }

	// Update is called once per frame
	void Update()
    {

        if(Input.GetKey("space") && Strings.Count > 0)
        {
            if(!_isDialoguePlaying)
            {
                _isDialoguePlaying = true;
                StartCoroutine(StartDialogue());
            }
        }
    }

    private IEnumerator StartDialogue()
    {
        int dialogueLength = Strings.Count;
        int currentDialogueIndex = 0;


        while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed )
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                StartCoroutine(DisplayString(Strings[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength)
                {
                    _isEndofDialogue = true;
                }
            }

            yield return 0;

        }

        while (true)
        {
            if (Input.GetKey("space"))
            {
                break;
            }

            yield return 0;

        }

        HideStuff();
        _isEndofDialogue = false;
        _isDialoguePlaying = false;

    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = stringToDisplay.IndexOf("]") + 1;

        if(stringToDisplay[0] == '[') {
            string[] commands = stringToDisplay.Substring(1, stringToDisplay.IndexOf("]") - 1).Split(',');
            if(GameObject.Find("RawImage") != null) {
                RawImage avatar = GameObject.Find("RawImage").GetComponent<RawImage>();
                avatar.texture = Resources.Load(commands[0]) as Texture;
            }
        }

        HideStuff();

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey("space"))
                {
                    yield return new WaitForSeconds(scrollSpeed * speedupRate);
                }
                else
                {
                    yield return new WaitForSeconds(scrollSpeed);
                }
            }

            else
            {
                break;
            }
        }

        ShowIcon();

        while (true)
        {
            if (Input.GetKey("space"))
            {
                break;
            }

            yield return 0;
        }

        HideStuff();

        _isStringBeingRevealed = false;
        _textComponent.text = "";
        _isEndofDialogue = true;

    }



    private void HideStuff()
    {
        continueText.SetActive(false);
        stopText.SetActive(false);
    }

    private void ShowIcon()
    {
        if (_isEndofDialogue)
        {
            stopText.SetActive(true);
            Debug.Log("this happened");
            return;
        }

        continueText.SetActive(true);
    }

}
