using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingController : MonoBehaviour {

	public float _speed = 5;
	public Transform target;
	private float _angleOffset = -90;
	// Use this for initialization
	void Start()
	{
		// 
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 dir = target.position - transform.position; //was target.transform.position
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + _angleOffset, Vector3.forward);

		transform.position += transform.up * _speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy")) {
			Destroy (other.gameObject);
		}
		if (other.CompareTag ("MinionTarget")) {
			Destroy (gameObject);
		}
	}
}
