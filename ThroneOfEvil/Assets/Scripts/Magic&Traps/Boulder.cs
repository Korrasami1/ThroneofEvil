using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

	public float speed;
	public float smooth;
	public float rotationSpeed;
	private float tiltAngle = 0;
	private Vector3 currentPosition;
	private Vector3 targetPosition;
	void Start () {
	}
	void FixedUpdate () {
		float step = speed * Time.deltaTime;
		currentPosition = transform.position;
		targetPosition = currentPosition -= new Vector3(step, 0f);
		transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);
		Rotate ();
	}
	void Rotate()
	{
		tiltAngle += rotationSpeed;
		float rotation = tiltAngle;
		Quaternion target = Quaternion.Euler (0f, 0f, rotation);
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "TrapDoor") {
			Destroy (gameObject);
		}
		if (collider.tag == "TarPool") {
			gameObject.tag = "TarredBoulder";
			speed = speed / 2;
		}
		if (collider.tag == "FrozenEnemy") {
			Destroy (collider.gameObject);
		}
	}
}
