using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingController : MonoBehaviour {
	public GameObject clothingRightView, clothingFrontView, clothingBackView;
	public GameObject[] Villager; //orientation purposes for left/right
	public string villagerOrientation;
	private string currentOrientation = "";
	private string previousOrientation = "";

	// Use this for initialization
	void Start () {
		//villagerOrientation = "right";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentOrientation = villagerOrientation;
		if (villagerOrientation == "right") {
			if (previousOrientation == "left") {
				Villager[0].GetComponent<SpriteRenderer> ().flipX = false;
				Villager[1].GetComponent<SpriteRenderer> ().flipX = false;
				Villager[2].GetComponent<SpriteRenderer> ().flipX = false;
				Villager[3].GetComponent<SpriteRenderer> ().flipX = false;
				Villager[4].GetComponent<SpriteRenderer> ().flipX = false;
			}
			clothingRightView.SetActive(true);
			clothingFrontView.SetActive(false);
			clothingBackView.SetActive(false);
			//clothingRightView.GetComponent<ClothingGenerator> ().Restart(true);
			previousOrientation = currentOrientation;
		} else if (villagerOrientation == "left") {
			Villager[0].GetComponent<SpriteRenderer> ().flipX = true;
			Villager[1].GetComponent<SpriteRenderer> ().flipX = true;
			Villager[2].GetComponent<SpriteRenderer> ().flipX = true;
			Villager[3].GetComponent<SpriteRenderer> ().flipX = true;
			Villager[4].GetComponent<SpriteRenderer> ().flipX = true;
			clothingRightView.SetActive(true);
			clothingFrontView.SetActive(false);
			clothingBackView.SetActive(false);
			//clothingRightView.GetComponent<ClothingGenerator> ().Restart(true);
			previousOrientation = currentOrientation;
		} else if (villagerOrientation == "front") {
			clothingRightView.SetActive(false);
			clothingFrontView.SetActive(true);
			clothingBackView.SetActive(false);
			//clothingRightView.GetComponent<ClothingGenerator> ().Restart(true);
			previousOrientation = currentOrientation;
		}else if (villagerOrientation == "back"){
			clothingRightView.SetActive(false);
			clothingFrontView.SetActive(false);
			clothingBackView.SetActive(true);
			//clothingRightView.GetComponent<ClothingGenerator> ().Restart(true);
			previousOrientation = currentOrientation;
		}
	}

}
