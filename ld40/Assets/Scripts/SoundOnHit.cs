using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHit : MonoBehaviour
{
    AudioSource source;
    AudioClip soundClip;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        soundClip = GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision theCollision)
    {
        source.PlayOneShot(soundClip, 1f);
    }
}
