using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCollide : MonoBehaviour
{
	private PlayerManagment player;

	private void Awake()
	{
		player = GetComponentInParent<PlayerManagment>();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			player.TakeDamage(other.GetComponentInParent<EnemyAttack>().getCurrentDamage());
		}
	}
}
