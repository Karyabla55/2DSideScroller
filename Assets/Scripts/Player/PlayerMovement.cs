using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float jumpForce = 10f;
	public Animator animator;
	public GameObject playerSprite;

	private bool direction;
	private Rigidbody2D rb;
	private bool isGrounded;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		// Jump
		if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}

		// Rotation
		if (direction)
		{
			//Debug.Log("Player looking left");
			playerSprite.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
		}
		else
		{
			//Debug.Log("Player looking right");
			playerSprite.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
		}
		// Animator updates
		animator.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
		animator.SetFloat("moveY", rb.velocity.y);
	}

	private void FixedUpdate()
	{
		// Movement
		rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);

		// Update direction
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			direction = false;
		}
		else if (Input.GetAxisRaw("Horizontal") < 0)
		{
			direction = true;
		}

		
		

		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("On ground");
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;

		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		Debug.Log("On Air");
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = false;
		}
	}
}