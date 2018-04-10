using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;

public class EmailController : MonoBehaviour {

	//public int asdasd;



	public void Gmailsender ()
	{
		string FilePath = "";
		string AttachmentName = "test.txt";
		string FileName = "test.txt";
		FilePath = string.Format(@"", AttachmentName);
		FilePath = Application.persistentDataPath + "/" + AttachmentName;
		Debug.Log (FilePath);
		MailMessage mail = new MailMessage();
		mail.From = new MailAddress("malefisheepfeedback@gmail.com");
		mail.To.Add("kontakt@erikrosenberg.se");
		mail.Subject = "Throne of Evil Feedback";
		mail.Body = "This is where we want to add the inputs and so on";
		Attachment data = new Attachment(FileName, System.Net.Mime.MediaTypeNames.Application.Octet);

		// Add time stamp information for the file.
		System.Net.Mime.ContentDisposition disposition = data.ContentDisposition;
		disposition.CreationDate = System.IO.File.GetCreationTime(FileName);
		disposition.ModificationDate = System.IO.File.GetLastWriteTime(FileName);
		disposition.ReadDate = System.IO.File.GetLastAccessTime(FileName);
		mail.Attachments.Add(data);
		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("malefisheepfeedback@gmail.com", "feedback123") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
		smtpServer.Send(mail);
		Debug.Log("success");
	}


	public void ButtonOneClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 1");
		writer.Close();

	}
	public void ButtonTwoClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 2");
		writer.Close();

	}
	public void ButtonThreeClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 3");
		writer.Close();

	}
	public void ButtonFourClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 4");
		writer.Close();

	}
	public void ButtonFiveClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 5");
		writer.Close();

	}
	public void ButtonSixClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 6");
		writer.Close();

	}
	public void ButtonSevenClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 7");
		writer.Close();

	}
	public void ButtonEightClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 8");
		writer.Close();

	}
	public void ButtonNineClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 9");
		writer.Close();

	}
	public void ButtonTenClick(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Player Scored The GamePlay 10");
		writer.Close();

	}
	public void ResetTextFile(){

		string path = "test.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, false);
		writer.WriteLine(""); //adds a emty row
		writer.Close();

	}

//	public void asdasdasd(){
//		asdasd = PlayerPrefs.GetInt ("Enemy");
//
//		string path = "test.txt";
//		//Write some text to the test.txt file
//		StreamWriter writer = new StreamWriter(path, true);
//		writer.WriteLine(asdasd); //adds a emty row
//		writer.Close();
//
//	}
	
//	public void Writetotextfile()
//	{
//		string path = "test.txt";
//		//Write some text to the test.txt file
//		StreamWriter writer = new StreamWriter(path, true);
//		writer.WriteLine("First row added");
//		writer.WriteLine("Second row added");
//		writer.Close();
//	}
}