using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
	public GameObject camera;
	public float parallaxEffectX;
	public float parallaxEffectY;

	private float length, startposX, startposY;

	private void Start()
	{
		startposX = transform.position.x;
		startposY = transform.position.y;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	private void FixedUpdate()
	{
		float tempX = (camera.transform.position.x * (1 - parallaxEffectX)); // Relative to camera movement
		float distX = (camera.transform.position.x * parallaxEffectX); // Parallax effect X

		float distY = (camera.transform.position.y * parallaxEffectY); // Parallax effect Y

		// Update the background position based on parallax effect
		transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);

		// If the camera moves too far, reset the position for seamless looping
		if (tempX > startposX + length)
		{
			startposX += length;
		}
		else if (tempX < startposX - length)
		{
			startposX -= length;
		}
	}
}
