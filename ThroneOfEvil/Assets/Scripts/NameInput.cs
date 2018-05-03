using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {
	string[] alphabet;
	public InputField l1, l2, l3, l4;
	public GameObject n1, n2, n3, n4;
	int AlphaNum = 0;
	// Use this for initialization
	void Start () {
		alphabet = new string[27]{"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","-"};
		n1.SetActive (false);
		n2.SetActive (false);
		n3.SetActive (false);
		n4.SetActive (false);
		gameObject.SetActive (true);
	}
		
	public void changeLetterUp(InputField Alpha){
		AlphaNum++;
		if (AlphaNum < 0) {
			AlphaNum = alphabet.Length-1;
			Alpha.text = alphabet [AlphaNum];
		} else if (AlphaNum >= alphabet.Length) {
			AlphaNum = 0;
			Alpha.text = alphabet [AlphaNum];
		} else {
			Alpha.text = alphabet [AlphaNum];
		}
	}
	public void changeLetterDown(InputField Alpha){
		AlphaNum--;
		if (AlphaNum <= -1) {
			AlphaNum = alphabet.Length-1;
			Alpha.text = alphabet [AlphaNum];
		} else if (AlphaNum >= alphabet.Length) {
			AlphaNum = 0;
			Alpha.text = alphabet [AlphaNum];
		} else {
			Alpha.text = alphabet [AlphaNum];
		}
	}

	public void setName(){
		string name = l1.text + l2.text + l3.text + l4.text;
		PlayerPrefs.SetString ("PlayerName", name);
		Debug.Log (name);
		n1.SetActive (true);
		n2.SetActive (true);
		n3.SetActive (true);
		n4.SetActive (true);
		gameObject.SetActive (false);
	}
}
