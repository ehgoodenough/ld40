using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    Component[] bodies;
    public int keysRequired;
    private int keysSoFar;
    public AudioClip unlockSound;
    private bool unlocked;
    public AudioClip onHitSound;

    // Use this for initialization
    void Start () {
        keysSoFar = 0;
        bodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody body in bodies)
        {
            body.isKinematic = true;
        }
        foreach(Renderer childRend in transform.GetComponentsInChildren<Renderer>())
        {
            childRend.material.color = new Color(0, 0, 0, 1);
        }
        unlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void unlock()
    {
        keysSoFar += 1;
        if (keysSoFar >= keysRequired && !unlocked)
        {
            foreach (Rigidbody body in bodies)
            {
                body.isKinematic = false;
            }
            foreach (Renderer childRend in transform.GetComponentsInChildren<Renderer>())
            {
                childRend.material.color = new Color(1, 1, 1, 1);
            }
            GetComponent<AudioSource>().PlayOneShot(unlockSound, 1);
            Debug.Log(unlockSound);
            GameObject.Find("TitleCounter").transform.GetChild(0).gameObject.SetActive(false);
            unlocked = true;
            foreach (Transform child in transform)
            {
                if (child.name == "DoorRight" || child.name == "DoorLeft")
                {
                    child.gameObject.AddComponent<SoundOnHit>();
                    child.GetComponent<AudioSource>().clip = onHitSound;
                }
            }
        }
    }
}
