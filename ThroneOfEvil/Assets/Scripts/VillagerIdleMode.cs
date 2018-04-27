using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerIdleMode : MonoBehaviour {

	public float _speed = 5;
	public Transform target;
	//private float _angleOffset = -90; //was -90
	public float timedelay = 2f;
	public float XMin;
	public float XMax;
	public float YMin;
	public float YMax;

	// Use this for initialization
	void Start () {
		XMin = -16;
		XMax = 13;
		YMin = -6;
		YMax = 4.7f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*Vector3 dir = target.position - transform.position; //was target.transform.position
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + _angleOffset, Vector3.forward);*/
		transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

		if (Time.time > timedelay) {
			timedelay = Time.time + 2f;
			target.position =  new Vector3 (Random.Range (XMin, XMax), Random.Range (YMin, YMax), 0.0f);
			//wayPoints.position =  new Vector3 (Random.Range (1, 8), Random.Range (1, 8), 0.0f);
			//target = wayPoints;
		}
	}
}
