﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagController : MonoBehaviour {
    Rigidbody body;
    float moveForce;
    float maxVelocity;
    List<GameObject> keys;

    GameObject playerInventory;
    private bool faded;

    private TitlesController titles;

    GameObject slotPanel;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        maxVelocity = 33f;
    
        keys = new List<GameObject>();
        playerInventory = GameObject.Find("InventoryGrid");
        playerInventory.GetComponent<CanvasGroup>().alpha = 0f;

        titles = GameObject.Find("Titles").GetComponent<TitlesController>();
        slotPanel = GameObject.Find("Slot Panel");

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        Vector3 inputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        float moveForce = Mathf.Max((maxVelocity - body.velocity.magnitude), 0);
        if (inputVelocity.magnitude > 0.99f)
        {
            body.drag = 1;
            body.AddForce(inputVelocity*moveForce*Time.deltaTime*60);
        } else
        {
            body.drag = 4;
        }
        if(body.velocity.magnitude > 0.5f)
        {
            transform.LookAt(transform.position + body.velocity);
        }

        fadeOut();
            
 //       Debug.Log(keys.Count);
 //         Debug.Log(faded);

    }

    void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "collectible")
		{
            AudioSource source = coll.collider.GetComponent<AudioSource>();
            source.PlayOneShot(source.clip, 0.5f);
            coll.collider.GetComponent<BoxCollider>().enabled = false;
            foreach(Renderer renderer in coll.gameObject.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false;
            }

			    //Debug.Log("collect it ");
                
                playerInventory.GetComponent<CanvasGroup>().alpha = 1f;
                faded = false;
                Destroy(coll.gameObject, 3f);
                
                if(keys.Count > 0)
                {
                GameObject newSlot = Instantiate(GameObject.Find("Slot"));
                //newSlot.transform.parent = GameObject.Find("Slot Panel").transform;
                newSlot.transform.SetParent(slotPanel.transform, false);
                newSlot.transform.localScale = new Vector3(4, 3, 1);
                keys.Add(newSlot);
                } else {
                        keys.Add(GameObject.Find("Slot"));
                        titles.earnTitle("Collector of Things");                                                
                        }
            //if(coll.gameObject.tag == "key")
                if(keys.Count == 5)
                {
                    titles.earnTitle("Le Charmant Collector");
                            
                }

		}                 
          
    }
         // fading out the alpha of the canvas
         void fadeOut()  {
                            
                            if(faded)
                                return;
                        
                            if(!faded) 
                                    {
                                    playerInventory.GetComponent<CanvasGroup>().alpha -= .005f * Time.deltaTime * 60;
                                    // Debug.Log("it is fading");
                                    }

                             if(playerInventory.GetComponent<CanvasGroup>().alpha <= .001f)
                                    {
                                        faded = true;
                                
                                    }
                             
                                      
                          } 
}
