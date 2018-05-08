using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class MutedVoiceCommands : MonoBehaviour {

	//public string[] keywords = new string[] {"Send in the minions", "Fire", "Lightning", "Fear", "Mind Control"};
	SoundsSceneManager sounds;
	public float minionSpeed;
	//protected string word = "Voice Commands Active";
	public GameObject minion;
	public int numOfMinions = 20;
	private bool isSpawningMinions = false;
	public GameObject fire;
	private bool isSpawningFire = false;
	public GameObject lightning;
	private bool isSpawningLightning = false;
	//public GameObject fear;
	//private bool isSpawningFear = false;
	//public GameObject MindControl;
	//private bool isSpawningMindControl = false;
	public GameObject Evil;
	private bool isSpawningEvil = false;
	private bool hasFireCooledDown, hasLightningCooledDown, hasMinionsCooleddown/*, hasFearCooledDown, hasMindControlCooledDown*/, hasEvilCooledDown;
	public float minionCooldown, fireCooldown, lightningCooldown/*, fearCooldown, MindControlCooldown*/, EvilLaughterCoolDown;
	private float previousMinioncool, previousFirecool, previousLightningcool/*, previousFearcool, previousMindcool*/;
	Camera cam;
	//private static bool created = false;
	void Start()
	{
		//for cooldown so that on start you can command a magic spell without waiting on that cooldown
		hasFireCooledDown = true;
		hasMinionsCooleddown = true;
		hasLightningCooledDown = true;
		//hasFearCooledDown = true;
		//hasMindControlCooledDown = true;
		isSpawningMinions = true;
		isSpawningFire = true;
		isSpawningLightning = true;
		//isSpawningFear = true;
		//isSpawningMindControl = true;
		cam = Camera.main;
		hasEvilCooledDown = true;
		sounds = GameObject.FindWithTag ("SoundManager").GetComponent<SoundsSceneManager> ();
	}
	private void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			Debug.Log ("You pressed A");
			if (hasMinionsCooleddown == false) {
				sounds.PlaySound(8);
			}
			spawnMinions ();
			hasMinionsCooleddown = false;
			StartCoroutine (MagicCoolDown (1, hasMinionsCooleddown));
		} else if (Input.GetKeyDown (KeyCode.S)) {
			Debug.Log ("You pressed S");
			if (hasFireCooledDown == false) {
				sounds.PlaySound(8);
			}
			SpawnFire ();
			hasFireCooledDown = false;
			StartCoroutine (MagicCoolDown (2, hasFireCooledDown));
		} else if (Input.GetKeyDown (KeyCode.D)) {
			Debug.Log ("You pressed D");
			if (hasLightningCooledDown == false) {
				sounds.PlaySound(8);
			}
			SpawnLightning ();
			hasLightningCooledDown = false;
			StartCoroutine (MagicCoolDown (3, hasLightningCooledDown));
		} /*else if (Input.GetKeyDown (KeyCode.F)) {
			Debug.Log ("You pressed F");
			if (hasFearCooledDown == false) {
				sounds.PlaySound(8);
			}
			SpawnFear ();
			hasFearCooledDown = false;
			StartCoroutine (MagicCoolDown (4, hasFearCooledDown));
		} else if (Input.GetKeyDown (KeyCode.G)) {
			Debug.Log ("You pressed G");
			if (hasMindControlCooledDown == false) {
				sounds.PlaySound(8);
			}
			SpawnMindControl ();
			hasMindControlCooledDown = false;
			StartCoroutine (MagicCoolDown (5, hasMindControlCooledDown));
		}*/
		else if (Input.GetKeyDown (KeyCode.H)) {
			Debug.Log ("You pressed H");
			if (hasEvilCooledDown == false) {
				sounds.PlaySound(8);
			}
			SpawnEvilPromotion ();
			hasEvilCooledDown = false;
			StartCoroutine (MagicCoolDown (6, hasEvilCooledDown));
		}
	}
	public void BackfromPromotion(){
		minionCooldown = previousMinioncool;
		fireCooldown = previousFirecool;
		lightningCooldown = previousLightningcool;
		//fearCooldown = previousFearcool;
		//MindControlCooldown = previousMindcool;
		Debug.Log ("yes");
		Debug.Log ("minion"+minionCooldown+"fire"+fireCooldown+"light"+lightningCooldown/*+"fear"+fearCooldown+"mind"+MindControlCooldown*/);
	}

	public void Promotion(){
		previousMinioncool = minionCooldown;
		previousFirecool = fireCooldown;
		previousLightningcool = lightningCooldown;
		//previousFearcool = fearCooldown;
		//previousMindcool = MindControlCooldown;
		minionCooldown = minionCooldown * 0.5f;
		fireCooldown = fireCooldown * 0.5f;
		lightningCooldown = lightningCooldown * 0.5f;
		//fearCooldown = fearCooldown * 0.5f;
		//MindControlCooldown = MindControlCooldown * 0.5f;
		Debug.Log ("minion"+minionCooldown+"fire"+fireCooldown+"light"+lightningCooldown/*+"fear"+fearCooldown+"mind"+MindControlCooldown*/);
	}
	IEnumerator MagicCoolDown(int magictype/*string magictype*/, bool hasCooled){
		switch (magictype)
		{
		case 1/*"Send in the minions"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (minionCooldown);
				hasMinionsCooleddown = true;
				isSpawningMinions = true;
			}
			break;
		case 2/*"Fire"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (fireCooldown);
				hasFireCooledDown = true;
				Debug.Log ("fire has cooled");
				isSpawningFire = true;
			}
			break;
		case 3/*"Lightning"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (lightningCooldown);
				hasLightningCooledDown = true;
				isSpawningLightning = true;
			}
			break;
		/*case 4/*"Fear"/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (fearCooldown);
				hasFearCooledDown = true;
				isSpawningFear = true;
			}
			break;
		case 5/*"Mind Control"/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (MindControlCooldown);
				hasMindControlCooledDown = true;
				isSpawningMindControl = true;
			}
			break;*/
		case 6/*"Evil Laugh"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (EvilLaughterCoolDown);
				hasEvilCooledDown = true;
				isSpawningEvil = true;
			}
			break;
		}
	}
	private void spawnMinions(){
		if (isSpawningMinions == true) {
			int tempCounter = 0;
			//Vector3 center = transform.position;
			for (int i = 0; i < numOfMinions; i++) {
				float a = 4f - i*1.5f; //was x //was -15f
				float b = cam.gameObject.transform.localPosition.x+15f/* + i*1.5f*/;
				Vector3 spawnPosition = new Vector3(b, a, 0f);
				Instantiate (minion, spawnPosition, Quaternion.identity);
				tempCounter++;
				Debug.Log ("minion counter: " + tempCounter); //remove after num of minions is set
			}
			isSpawningMinions = false;
		}
	}
	private void SpawnFire(){
		if (isSpawningFire == true) {
			for (int i = 0; i < 1; i++) {
				Instantiate (fire, fire.transform.position, Quaternion.identity);
			}
			isSpawningFire = false;
		}
	}
	private void SpawnLightning(){
		if (isSpawningLightning == true) {
			for (int i = 0; i < 1; i++) {
				Instantiate (lightning, lightning.transform.position, Quaternion.identity);
			}
			isSpawningLightning = false;
		}
	}
	/*private void SpawnFear(){
		if (isSpawningFear == true) {
			for (int i = 0; i < 1; i++) {
				Instantiate (fear, fear.transform.position, Quaternion.identity);
			}
			isSpawningFear = false;
		}
	}
	private void SpawnMindControl(){
		if (isSpawningMindControl == true) {
			for (int i = 0; i < 1; i++) {
				Instantiate (MindControl, MindControl.transform.position, Quaternion.identity);
			}
			isSpawningMindControl = false;
		}
	}*/
	private void SpawnEvilPromotion(){
		if (isSpawningEvil == true) {
			for (int i = 0; i < 1; i++) {
				Instantiate (Evil, Evil.transform.position, Quaternion.identity);
			}
			isSpawningEvil = false;
		}
	}
	//spawning minions in a circle on the field
	Vector3 RandomCircle(Vector3 center, float radius,int a)
	{
		//Debug.Log(a);
		float ang = a;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.z = center.z;
		return pos;
	}
}
