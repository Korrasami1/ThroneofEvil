using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;                         //The speed of the enemy, around 5 looks nice
	public float horizontal;                    //This has no function until random movement within the different lanes is implemented
	public float vertical;                      //This has no function until random movement within the different lanes is implemented
	public float laneOne;                       //Representing the Y-value of lane 1
	public float laneTwo;                       //Representing the Y-value of lane 2
	public float laneThree;                     //Representing the Y-value of lane 3
	public float laneFour;                      //Representing the Y-value of lane 4
	public float laneFive;                      //Representing the Y-value of lane 5
	public float laneDiversity;                 //The randomized difference in Y-value for enemies on the same lane
	private Vector3 currentPosition;            //The current position of the enemy on this update
	private Vector3 targetPosition;             //The position the enemy will move to on the next update
	private float targetY;                      //The Y-value of targetPosition
	void Start()
	{
		int random = Random.Range (0, 5);
		switch (random) {
		case 0:
			targetY = laneOne;
			break;
		case 1:
			targetY = laneTwo;
			break;
		case 2:
			targetY = laneThree;
			break;
		case 3:
			targetY = laneFour;
			break;
		case 4:
			targetY = laneFive;
			break;
		default:
			Debug.Log ("Start randomization failed");
			break;
		}
	}

	void FixedUpdate()
	{
		//Every FixedUpdate() the enemy moves towards the target position, 
		//which is calculated by adding (speed value multiplied by Time.deltaTime) to the X-value of the enemies current position
		float step = speed * Time.deltaTime;
		currentPosition = transform.position;
		targetPosition = currentPosition += new Vector3(step, 0f);
		targetPosition.y = targetY;
		transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);
	}
	void SwitchLanes()
	{
		//SwitchLanes() first checks for the y-position of the enemy and then decides aitch lane it is on
		//Then, depending on lane, MoveTo() is called using the value of the lane that the enemy is supposed to move to
		//If the enemy can move to two different lanes, the Randomizer() chooses witch lane the enemy will target
		if (transform.position.y < laneOne + laneDiversity && transform.position.y > laneOne - laneDiversity) {
			Debug.Log ("Lane One!");
			MoveTo (laneTwo);
		} else if (transform.position.y < laneTwo + laneDiversity && transform.position.y > laneTwo - laneDiversity) {
			Debug.Log ("Lane Two!");
			if (Randomizer ()) {
				MoveTo (laneOne);
			} else {
				MoveTo (laneThree);
			}
		} else if (transform.position.y < laneThree + laneDiversity && transform.position.y > laneThree - laneDiversity) {
			Debug.Log ("Lane Three!");
			if (Randomizer ()) {
				MoveTo (laneTwo);
			} else {
				MoveTo (laneFour);
			}
		} else if (transform.position.y < laneFour + laneDiversity && transform.position.y > laneFour - laneDiversity) {
			Debug.Log ("Lane Four!");
			if (Randomizer ()) {
				MoveTo (laneThree);
			} else {
				MoveTo (laneFive);
			}
		} else if (transform.position.y < laneFive + laneDiversity && transform.position.y > laneFive - laneDiversity) {
			Debug.Log ("Lane Five!");
			MoveTo (laneFour);
		} else {
			return;
		}
	}
	void MoveTo(float lane)
	{
		//MoveTo() takes the float value of the lane that is called and randomizes it depending on the value of laneDiversity
		float randomizer = Random.Range (-laneDiversity, laneDiversity);
		targetY = lane + randomizer;
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Trap") 
		{
			SwitchLanes ();
		}
	}
	bool Randomizer()
	{
		//A randomizer for a 50/50 event
		bool random = false;
		float randomizer = Random.Range (0, 2);
		if (randomizer >= 1f)
		{
			random = true;
		}
		return random;
	}
}
