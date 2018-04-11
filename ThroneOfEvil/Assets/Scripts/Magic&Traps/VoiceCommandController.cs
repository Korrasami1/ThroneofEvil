using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceCommandController : MonoBehaviour
{

	public string[] keywords = new string[] {"Send in the minions", "Fire", "Lightning"};
	public ConfidenceLevel confidence = ConfidenceLevel.Low;
	public float minionSpeed;
	protected PhraseRecognizer recognizer;
	protected string word = "Voice Commands Active";
	public GameObject minion;
	public int numOfMinions = 10;
	private bool isSpawningMinions = false;
	public GameObject fire;
	private bool isSpawningFire = false;
	public GameObject Lightning;
	private bool isSpawningLightning = false;
	private bool hasFireCooleddown, hasLightningCooleddown, hasMinionsCooleddown;
	public float MinionCooldown, fireCooldown, lightningCooldown;
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
		hasFireCooleddown = true;
		hasMinionsCooleddown = true;
		hasLightningCooleddown = true;
	}
	private void FixedUpdate()
	{
		switch (word)
		{
		case "Send in the minions":
			if (hasMinionsCooleddown == true) {
				minionSpeed = 7.5f;
				spawnMinions ();
				hasMinionsCooleddown = false;
				StartCoroutine (MagicCoolDown (1, hasMinionsCooleddown));
			}
			break;
		case "Fire":
			if (hasFireCooleddown == true) {
				minionSpeed = 7.5f;
				SpawnFire ();
				hasFireCooleddown = false;
				StartCoroutine (MagicCoolDown (2, hasFireCooleddown));
			}
			break;
		case "Lightning":
			if (hasLightningCooleddown == true) {
				minionSpeed = 7.5f;
				SpawnLightning ();
				hasLightningCooleddown = false;
				StartCoroutine (MagicCoolDown (3, hasLightningCooleddown));
			}
			break;
		case "exit":
			Application.Quit();
			break;
		}
	}
	private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		word = args.text;
		string debugText = "You said: <b>" + word + "</b>";
		Debug.Log(debugText);
		//i placed this here so that they wouldnt spam
		isSpawningMinions = true;
		isSpawningFire = true;
		isSpawningLightning = true;
	}
	IEnumerator MagicCoolDown(int magictype/*string magictype*/, bool hasCooled){
		switch (magictype)
		{
		case 1/*"Send in the minions"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (MinionCooldown);
				hasMinionsCooleddown = true;
			}
			break;
		case 2/*"Fire"*/:
			if (hasCooled == false) {
				Debug.Log ("fire cooldown activated");
				yield return new WaitForSeconds (fireCooldown);
				hasFireCooleddown = true;
				Debug.Log ("fire has cooled");
			}
			break;
		case 3/*"Lightning"*/:
			if (hasCooled == false) {
				yield return new WaitForSeconds (lightningCooldown);
				hasLightningCooleddown = true;
			}
			break;
		}
	}
	private void spawnMinions(){
		if (isSpawningMinions == true) {
			int tempCounter = 0;
			Vector3 center = transform.position;
			for (int i = 0; i < numOfMinions; i++) {
				int a = 360 / numOfMinions * i;
				Vector3 spawnPosition = RandomCircle(center, 15.0f ,a);
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
				Instantiate (Lightning, Lightning.transform.position, Quaternion.identity);
			}
			isSpawningLightning = false;
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