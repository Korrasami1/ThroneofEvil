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

	private static bool created = false;


	void Awake()
	{
		if (!created) 
		{
			DontDestroyOnLoad (this.gameObject);
			created = true;
			Debug.Log ("Awake: " + this.gameObject);
		}
	}

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
//		var x = target.transform.position.x;
//		var y = target.transform.position.y;

		switch (word)
		{
		case "Send in the minions":
			minionSpeed = 7.5f;
			break;
		case "Fire":
			minionSpeed = 7.5f;
			break;
		case "Burn them alive":
			minionSpeed = 7.5f;
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
	}

	private void OnApplicationQuit()
	{
		if (recognizer != null && recognizer.IsRunning)
		{
			recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
			recognizer.Stop();
		}
	}
}