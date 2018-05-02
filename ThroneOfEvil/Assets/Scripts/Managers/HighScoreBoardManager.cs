using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighScoreBoardManager : MonoBehaviour {
	public Text[] scores;
	public Text[] Names;
	private int currentPlayerScore;
	private int[] score;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("HighScore", 50);
		currentPlayerScore = PlayerPrefs.GetInt ("HighScore");
		Debug.Log (scores[0].text);
		for (int i = 0; i < scores.Length; i++) {
			score [i] = int.Parse(scores [i].text);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (int sort in score.OrderBy(score=>score))
		{
			Debug.Log(sort);
		}
	}
}
