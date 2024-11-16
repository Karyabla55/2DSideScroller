using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float bulletDamage = 5f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(bulletDamage);
			}
		}
		Destroy(gameObject);
	}

}
