using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampBallController : MonoBehaviour
{
    float age;
    float lifespan;
    bool ceased;
    Vector3 startingPosition;

    // Use this for initialization
    void Start()
    {
        startingPosition = transform.position;
        age = 0;
        lifespan = 8;
        ceased = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ceased)
        {
            age += Time.deltaTime;
            if (age > lifespan)
            {
                transform.position = startingPosition;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                age = 0;
            }
        }
    }

    public void Cease()
    {
        ceased = true;
    }
}
