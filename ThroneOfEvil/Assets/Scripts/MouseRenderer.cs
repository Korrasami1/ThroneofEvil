﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRenderer : MonoBehaviour {

	Vector3 mouse;
	float w = 120f; //was 32, 70
	float h = 120f;
	public Texture[] cursor;
	public int cursorChangeNum = 0;

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
		if (cursorChangeNum == 0) {
			GUI.DrawTexture (new Rect (mouse.x - (w / 2), mouse.y /*- (h / 2)*/, w, h), cursor [cursorChangeNum]);
		} else {
			GUI.DrawTexture (new Rect (mouse.x - (w / 2), mouse.y - (h / 2), w, h), cursor [cursorChangeNum]);
			Debug.Log ("other numebr");
		}
	}
}
