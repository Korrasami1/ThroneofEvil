using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceCommandController : MonoBehaviour
{

	public string[] keywords = new string[] {"Send in the minions", "Fire", "Lightning", "Fear", "Mind Control"};
	public ConfidenceLevel confidence = ConfidenceLevel.Low;
	public float minionSpeed;
	protected PhraseRecognizer recognizer;
	protected string word = "Voice Commands Active";
	public GameObject minion;
	public int numOfMinions = 20;
	private bool isSpawningMinions = false;
	public GameObject fire;
	private bool isSpawningFire = false;
	public GameObject lightning;
	private bool isSpawningLightning = false;
	public GameObject fear;
	private bool isSpawningFear = false;
	public GameObject MindControl;
	private bool isSpawningMindControl = false;
	private bool hasFireCooledDown, hasLightningCooledDown, hasMinionsCooleddown, hasFearCooledDown, hasMindControlCooledDown;
	public float minionCooldown, fireCooldown, lightningCooldown, fearCooldown, MindControlCooldown;
	//private static bool created = false;
	void Start()
	{
		if (keywords != null)
		{
			recognizer = new KeywordRecognizer(keywords, confidence);
			recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
			recognizer.Start();
		}
		//for cooldown so that on start you can command a magic spell without waiting on that cooldown
		hasFireCooledDown = true;
		hasMinionsCooleddown = true;
		hasLightningCooledDown = true;
		hasFearCooledDown = true;
		hasMindControlCooledDown = true;
	}
	private void FixedUpdate()
	{
		switch (word)
		{
		case "Send in the minions":
			spawnMinions ();
			hasMinionsCooleddown = false;
			StartCoroutine (MagicCoolDown (1, hasMinionsCooleddown));
			break;
		case "Fire":
			SpawnFire ();
			hasFireCooledDown = false;
			StartCoroutine (MagicCoolDown (2, hasFireCooledDown));
			break;
		case "Lightning":
			SpawnLightning ();
			hasLightningCooledDown = false;
			StartCoroutine (MagicCoolDown (3, hasLightningCooledDown));
			break;
		case "Fear":
			SpawnFear ();
			hasFearCooledDown = false;
			StartCoroutine (MagicCoolDown (4, hasFearCooledDown));
			break;
		case "Mind Control":
			SpawnMindControl ();
			hasMindControlCooledDown = false;
			StartCoroutine (MagicCoolDown (5, hasMindControlCooledDown));
			break;
		case "exit":
			Application.Quit();
			break;
		}
	}
	private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		word = args.text;
		if (word == "Fire" && !hasFireCooledDown) {
			word = "Cooldown in effect!";
		}
		if (word == "Lightning" && !hasLightningCooledDown) {
			word = "Cooldown in effect!";
		}
		if (word == "Send in the minions" && !hasMinionsCooleddown) {
			word = "Cooldown in effect!";
		}
		if (word == "Fear" && !hasFearCooledDown) {
			word = "Cooldown in effect!";
		}
		if (word == "Mind Control" && !hasMindControlCooledDown) {
			word = "Cooldown in effect!";
		}
		string debugText = "You said: <b>" + word + "</b>";
		Debug.Log(debugText);
		//i placed this here so that they wouldnt spam
		isSpawningMinions = true;
		isSpawningFire = true;
		isSpawningLightning = true;
		isSpawningFear = true;
		isSpawningMindControl = true;
	}
	IEnumerator MagicCoolDown(int magictype/*string magictype*/, bool hasCooled){
		switch (magictype)
		{
		case 1/*"Send in the minions"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (minionCooldown);
				hasMinionsCooleddown = true;
			}
			break;
		case 2/*"Fire"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (fireCooldown);
				hasFireCooledDown = true;
				Debug.Log ("fire has cooled");
			}
			break;
		case 3/*"Lightning"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (lightningCooldown);
				hasLightningCooledDown = true;
			}
			break;
		case 4/*"Fear"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (fearCooldown);
				hasFearCooledDown = true;
			}
			break;
		case 5/*"Mind Control"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (MindControlCooldown);
				hasMindControlCooledDown = true;
			}
			break;
		}
	}
	private void spawnMinions(){
		if (isSpawningMinions == true) {
			int tempCounter = 0;
			//Vector3 center = transform.position;
			for (int i = 0; i < numOfMinions; i++) {
				float a = -15f + i*1.5f;
				Vector3 spawnPosition = new Vector3(a, 16f, 0f);
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
	private void SpawnFear(){
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
	}
	private void OnDestroy()
	{
		if (recognizer != null && recognizer.IsRunning)
		{
			recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
			recognizer.Stop();
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