using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRenderer : MonoBehaviour {

	Vector3 mouse;
	float w = 50f; //was 32, 70
	float h = 50f;
	public Texture cursor ;

	void Start()
	{
		Cursor.visible = false;
	}

	void Update()
	{
		mouse = new Vector3(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 0.0f);
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(mouse.x - (w / 2), mouse.y - (h / 2), w, h), cursor);
	}
}
