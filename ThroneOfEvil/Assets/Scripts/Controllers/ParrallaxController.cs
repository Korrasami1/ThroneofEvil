using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrallaxController : MonoBehaviour {
	public Transform[] spawnLocations; //so that i can change their positions based on camera placement
	public float[] xposition;
	public Vector3[] allspawnpositions;
	public bool CameraMovement, BackgroundMovement;
	public GameObject cam;
	public float CameraSpeed;
	public float[] backgroundSpeeds;
	public GameObject[] backgrounds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (BackgroundMovement) {
			BackgroundLayerMovements ();
		} else if (CameraMovement) {
			CameraMovements ();
		}
	}

	void BackgroundLayerMovements(){
		backgrounds[0].transform.position += backgroundSpeeds[0] * Vector3.right * Time.deltaTime;
	}
	void CameraMovements(){
		cam.transform.position += CameraSpeed * Vector3.left * Time.deltaTime;
		if (cam.transform.position.x <= xposition[0]) {
			spawnLocations [0].localPosition = allspawnpositions[0];
		}
		if (cam.transform.position.x <= xposition[1]) {
			spawnLocations [1].localPosition = allspawnpositions[1];
		}
	}
}
