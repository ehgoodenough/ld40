//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FadeOut : MonoBehaviour {

//    public GameObject InventoryGrid;
//    public GameObject player;
//    private bool fadeOutTrigger;
//    public bool faded;

//	// Use this for initialization
//	void Start () {
		        

//	}
	
//	// Update is called once per frame
//	void Update () {
//		fadeOut();

//        if(gameObject.transform.parent.transform.parent.GetComponent<CanvasGroup>().alpha <= .001f)
//        {
//            gameObject.transform.parent.transform.parent.SetActive(false);
//            Debug.Log("totally faded out, man");
//        }
//	}

//    void fadeOut()
//	{
//		if (!gameObject.activeSelf)
//			return;

//        transform.parent.transform.parent.GetComponent<CanvasGroup>().alpha -= .05f;


//		//if (fadeOutTrigger && coolDown <= 0) 
//		//{
//		//	coolDownTime = (int)coolDown;
//		//}

//		//if (coolDown > 0)
//		//{
//		//	coolDown -= Time.deltaTime;
//		//}

//		//if(coolDown <= 0)
//		//{
//		//	fadeOutTrigger = false;
//		//}
//	}
//}
