using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;                         //The speed of the enemy, around 5 looks nice
	public float horizontal;                    //This has no function until random movement within the different lanes is implemented
	public float vertical;                      //This has no function until random movement within the different lanes is implemented
	public float laneOne = 5f;                  //Representing the Y-value of lane 1
	public float laneTwo = 2.5f;                //Representing the Y-value of lane 2
	public float laneThree = 0f;                //Representing the Y-value of lane 3
	public float laneFour = -2.5f;              //Representing the Y-value of lane 4
	public float laneFive = -5f;                //Representing the Y-value of lane 5
	public float laneDiversity = 0.5f;          //The randomized difference in Y-value for enemies on the same lane
	public TarPool tarPool;
	public TrapDoorRelease trapDoor;
	public FreezeTrapExplosion freezeTrap;
	public float pathReactionTime;
	public Vector3 destinationOne;
	public Vector3 destinationTwo;
	public Vector3 destinationThree;
	private Vector3 currentPosition;            //The current position of the enemy on this update
	private Vector3 targetPosition;             //The position the enemy will move to on the next update
	//  private Vector3 previousPosition;           //The position position of the enemy on the update before, not currently in use
	private float targetY;                      //The Y-value of targetPosition
	private float normalSpeed;			//The value of speed stored so if speed is changed during run time it can later be reverted back to it's original value
	//private bool pathFinding = false;
	//private bool trapDoorIsOpen = false;
	private bool foundDestinationOne = false;
	private bool foundDestinationTwo = false;
	private bool foundDestinationThree = false;
	private bool objectCollision = false;
	private bool canMoveUp = true;
	private bool canMoveDown = true;
	private bool isMovementPaused = false;
	void Start()
	{
		//Start() assigns a random value between 0 and 4 to each enemy spawn, this in turn decides their starting lane
		int random = Random.Range (0, 5);
		switch (random) {
		case 0:
			MoveTo(laneOne);
			break;
		case 1:
			MoveTo(laneTwo);
			break;
		case 2:
			MoveTo(laneThree);
			break;
		case 3:
			MoveTo(laneFour);
			break;
		case 4:
			MoveTo(laneFive);
			break;
		default:
			Debug.Log ("Start randomization failed");
			break;
		}
		normalSpeed = speed;
	}
	void FixedUpdate()
	{
		//Every FixedUpdate() the enemy moves towards the target position, 
		//which is calculated by adding (speed value multiplied by Time.deltaTime) to the X-value of the enemies current position
		float step = speed * Time.deltaTime;
		currentPosition = transform.position;
		targetPosition.x = currentPosition.x += step*0.8f;
		transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step*1.25f);
		MoveToDestination ();
		if (isMovementPaused == true) {
			//StartCoroutine ();
		}
	}
	void RandomLaneMovement()
	{
		horizontal = Random.Range (-horizontal, horizontal);
		vertical = Random.Range (-vertical, vertical);
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
	void MoveToDestination()
	{
		//		if (Input.GetKeyDown ("space") && !trapDoorIsOpen) {
		//			trapDoorIsOpen = true;
		//		} else {
		//			//ble
		//		}
		trapDoor = (TrapDoorRelease)FindObjectOfType(typeof(TrapDoorRelease));
		if (trapDoor)
			Debug.Log("trapDoor object found: " + trapDoor.name);
		else
			Debug.Log("No trapDoor object could be found");
		if (trapDoor.mode == "open") {
			if ((FindDestination (destinationOne) && !foundDestinationOne) && (FindDestination (destinationTwo) && !foundDestinationTwo)) {
				if (CompareDestination (destinationOne.y, destinationTwo.y)) {
					MoveTo (destinationOne.y);
					foundDestinationOne = true;
				} else {
					MoveTo (destinationTwo.y);
					foundDestinationTwo = true;
				}
			}
		}
		if (FindDestination (destinationThree) && !foundDestinationThree) {
			MoveTo (destinationThree.y);
			foundDestinationThree = true;
		}
	}
	bool FindDestination(Vector3 destination)
	{
		if (destination == new Vector3(0, 0, 0)){
			return false;
		} else if (transform.position.x > destination.x - pathReactionTime && transform.position.x < destination.x) {
			return true;
		} else {
			return false;
		}
	}
	bool CompareDestination(float destination1, float destination2) 
	{
		float positionY = transform.position.y;
		float destinationOneY = destination1;
		float destinationTwoY = destination2;
		float deltaOneY = MakePositive(destinationOneY - positionY); 
		float deltaTwoY = MakePositive(destinationTwoY - positionY);
		if (deltaOneY == deltaTwoY) {
			if (Randomizer ()) {
				return true;
			} else {
				return false;
			}
		}
		else if (deltaOneY < deltaTwoY) {
			return true;
		} else {
			return false;
		}
	}
	float MakePositive(float num)
	{
		if (num < 0f) {
			return num * -1;
		} else {
			return num;
		}
	}
	void AvoidObstacle(float xPosition, float yPosition)
	{
		if (xPosition > destinationOne.x - pathReactionTime && xPosition < destinationOne.x) {
			MoveTo (destinationOne.y);
			//pathFinding = true;
		} else {
			//pathFinding = false;
		}
	}
	void MoveTo(float lane)
	{
		//MoveTo() takes the float value of the lane that is called and randomizes it depending on the value of laneDiversity
		float randomizer = Random.Range (-laneDiversity, laneDiversity);
		targetY = lane + randomizer;
		targetPosition.y = targetY;
	}
	public IEnumerator pauseMovement(bool isPausing){
		speed = 0;
		yield return new WaitUntil(() => isPausing == false);
		speed = 5;
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
	IEnumerator TarCountdown()
	{
		gameObject.tag = "TarredEnemy";
		speed = normalSpeed * tarPool.slowdown;
		yield return new WaitForSeconds (tarPool.slowDurationSeconds);
		speed = normalSpeed;
		gameObject.tag = "Enemy";
	}
	IEnumerator FreezeCountdown()
	{
		gameObject.tag = "FrozenEnemy";
		speed = normalSpeed * 0;
		yield return new WaitForSeconds (freezeTrap.freezeDurationSeconds);
		speed = normalSpeed;
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Trap" || collider.tag == "TrapDoor") 
		{
			Destroy(gameObject);
		}
		else if (collider.tag == "Trap Detection") 
		{
			SwitchLanes ();
		}
		if (collider.CompareTag("Fear")) {
			gameObject.GetComponent<ClothingController>().villagerOrientation = "right";
			speed = 5;
		}
		if (collider.tag == "Wall" && objectCollision == false) 
		{
			//StartCoroutine (BounceBack ());
			objectCollision = true;
		}
		if (collider.tag == "TarPool" || collider.tag == "TarredBoulder") {
			StartCoroutine (TarCountdown ());
		}
		if (collider.tag == "FreezeTrapExplosion") {
			StartCoroutine (FreezeCountdown ());
		}
	}
	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "Wall Detection") 
		{
			AvoidObstacle (transform.position.x, transform.position.y);
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
	IEnumerator TarPoolCountdown()
	{
		speed = normalSpeed * tarPool.slowdown;
		yield return new WaitForSeconds (tarPool.slowDurationSeconds);
		speed = normalSpeed;
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
