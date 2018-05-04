using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerIdleMode : MonoBehaviour {

	public float _speed = 5;
	public Transform target;
	//private float _angleOffset = -90; //was -90
	public float timedelay = 2f;
	public float XMin1 = -16;
	public float XMax1 = 13;
	public float YMin1 = -6;
	public float YMax1 = 4.7f;
	public float timetodelay;

	// Use this for initialization
	void Start () {
		/*XMin = -16;
		XMax = 13;
		YMin = -6;
		YMax = 4.7f;*/
		timetodelay = Random.Range (0, 5);
		_speed = Random.Range (1, 3); //want them to move first so 0 not called
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dir = target.position - transform.position; //was target.transform.position
		//float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis(angle + _angleOffset, Vector3.forward);*/
		if (transform.position.y >= YMax1 || transform.position.y <= YMin1) {
			transform.position = Vector3.MoveTowards (transform.position, -target.position, _speed * Time.deltaTime);
		} else {
			transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
		}
		if(dir.x < 0){
			gameObject.GetComponent<ClothingController>().villagerOrientation = "left";
		}else if (dir.x > 0){
			gameObject.GetComponent<ClothingController>().villagerOrientation = "right";
		}

		if (Time.time > timedelay && !gameObject.CompareTag("FrozenEnemy")) {
			timedelay = Time.time + timetodelay;
			target.position =  new Vector3 (Random.Range (XMin1, XMax1), Random.Range (YMin1, YMax1), 0.0f);
			timetodelay = Random.Range (0, 5);
			_speed = Random.Range (0, 3);
			XMin1 -= 0.5f;
			//wayPoints.position =  new Vector3 (Random.Range (1, 8), Random.Range (1, 8), 0.0f);
			//target = wayPoints;
		}
	}
	public void CheckForTag(){
		if (gameObject.CompareTag("Enemy")) {
			_speed = 2f;
		} else if (gameObject.CompareTag("FrozenEnemy")) {
			_speed = 0f;
			//Debug.Log("Enemy is frozen!");
		} else if (gameObject.CompareTag("TarredEnemy")) {
			_speed = 0.5f;
			//Debug.Log("Enemy is tarred!");
		} else if (gameObject.CompareTag("BurningEnemy")) {
			/*SwitchLanes ();
			MultiplySpeed(RunningAroundOnfireSpeed, 0f);
			gameObject.GetComponent<ClothingController>().villagerOrientation = "left";*/
			_speed = 1f;
			Debug.Log("Enemy is burning!");
		} else {
			Debug.Log ("Enemy CheckForTag() failed!");
			return;
		}
	}
}
