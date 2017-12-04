using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorScript : MonoBehaviour {
    Rigidbody[] bodies;
    public AudioClip unlockSound;
    private bool unlocked;
    public AudioClip onHitSound;

    // Use this for initialization
    void Start () {
        bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody body in bodies)
        {
            body.isKinematic = true;
        }
        foreach (Renderer childRend in transform.GetComponentsInChildren<Renderer>())
        {
            childRend.material.color = new Color(0, 0, 0, 1);
        }
        unlocked = false;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Unlock()
    {
        if (!unlocked)
        {
            foreach (Rigidbody body in bodies)
            {
                body.isKinematic = false;
            }
            foreach (Renderer childRend in transform.GetComponentsInChildren<Renderer>())
            {
                childRend.material.color = new Color(1, 1, 1, 1);
            }
            GetComponent<AudioSource>().PlayOneShot(unlockSound);
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
