using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    public GameObject dialogueTextBox;
    private bool scaleDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            
            if(scaleDown == false)
            {

                   if(transform.localScale.x > .012f && transform.localScale.x < .014f)
                    {
		                dialogueTextBox.transform.localScale += new Vector3(0.00005F, 0.00005F, 0);
                    }

                    if(transform.localScale.x > .014f)
                    {
                      scaleDown = true;
                    }
             }


             if(scaleDown)
            {
                               
                dialogueTextBox.transform.localScale -= new Vector3(0.00005F, 0.00005F, 0);
                
                if(transform.localScale.x < 0.0125f)
                   {
                    scaleDown = false;
                   }

            }
	}
}
