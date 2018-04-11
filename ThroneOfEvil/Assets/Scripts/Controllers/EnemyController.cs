using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;                         //The speed of the enemy, around 5 looks nice
	public float damage = 50;
	//  public float horizontal;                    //This has no function until random movement within the different lanes is implemented
	//  public float vertical;                      //This has no function until random movement within the different lanes is implemented
	public float laneOne = 5f;                  //Representing the Y-value of lane 1
	public float laneTwo = 2.5f;                //Representing the Y-value of lane 2
	public float laneThree = 0f;                //Representing the Y-value of lane 3
	public float laneFour = -2.5f;              //Representing the Y-value of lane 4
	public float laneFive = -5f;                //Representing the Y-value of lane 5
	public float laneDiversity = 0.5f;          //The randomized difference in Y-value for enemies on the same lane
	public Vector3 openingOne;
	public Vector3 openingTwo;
	public Vector3 openingThree;
	private Vector3 currentPosition;            //The current position of the enemy on this update
	private Vector3 targetPosition;             //The position the enemy will move to on the next update
	//  private Vector3 previousPosition;           //The position position of the enemy on the update before, not currently in use
	private float targetY;                      //The Y-value of targetPosition
	private bool objectCollision = false;
	private bool canMoveUp = true;
	private bool canMoveDown = true;
	void Start()
	{
		//Start() assigns a random value between 0 and 4 to each enemy spawn, this in turn decides their starting lane
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
		if (objectCollision) {
			targetPosition = currentPosition += new Vector3(0f, 0f);
		} else {
			targetPosition = currentPosition += new Vector3(step*0.8f, 0f);
		}
		targetPosition.y = targetY;
		transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step*1.25f);
	}
	int CheckForLane(float yPosition)
	{
		if (yPosition < laneOne + laneDiversity && transform.position.y > laneOne - laneDiversity) {
			return 1;
		} else if (yPosition < laneTwo + laneDiversity && transform.position.y > laneTwo - laneDiversity) {
			return 2;
		} else if (yPosition < laneThree + laneDiversity && transform.position.y > laneThree - laneDiversity) {
			return 3;
		} else if (yPosition < laneFour + laneDiversity && transform.position.y > laneFour - laneDiversity) {
			return 4;
		} else if (yPosition < laneFive + laneDiversity && transform.position.y > laneFive - laneDiversity) {
			return 5;
		} else {
			return 0;
		}
	}
	void SwitchLanes()
	{
		//SwitchLanes() first checks for the y-position of the enemy and then decides aitch lane it is on
		//Then, depending on lane, MoveTo() is called using the value of the lane that the enemy is supposed to move to
		//If the enemy can move to two different lanes, the Randomizer() chooses witch lane the enemy will target
		if (CheckForLane(transform.position.y) == 1) {
			if (canMoveDown) {
				MoveTo (laneTwo);
			} else {
				return;
			}
		} else if (CheckForLane(transform.position.y) == 2) {
			if (!canMoveDown && !canMoveUp) {
				RandomAdjacentLane (laneOne, laneThree);
			} else if (!canMoveDown) {
				MoveTo (laneOne);
			} else if (!canMoveUp) {
				MoveTo (laneThree);
			} else {
				RandomAdjacentLane (laneOne, laneThree);
			}
		} else if (CheckForLane(transform.position.y) == 3) {
			if (!canMoveDown && !canMoveUp) {
				RandomAdjacentLane (laneTwo, laneFour);
			} else if (!canMoveDown) {
				MoveTo (laneTwo);
			} else if (!canMoveUp) {
				MoveTo (laneFour);
			} else {
				RandomAdjacentLane (laneTwo, laneFour);
			}
		} else if (CheckForLane(transform.position.y) == 4) {
			if (!canMoveDown && !canMoveUp) {
				RandomAdjacentLane (laneThree, laneFive);
			} else if (!canMoveDown) {
				MoveTo (laneThree);
			} else if (!canMoveUp) {
				MoveTo (laneFive);
			} else {
				RandomAdjacentLane (laneThree, laneFive);
			}
		} else if (CheckForLane(transform.position.y) == 5) {
			if (canMoveUp) {
				MoveTo (laneFour);
			} else {
				return;
			}
		} else {
			return;
		}
	}
	void RandomAdjacentLane(float lane1, float lane2)
	{
		if (Randomizer ()) {
			MoveTo (lane1);
		} else {
			MoveTo (lane2);
		}
	}
	void AvoidObstacle(float xPosition)
	{
		if (xPosition < openingOne.x) {
			MoveTo (openingOne.y);
		} else if (xPosition < openingTwo.x) {
			MoveTo (openingTwo.y);
		} else if (xPosition < openingThree.x) {
			MoveTo (openingThree.y);
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
	IEnumerator BounceBack()
	{
		//This script is a kind of work in progress since I don't think it looks super nice. But right now it gets the job done and I'm focusing on more urgent stuff.
		objectCollision = true;
		speed *= -1;
		float previousTargetY = targetY;
		targetY = transform.position.y;
		yield return new WaitForSeconds (0.2f);
		targetY = previousTargetY;
		speed *= -1f;
		objectCollision = false;
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Trap") 
		{
			GetComponent<EnemyHealthController>().DealDamage(damage);
			Debug.Log ("current enemies health after Trap " + GetComponent<EnemyHealthController> ().currentHealth);
			if (GetComponent<EnemyHealthController> ().currentHealth <= 0) {
				Destroy(gameObject);
			}
		}
		else if (collider.tag == "Trap Detection") 
		{
			SwitchLanes ();
		}
		if (collider.tag == "Wall" && objectCollision == false) 
		{
			//StartCoroutine (BounceBack ());
			objectCollision = true;
		}
	}
	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "Wall Detection") 
		{
			AvoidObstacle (transform.position.x);
		}
		if (collider.tag == "Trap Downwards Detection") 
		{
			canMoveDown = false;
		}
		if (collider.tag == "Trap Upwards Detection") 
		{
			canMoveUp = false;
		}
	}
	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Wall" && objectCollision == true) 
		{
			objectCollision = false;
		}
		if (collider.tag == "Trap Downwards Detection") 
		{
			canMoveDown = true;
		}
		if (collider.tag == "Trap Upwards Detection") 
		{
			canMoveUp = true;
		}
	}
	bool Randomizer()
	{
		//A randomizer for a 50/50 event
		bool random = false;
		float randomizer = Random.value;
		if (randomizer >= 0.51f)
		{
			random = true;
		}
		return random;
	}
}
