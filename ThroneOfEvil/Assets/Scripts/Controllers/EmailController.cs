using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmailController : MonoBehaviour {

	public Text debugText;
	//public Text QuestionOne;
	public string questionOneAnswer;
	//public string questionTwoAnswer;
	public InputField QuestionOneInput;



	void Start(){
		//QuestionOne.text = GetComponent<Text>().text; 
		//QuestionOneInput.text = questionOneAnswer; 
		//		_valueTestBoulder = PlayerPrefs.GetFloat("valueTestBoulder");
	}

	void Update (){
		//QuestionOneInput.text = "write text here"; 
		//QuestionOne = "Write Question here";
		//QuestionOneInput.text = questionOneAnswer; 

	}


	public void Gmailsender ()
	{


		string FilePath = "";
		string AttachmentName = "test.txt";
		string FileName = "test.txt";
		//string Screenshot = "ScreenShot.PNG";
		FilePath = string.Format (@"", AttachmentName);
		FilePath = Application.persistentDataPath + "/" + AttachmentName;
		Debug.Log (FilePath);
		MailMessage mail = new MailMessage ();
		mail.From = new MailAddress ("malefisheepfeedback@gmail.com");
		mail.To.Add ("kontakt@erikrosenberg.se");
		mail.Subject = "Throne of Evil Feedback";
		mail.Body = "This is where we want to add the inputs and so on";
		Attachment data = new Attachment (FileName, System.Net.Mime.MediaTypeNames.Application.Octet);
		//Attachment screendata = new Attachment (Screenshot, System.Net.Mime.MediaTypeNames.Application.Octet);
		// Add time stamp information for the file.
		System.Net.Mime.ContentDisposition disposition = data.ContentDisposition;
		disposition.CreationDate = System.IO.File.GetCreationTime (FileName);
		disposition.ModificationDate = System.IO.File.GetLastWriteTime (FileName);
		disposition.ReadDate = System.IO.File.GetLastAccessTime (FileName);
		mail.Attachments.Add (data);
		//mail.Attachments.Add (screendata);
		SmtpClient smtpServer = new SmtpClient ("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential ("malefisheepfeedback@gmail.com", "feedback123") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			return true;
		};
		smtpServer.Send (mail);
		Debug.Log ("success");

	}
	public void questionOneInputField(string newStringOne){

		QuestionOneInput.GetComponent<InputField>().lineType = InputField.LineType.MultiLineNewline;
		questionOneAnswer = newStringOne;
		//questionTwoAnswer = newStringOne;
		//Debug.Log("value update" + newValueSpeed);
		//Debug.Log("Answer on question one is: " + questionOneAnswer);

	}


	public void QuestionOneSend(){
		//writes the question to text file
		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);

		writer.WriteLine("Answer to the question 1 is: " + questionOneAnswer);
		//writer.WriteLine("question Two is: " + questionTwoAnswer);

		writer.Close();
		Debug.Log("Question answer 1 is:  " + questionOneAnswer);
		//Debug.Log("Question two answer is:  " + questionTwoAnswer);

	}
	public void QuestionTwoSend(){
		//writes the question to text file
		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);

		writer.WriteLine("Answer to the question 2 is: " + questionOneAnswer);
		//writer.WriteLine("question Two is: " + questionTwoAnswer);

		writer.Close();
		Debug.Log("Question answer  2  is:  " + questionOneAnswer);
		//Debug.Log("Question two answer is:  " + questionTwoAnswer);

	}
	public void QuestionThreeSend(){
		//writes the question to text file
		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);

		writer.WriteLine("Answer to the question 3 is: " + questionOneAnswer);
		//writer.WriteLine("question Two is: " + questionTwoAnswer);

		writer.Close();
		Debug.Log("Question answer  3  is:  " + questionOneAnswer);
		//Debug.Log("Question two answer is:  " + questionTwoAnswer);

	}
	public void QuestionFourSend(){
		//writes the question to text file
		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);

		writer.WriteLine("Answer to the question 4 is: " + questionOneAnswer);
		//writer.WriteLine("question Two is: " + questionTwoAnswer);

		writer.Close();
		Debug.Log("Question answer  4  is:  " + questionOneAnswer);
		//Debug.Log("Question two answer is:  " + questionTwoAnswer);

	}
	// -----------------------------------------------------------------------------------------
	public void ButtonOneClickQOne(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Tar Trap? Player scored it: 1 ");
		writer.Close();
		Debug.Log("How useful was the Tar Trap? Player scored it: 1");

	}
	public void ButtonTwoClickQOne(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Tar Trap? Player scored it: 2 ");
		writer.Close();


	}
	public void ButtonThreeClickQOne(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Tar Trap? Player scored it: 3 ");
		writer.Close();


	}
	public void ButtonFourClickQOne(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Tar Trap? Player scored it: 4 ");
		writer.Close();


	}
	public void ButtonFiveClickQOne(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Tar Trap? Player scored it: 5 ");
		writer.Close();


	}

	// -----------------------------------------------------------------------------------------
	public void ButtonOneClickQTwo(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Freezing Trap? Player scored it: 1 ");
		writer.Close();
		Debug.Log("How useful was the Freezing Trap? Player scored it: 1");

	}
	public void ButtonTwoClickQTwo(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Freezing Trap? Player scored it: 2 ");
		writer.Close();


	}
	public void ButtonThreeClickQTwo(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Freezing Trap? Player scored it: 3 ");
		writer.Close();


	}
	public void ButtonFourClickQTwo(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Freezing Trap? Player scored it: 4 ");
		writer.Close();


	}
	public void ButtonFiveClickQTwo(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Freezing Trap? Player scored it: 5 ");
		writer.Close();


	}
	// -----------------------------------------------------------------------------------------
	public void ButtonOneClickQThree(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Boulder? Player scored it: 1 ");
		writer.Close();
		Debug.Log("How useful was the Boulder? Player scored it: 1");

	}
	public void ButtonTwoClickQThree(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Boulder? Player scored it: 2 ");
		writer.Close();


	}
	public void ButtonThreeClickQThree(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Boulder? Player scored it: 3 ");
		writer.Close();


	}
	public void ButtonFourClickQThree(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Boulder? Player scored it: 4 ");
		writer.Close();


	}
	public void ButtonFiveClickQThree(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Boulder? Player scored it: 5 ");
		writer.Close();


	}
	// -----------------------------------------------------------------------------------------
	public void ButtonOneClickQFour(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Lightning Bolt Player scored it: 1 ");
		writer.Close();
		Debug.Log("How useful was the Lightning Bolt Player scored it: 1");

	}
	public void ButtonTwoClickQFour(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Lightning Bolt Player scored it: 2 ");
		writer.Close();


	}
	public void ButtonThreeClickQFour(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Lightning Bolt Player scored it: 3 ");
		writer.Close();


	}
	public void ButtonFourClickQFour(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Lightning Bolt Player scored it: 4 ");
		writer.Close();


	}
	public void ButtonFiveClickQFour(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Lightning Bolt Player scored it: 5 ");
		writer.Close();


	}
	// -----------------------------------------------------------------------------------------
	public void ButtonOneClickQFive(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Fireball? Player scored it: 1 ");
		writer.Close();
		Debug.Log("How useful was the Fireball? Player scored it: 1");

	}
	public void ButtonTwoClickQFive(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Fireball? Player scored it: 2 ");
		writer.Close();


	}
	public void ButtonThreeClickQFive(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Fireball? Player scored it: 3 ");
		writer.Close();


	}
	public void ButtonFourClickQFive(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Fireball? Player scored it: 4 ");
		writer.Close();


	}
	public void ButtonFiveClickQFive(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("How useful was the Fireball? Player scored it: 5 ");
		writer.Close();


	}
	// -----------------------------------------------------------------------------------------

	public void ResetTextFile(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, false);
		//writer.WriteLine(""); //adds a emty row
		writer.Close();

	}

}