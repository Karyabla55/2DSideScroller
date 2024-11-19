using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Animator animator;
	public float health = 100;

	private EnemyMovement enemyMovement;
	private EnemyAttack enemyAttack;

	private void Start()
	{
		enemyMovement = GetComponent<EnemyMovement>();
		enemyAttack = GetComponent<EnemyAttack>();
	}
	private void Update()
	{
		if (health <= 0)
		{
			animator.SetBool("isAlive", false);
			enemyMovement.enabled = false;
			enemyAttack.enabled = false;
			Destroy(gameObject,4f);
		}
	}
	public void TakeDamage(float damage)
	{
		enemyMovement.enabled = false;
		this.health -= damage;
		Debug.Log("Damage Taken");
		Debug.Log("Enemy's health:"+ health);
		animator.SetBool("TakeHit",true);
		StartCoroutine(TakingHit(0.7f));
	}

	private IEnumerator TakingHit(float delayTime)
	{

		yield return new WaitForSeconds(delayTime);
		animator.SetBool("TakeHit", false);
		enemyMovement.enabled = false;

	}
}
