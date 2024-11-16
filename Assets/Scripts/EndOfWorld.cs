using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfWorld : MonoBehaviour
{
	private Rigidbody2D rb;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			rb = collision.gameObject.GetComponent<Rigidbody2D>();
			rb.velocity = new Vector2(0, 0);
		}
	}
}
