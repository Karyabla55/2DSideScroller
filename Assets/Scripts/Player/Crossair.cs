using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossair : MonoBehaviour
{
	private Camera mainCam;

	void Start()
	{
		mainCam = Camera.main; // Get the main camera
	}

	void Update()
	{
		// Get the mouse position in world space
		Vector3 mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));

		// Update the crosshair's position to the mouse position
		transform.position = new Vector3(mousePos.x, mousePos.y, mousePos.z);
	}



}
