using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;

	private void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
	public void TakeDamage(float damage)
	{
		this.health -= damage;
		Debug.Log("Damage Taken");
		Debug.Log("Enemy's health:"+ health);
	}
}
