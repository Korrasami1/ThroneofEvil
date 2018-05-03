using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class HighScoreBoardManager : MonoBehaviour {
	public Text[] scores;
	public Text[] Names;
	private int currentPlayerScore;
	private string currentPlayerName;
	List<PlayerScores> highscores;

	void Start () {
		readfromFile ();
		currentPlayerScore = PlayerPrefs.GetInt ("HighScore");
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
		clearFiles ();
		writeTofile ();
		writeTofile2 ();
	}

	void writeTofile(){
		for (int i = 0; i < 10; i++) {
			StreamWriter write = new StreamWriter ("textfile.txt", true);
			write.WriteLine (Names[i].text);
			write.Close ();
		}
	}
	void writeTofile2(){
		for (int i = 0; i < 10; i++) {
			StreamWriter write = new StreamWriter ("Scores.txt", true);
			write.WriteLine (scores[i].text);
			write.Close ();
		}
	}

	void clearFiles(){
		StreamWriter writer = new StreamWriter("textfile.txt", false);
		StreamWriter writer2 = new StreamWriter("Scores.txt", false);
		writer.Close();
		writer2.Close ();
	}

	void readfromFile(){
		string[] lines = System.IO.File.ReadAllLines("textfile.txt");
		string[] lines2 = System.IO.File.ReadAllLines("Scores.txt");
		for (int i = 0; i < Names.Length; i++) {
			Names [i].text = lines[i];
			scores [i].text = lines2[i];
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
