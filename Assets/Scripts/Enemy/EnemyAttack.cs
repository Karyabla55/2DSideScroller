using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	public float attackRange;
	public float attackCooldown = 3f;
	public int damage1 = 15;
	public int damage2 = 20;
	public bool IsHaveSecondAttack = false;

	private int curretAttackDamage;
	private GameObject player;
	private Animator animator;
	private float nextAttackTime = 0f;
	private bool performedFirstAttack = false;
	private EnemyMovement enemyMovement; // Reference to the movement script

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		animator = GetComponent<Enemy>().animator;
		enemyMovement = GetComponent<EnemyMovement>(); // Get the movement script
	}

	void Update()
	{
		float distanceToPlayer = Vector3.Distance(transform.position, player.GetComponent<Transform>().position);

		if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
		{
			if (!performedFirstAttack)
			{
				PerformAttack1();
				performedFirstAttack = true;
				nextAttackTime = Time.time + attackCooldown / 3; // Delay for the second attack
			}
			if (IsHaveSecondAttack && performedFirstAttack && Time.time >= nextAttackTime)
			{
				PerformAttack2();
				//performedFirstAttack = false;
				nextAttackTime = Time.time + attackCooldown;
				StartCoroutine(AddDelayToTurnIdle(0.7f));

			}
			else if (performedFirstAttack && !IsHaveSecondAttack)
			{
				StartCoroutine(AddDelayToTurnIdle(0.7f));
				
			}
		}
		if (distanceToPlayer > attackRange)
		{
			animator.SetInteger("Attack", 0);
			performedFirstAttack = false;
			enemyMovement.enabled = true; // Re-enable movement if the player is out of range
		}
	}

	void PerformAttack1()
	{
		animator.SetInteger("Attack", 1); // Trigger the "draw sword from hatred" animation
		Debug.Log("Enemy performs Attack1!");
		curretAttackDamage = damage1;
		enemyMovement.enabled = false;
	}

	void PerformAttack2()
	{
		animator.SetInteger("Attack", 2);
		Debug.Log("Enemy performs Attack2!");
		curretAttackDamage = damage1;
		enemyMovement.enabled = false;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}

	private IEnumerator AddDelayToTurnIdle(float delayTime)
	{

		yield return new WaitForSeconds(delayTime);
		animator.SetInteger("Attack", 0);
		performedFirstAttack = false;

	}
	public int getCurrentDamage()
	{
		return curretAttackDamage;

	}
}
