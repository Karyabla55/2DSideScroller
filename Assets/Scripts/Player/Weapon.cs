using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
	public int ammo = 7;
	public string weaponName;
	public int defAmmo = 7;
	public GameObject bulletPrefab;
	public GameObject firePoint;
	public float fireSpeed = 40f;
	public Aim aim;
	public Animator animator;

	public float shootDelay = 0.5f; // Time between each shot in seconds
	private Vector3 aimDirection;
	private bool canShoot = true; // Controls when the player can shoot

	public void shoot()
	{

		if (ammo > 0 && canShoot)
		{
			canShoot = false;
			Debug.Log("Shoot");

			// Instantiate the bullet at the fire point
			GameObject bullet = Instantiate(bulletPrefab, new Vector3( firePoint.transform.position.x, firePoint.transform.position.y,0), firePoint.transform.rotation);

			aimDirection = aim.GetCrossPos().position - transform.position;
			float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
			if (aim.GetCrossPos().localPosition.x < 0)
			{
				transform.rotation = Quaternion.Euler(180, 0, -angle);
			}
			else if (aim.GetCrossPos().localPosition.x > 0)
			{
				transform.rotation = Quaternion.Euler(0, 0, angle);
			}
			bullet.SetActive(true);
			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
			Vector2 firePointPos = firePoint.transform.position;
			Vector2 crosshairPos = aim.GetCrossPos().position;
			Vector2 direction = (crosshairPos - firePointPos).normalized; ;
			rb.velocity = direction * fireSpeed;

			ammo -= 1;
			Destroy(bullet, 1.5f); // Destroy bullet after 1.5 seconds
			animator.SetBool("Fire", true);
			StartCoroutine(AddDelay(shootDelay)); // Add the shooting delay
		}
		else if (ammo <= 0)
		{
			reload(); // Reload when out of ammo
		}
	}

	public void reload()
	{
		if (canShoot)
		{
			StartCoroutine(ReloadDelay(2f)); // Add a delay for reloading (2 seconds)
		}
	}

	// Coroutine for adding delay between shots
	private IEnumerator AddDelay(float delayTime)
	{
		//Debug.Log("ShootDelay start");
		yield return new WaitForSeconds(delayTime);
		animator.SetBool("Fire", false);
		//Debug.Log("ShootDelay end");

		canShoot = true; // Allow shooting again after the delay
	}

	// Coroutine for reloading
	private IEnumerator ReloadDelay(float delayTime)
	{
		canShoot = false; 
		Debug.Log("Reloading...");
		yield return new WaitForSeconds(delayTime);
		ammo = defAmmo; 
		Debug.Log("Reload complete");
		canShoot = true; 
	}
}
