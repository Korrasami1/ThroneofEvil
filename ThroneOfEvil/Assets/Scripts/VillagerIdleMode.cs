﻿using System.Collections;
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

	// Use this for initialization
	void Start () {
		/*XMin = -16;
		XMax = 13;
		YMin = -6;
		YMax = 4.7f;*/
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dir = target.position - transform.position; //was target.transform.position
		//float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis(angle + _angleOffset, Vector3.forward);*/
		transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
		if(dir.x < 0){
			gameObject.GetComponent<ClothingController>().villagerOrientation = "left";
		}else if (dir.x > 0){
			gameObject.GetComponent<ClothingController>().villagerOrientation = "right";
		}
		/*if(dir.y < 0){
			gameObject.GetComponent<ClothingController>().villagerOrientation = "front";
		}else if (dir.y > 0){
			gameObject.GetComponent<ClothingController>().villagerOrientation = "back";
		}*/

		if (Time.time > timedelay) {
			timedelay = Time.time + 2f;
			target.position =  new Vector3 (Random.Range (XMin1, XMax1), Random.Range (YMin1, YMax1), 0.0f);
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
