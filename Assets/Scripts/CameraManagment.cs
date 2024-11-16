using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagment : MonoBehaviour
{
	public GameObject Player;
	private Transform pTransform;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	public float targetYFix;

	Rigidbody2D rb;
	Vector3 desiredPosition;

	private void Start()
	{
		rb = Player.GetComponent<Rigidbody2D>();
		pTransform = Player.GetComponent<Transform>();
	}

	void FixedUpdate()
	{
		if (rb != null)
		{
			float targetX = pTransform.position.x;
			float targetY = pTransform.position.y;
			if (rb.velocity.x > 0f)
			{
				targetX = pTransform.position.x + offset.y + 1;
			}
			else if (rb.velocity.x < 0f)
			{
				targetX = pTransform.position.x + offset.y - 2;
			}
			if (rb.velocity.y > 0f)
			{
				targetY = pTransform.position.y + offset.x + 1;
			}
			else if(rb.velocity.y < 0f)
			{
				targetY = pTransform.position.y + offset.x +1;
			}

			
			desiredPosition = new Vector3(targetX, targetY +targetYFix, transform.position.z);
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;
		}
	}

}
