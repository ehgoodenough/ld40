using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnHit : MonoBehaviour
{
    AudioSource source;
    AudioClip soundClip;
    float timeSinceSound;
    float minTimeBetweenSounds;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        soundClip = GetComponent<AudioSource>().clip;
        minTimeBetweenSounds = 1;
        timeSinceSound = minTimeBetweenSounds;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSound += Time.deltaTime;
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if(theCollision.collider.name.StartsWith("Protag") && timeSinceSound > minTimeBetweenSounds)
        {
            source.PlayOneShot(soundClip, 1f);
            timeSinceSound = 0;
        }
    }
}
