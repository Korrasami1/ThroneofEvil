using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VillagerIdleMode : MonoBehaviour {

	public float _speed = 5;
	public Transform target;
	public Transform[] fearPositions;
	//private float _angleOffset = -90; //was -90
	public float timedelay = 2f;
	public float XMin1 = -16;
	public float XMax1 = 13;
	public float YMin1 = -6;
	public float YMax1 = 4.7f;
	public float timetodelay;
	bool switchstate;
	List<Vector3> paths;
	Vector3[] shortestPaths;

	// Use this for initialization
	void Start () {
		/*XMin = -16;
		XMax = 13;
		YMin = -6;
		YMax = 4.7f;*/
		paths = new List<Vector3> ();
		timetodelay = Random.Range (0, 5);
		_speed = Random.Range (1, 3); //want them to move first so 0 not called
		switchstate = false;
		for(int i = 0; i < fearPositions.Length; i++){
			if (fearPositions [i].CompareTag("SafeSpot")) {
				Vector3 temp = fearPositions [i].localPosition;
				paths.Add (temp);
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dir = target.position - transform.position; //was target.transform.position
		//this mathf.clamp allows me to create boundaries for the enemies to reside in.
		transform.position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, XMin1, XMax1), Mathf.Clamp(GetComponent<Rigidbody>().position.y, YMin1, YMax1), 0.0f);
		transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
		if(dir.x < 0){
			gameObject.GetComponent<ClothingController>().villagerOrientation = "left";
		}else if (dir.x > 0){
			gameObject.GetComponent<ClothingController>().villagerOrientation = "right";
		}

		if (Time.time > timedelay && switchstate == false) {
			timedelay = Time.time + timetodelay;
			target.position =  new Vector3 (Random.Range (XMin1, XMax1), Random.Range (YMin1, YMax1), 0.0f);
			timetodelay = Random.Range (0, 5);
			_speed = Random.Range (0, 3);
			//wayPoints.position =  new Vector3 (Random.Range (1, 8), Random.Range (1, 8), 0.0f);
			//target = wayPoints;
		}
	}
	public void moveAway(){
		transform.position = Vector3.MoveTowards (transform.position, -target.position, _speed * Time.deltaTime);
	}
	public void CheckForTag(){
		if (gameObject.CompareTag("Enemy")) {
			switchstate = false;
			_speed = 2f;
		} else if (gameObject.CompareTag("FrozenEnemy")) {
			switchstate = true;
			_speed = 0f;
			//Debug.Log("Enemy is frozen!");
		} else if (gameObject.CompareTag("TarredEnemy")) {
			switchstate = true;
			_speed = 0.5f;
			//Debug.Log("Enemy is tarred!");
		} else if (gameObject.CompareTag("BurningEnemy")) {
			switchstate = true;
			_speed = 1f;
			Debug.Log("Enemy is burning!");
		}else if (gameObject.CompareTag("FearedEnemy")) {
			switchstate = true;
			randomiseFearLocation ();
			_speed = 3f;
		} else {
			Debug.Log ("Enemy CheckForTag() failed!");
			return;
		}
	}
	public Vector3 randomiseFearLocation(){
		shortestPaths = GetShortestPath(2);
		int num = Random.Range (1, 3); //has be from 1 to number of fearpotions+1 otherwise it will only choose number 1 to fearpotions -1 

		switch (num)
		{
		case 1:
			target.position = shortestPaths [0];
			break;
		case 2:
			target.position = shortestPaths [1];
			break;
		case 3:
			//target.position = fearPositions [2].position;
			break;
		case 4:
			//target.position = fearPositions [3].position;
			break;
		case 5:
			//target.position = fearPositions [4].position;
			break;
		case 6:
			//target.position = fearPositions [5].position;
			break;
		}

		return target.position;
	}
	Vector3[] GetShortestPath(int top3){
		return paths.OrderBy (x => Vector3.Distance(this.transform.position, x)).Take (top3).ToArray <Vector3> ();
	}
}
