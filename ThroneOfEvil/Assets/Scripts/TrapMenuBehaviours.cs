using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMenuBehaviours : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*Vector3 mousePosition,targetPosition;
	public float distance = 10f;

	void Start(){
		
	}

//might need to just instantiate in trap controller and then have it follow mouse then once changed then it will destroy and instantiate again.
	void Update () {
		//To get the current mouse position
		mousePosition = Input.mousePosition;

		//Convert the mousePosition according to World position
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy")) {
			Destroy (other.gameObject);
		} else {
			Destroy (gameObject, 5);
		}
	}*/
}
