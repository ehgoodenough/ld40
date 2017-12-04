using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour {
    SequencePuzzleController puzzleScript;
    GameObject sphere;

	// Use this for initialization
	void Start () {
        puzzleScript = transform.parent.transform.GetComponent<SequencePuzzleController>();
        sphere = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision theCollision)
    {
        if(theCollision.collider.name.StartsWith("Protag"))
        {
            sphere.transform.localScale = new Vector3(3, 3, 3);
            puzzleScript.ActivatePillar((int)char.GetNumericValue(this.name[this.name.Length - 1]));
        }
    }

    public void Deactivate()
    {
        sphere.transform.localScale = new Vector3(1, 1, 1);
    }
}
