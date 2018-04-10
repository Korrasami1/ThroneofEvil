using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceCommandController : MonoBehaviour
{

	public string[] keywords = new string[] {"Send in the minions", "Fire", "Burn them alive"};
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
	//private static bool created = false;
	void Start()
	{
		if (keywords != null)
		{
			recognizer = new KeywordRecognizer(keywords, confidence);
			recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
			recognizer.Start();
		}
	}
	private void Update()
	{
		switch (word)
		{
		case "Send in the minions":
			minionSpeed = 7.5f;
			spawnMinions ();
			break;
		case "Fire":
			minionSpeed = 7.5f;
			SpawnFire ();
			break;
		case "Burn them alive":
			minionSpeed = 7.5f;
			SpawnLightning ();
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
	}
	private void spawnMinions(){
		if (isSpawningMinions == true) {
			int tempCounter = 0;
			Vector3 center = transform.position;
			for (int i = 0; i < numOfMinions; i++) {
				//Vector3 spawnPosition = new Vector3 (Random.Range (-4f, 9), -6, 0f);
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
				//Vector3 spawnPosition = new Vector3 (Random.Range (-4f, 9), -6, 0f);
				Instantiate (fire, fire.transform.position, Quaternion.identity);
			}
			isSpawningFire = false;
		}
	}
	private void SpawnLightning(){
		/*if (isSpawningLightning == true) {
			for (int i = 0; i < 1; i++) {
				//Vector3 spawnPosition = new Vector3 (Random.Range (-4f, 9), -6, 0f);
				Instantiate (Lightning, Lightning.transform.position, Quaternion.identity);
			}
			isSpawningLightning = false;
		}*/
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