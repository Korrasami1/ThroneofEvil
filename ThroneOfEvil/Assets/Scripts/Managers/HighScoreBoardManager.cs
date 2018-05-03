using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighScoreBoardManager : MonoBehaviour {
	public Text[] scores;
	public Text[] Names;
	private int currentPlayerScore;
	private string currentPlayerName;
	List<PlayerScores> highscores;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("HighScore", 50);
		currentPlayerScore = PlayerPrefs.GetInt ("HighScore");
		PlayerPrefs.SetString ("PlayerName", "steve");
		currentPlayerName = PlayerPrefs.GetString ("PlayerName");
		highscores = new List<PlayerScores> ();
		//this adds the names with their scores to an array that so it can be sorted.
		for (int i = 0; i < scores.Length; i++) {
			highscores.Add (new PlayerScores () { names = Names [i].text, points = int.Parse (scores [i].text) });
		}
		highscores.Add (new PlayerScores () { names = currentPlayerName, points = currentPlayerScore });
		//sorts and collects just the top 10 players
		PlayerScores[] top10 = GetHighScores (10);

		//places the top 10 names into the scenes's text files
		for (int i = 0; i < 10; i++) {
			Names [i].text = top10 [i].names;
			scores [i].text = top10 [i].points.ToString();
		}
	}

	PlayerScores[] GetHighScores(int top10){
		return highscores.OrderBy (highscores => -highscores.points).Take (top10).ToArray ();
	}

	public struct PlayerScores{
		public int points;
		public string names;
	}
}
