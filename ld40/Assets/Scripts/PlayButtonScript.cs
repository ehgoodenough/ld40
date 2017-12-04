using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.text = "Play!";
        text.fontSize = 50;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
}
