using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speedX = 2;              		//The x-axis speed of the enemy
	public float speedY = 3;					//The y-axis speed of the enemy
	public float RunningAroundOnfireSpeed = -3f;
	public float horizontal;                    //This has no function until random movement within the different lanes is implemented
	public float vertical;                      //This has no function until random movement within the different lanes is implemented
	public float laneOne = 5f;                  //Representing the Y-value of lane 1
	public float laneTwo = 2.5f;                //Representing the Y-value of lane 2
	public float laneThree = 0f;                //Representing the Y-value of lane 3
	public float laneFour = -2.5f;              //Representing the Y-value of lane 4
	public float laneFive = -5f;                //Representing the Y-value of lane 5
	public float laneDiversity = 0.5f;          //The randomized difference in Y-value for enemies on the same lane
	public TrapDoorRelease trapDoor;
	public float pathReactionTime;
	public Vector3 destinationOne;
	public Vector3 destinationTwo;
	public Vector3 destinationThree;
	private Vector3 currentPosition;            //The current position of the enemy on this update
	private Vector3 targetPosition;             //The position the enemy will move to on the next update
	private Vector3 previousPosition;         	//The position position of the enemy on the update before, not currently in use
	private float targetY;                      //The Y-value of targetPosition
	private float normalSpeedX;                 //The value of speedX stored so if speed is changed during run time it can later be reverted back to it's original value
	private float normalSpeedY;					//The value of speedY stored so if speed is changed during run time it can later be reverted back to it's original value
	private bool foundDestinationOne = false;
	private bool foundDestinationTwo = false;
	private bool foundDestinationThree = false;
	private bool objectCollision = false;
	private bool canMoveUp = true;
	private bool canMoveDown = true;
	public bool isMovementPaused = false;
	public bool isPaused = false;
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
		normalSpeedX = speedX;
		normalSpeedY = speedY;
	}
	void FixedUpdate()
	{
		//Every FixedUpdate() the enemy moves towards the target position, 
		//which is calculated by adding (speed value multiplied by Time.deltaTime) to the X-value of the enemies current position
		//CheckForTag(); //this should not be in update for the enemy!!
		if (isPaused) {
			MultiplySpeed (0f, 0f);
		}
		float stepX = speedX * Time.fixedDeltaTime;
		float stepY = speedY * Time.fixedDeltaTime;
		float step = (stepX + stepY);
		currentPosition = transform.position;
		targetPosition.x = currentPosition.x += stepX;
		transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);
		MoveToDestination ();
	}
	public void CheckForTag(){
		if (gameObject.CompareTag("Enemy")) {
			MultiplySpeed (1f, 1f);
		} else if (gameObject.CompareTag("FrozenEnemy")) {
			MultiplySpeed (0f, 0f);
			//Debug.Log("Enemy is frozen!");
		} else if (gameObject.CompareTag("TarredEnemy")) {
			MultiplySpeed (0.5f, 0.5f);
			//Debug.Log("Enemy is tarred!");
		} else if (gameObject.CompareTag("BurningEnemy")) {
			SwitchLanes ();
			MultiplySpeed(RunningAroundOnfireSpeed, 0f);
			gameObject.GetComponent<ClothingController>().villagerOrientation = "left";
			Debug.Log("Enemy is burning!");
		} else {
			Debug.Log ("Enemy CheckForTag() failed!");
			return;
		}
	}
	public void MultiplySpeed(float speedMultX, float speedMultY){
		speedX = normalSpeedX * speedMultX;
		speedY = normalSpeedY * speedMultY;
	}
	void RandomLaneMovement()
	{
		//RandomLaneMovement() is currently not in use
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
	public void SwitchLanes()
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
		trapDoor = (TrapDoorRelease)FindObjectOfType(typeof(TrapDoorRelease));
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
		} else {
			return;
		}
	}
	void MoveTo(float lane)
	{
		//MoveTo() takes the float value of the lane that is called and randomizes it depending on the value of laneDiversity
		float randomizer = Random.Range (-laneDiversity, laneDiversity);
		targetY = lane + randomizer;
		targetPosition.y = targetY;
	}
	IEnumerator BounceBack()
	{
		MultiplySpeed (-5f, 7f);
		yield return new WaitForSeconds (0.2f);
		MultiplySpeed (1f, 1f);
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag ("Trap Detection")) 
		{
			SwitchLanes ();
		}
		if (collider.CompareTag("Fear")) {
			gameObject.GetComponent<ClothingController>().villagerOrientation = "right";
			MultiplySpeed (1f, 1f);
		}
		if (collider.CompareTag("Wall") && objectCollision == false) 
		{
			//StartCoroutine (BounceBack ());
			objectCollision = true;
		}
		if (collider.CompareTag("TarPool") || collider.CompareTag("TarredBoulder")){

		}
		if (collider.CompareTag("Boulder") || collider.CompareTag("BurningBoulder") || collider.CompareTag("TarredBoulder")){
			StartCoroutine (BounceBack ());
			SwitchLanes ();
		}
	}
	void OnTriggerStay(Collider collider)
	{
		if (collider.CompareTag ("Wall Detection"))
		{
			AvoidObstacle (transform.position.x, transform.position.y);
		}
		if (collider.CompareTag ("Trap Downwards Detection"))
		{
			canMoveDown = false;
		}
		if (collider.CompareTag ("Trap Upwards Detection"))
		{
			canMoveUp = false;
		}
	}
	void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag ("Wall") && objectCollision == true) 
		{
			objectCollision = false;
		}
		if (collider.CompareTag ("Trap Downwards Detection")) 
		{
			canMoveDown = true;
		}
		if (collider.CompareTag("Trap Upwards Detection")) 
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
