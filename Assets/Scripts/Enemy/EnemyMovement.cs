using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;
	private Animator animator;
	public GameObject playerSprite;
	
	public float chaseDistance = 15;
	public float chaseLeft = 17;

	private Transform target;
	private bool isChasing;
	private bool direction;
	private Rigidbody2D rb;

	private void Awake()
	{
		animator = GetComponent<Enemy>().animator;
	}
	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{

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


	}

	private void FixedUpdate()
	{
			// Movement
			if (isChasing)
			{
				if (Vector2.Distance(transform.position, target.position) > chaseDistance)
				{
					isChasing = false;
				}
				if (transform.position.x > target.position.x)
				{
					direction = true;
					rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
					animator.SetFloat("moveX", -1);
				}
				if (transform.position.x < target.position.x)
				{
					direction = false;
					rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
					animator.SetFloat("moveX", 1);
				}
			}
			else
			{
				if (Vector2.Distance(transform.position, target.position) < chaseDistance)
				{
					isChasing = true;
				}
				animator.SetFloat("moveX", 0);
			}
	}

}
