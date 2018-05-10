using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {
	public GameObject animchild, animchild2;
	public Sprite[] boulderClothes;
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
		animchild.transform.position = new Vector3(transform.position.x, animchild.transform.position.y, 0f);
		animchild2.transform.position = new Vector3(transform.position.x, animchild2.transform.position.y, 0f);
		Rotate ();
	}
	void CheckForTag(){
		if (gameObject.CompareTag("Boulder")) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = boulderClothes [0];
			speed = normalSpeed;
		} else if (gameObject.tag == "TarredBoulder") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = boulderClothes [1];
			speed = tarredSpeed;
		} else if (gameObject.tag == "BurningBoulder") {
			gameObject.GetComponent<SpriteRenderer> ().sprite = boulderClothes [2];
			animchild2.GetComponent<SpriteRenderer> ().enabled = true;
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
		animchild.transform.rotation = Quaternion.identity;
		animchild2.transform.rotation = Quaternion.identity;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy") || other.CompareTag ("FrozenEnemy") || other.CompareTag ("BurningEnemy") || other.CompareTag ("TarredEnemy") || other.CompareTag ("FearedEnemy")) {
			killstreak = killstreak+1;
			animchild.GetComponent<Animator> ().Play ("BloodPath");

		}
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
