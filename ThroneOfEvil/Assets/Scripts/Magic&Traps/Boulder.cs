using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

	public float speed = 10;
	public float tarredSpeed = 5;
	public float smooth = 5;
	public float rotationSpeed = 15;
	private float normalSpeed;
	private float tiltAngle = 0;
	private Vector3 currentPosition;
	private Vector3 targetPosition;
	public int killstreak = 1;
	void Start () {
		killstreak = 1;
		normalSpeed = speed;
	}
	void FixedUpdate () {
		float step = speed * Time.fixedDeltaTime;
		currentPosition = transform.position;
		targetPosition = currentPosition -= new Vector3(step, 0f);
		transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);
		Rotate ();
	}
	void CheckForTag(){
		if (gameObject.CompareTag("Boulder")) {
			speed = normalSpeed;
		} else if (gameObject.tag == "TarredBoulder") {
			speed = tarredSpeed;
		} else if (gameObject.tag == "BurningBoulder") {
			speed = normalSpeed;
			Debug.Log("Boulder is burning!");
		} else {
			Debug.Log ("Boulder CheckForTag() failed!");
			return;
		}
	}
	void Rotate()
	{
		tiltAngle += rotationSpeed;
		float rotation = tiltAngle;
		Quaternion target = Quaternion.Euler (0f, 0f, rotation);
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.fixedDeltaTime * smooth);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("TrapDoor")) {
			Destroy (gameObject);
		}
		if (other.CompareTag ("TarPool")) {
			gameObject.tag = "TarredBoulder";
			CheckForTag ();
		}
		if (gameObject.CompareTag("TarredBoulder")){
			if (other.CompareTag("Fire") || other.CompareTag("Explosion")){
				gameObject.tag = "BurningBoulder";
				CheckForTag ();
			}
		}
	}
}
