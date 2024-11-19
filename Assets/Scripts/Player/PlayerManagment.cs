using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagment : MonoBehaviour
{
	private float playerHealth = 100;
	public PlayerMovement movement;
    public GameObject[] WeaponPrefabs;
	public GameObject crosshair;
	public float weaponOffsetY;
	public int currentWeapon = 0; 

	private GameObject Weapon;
	private void Awake()
	{
		Weapon = Instantiate(WeaponPrefabs[currentWeapon], transform.parent);
		Weapon.GetComponent<Aim>().crosshair = crosshair.transform;
	}
	private void Update()
	{
		if (Weapon.GetComponent<Weapon>().weaponName != WeaponPrefabs[currentWeapon].GetComponent<Weapon>().weaponName)
		{
			Debug.Log("Changing weapon");
			ChangeWeapon();
		}
			Weapon.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + weaponOffsetY, transform.position.z);
	}

	public void ChangeWeapon()
	{
		Destroy(Weapon);
		Weapon = Instantiate(WeaponPrefabs[currentWeapon], transform.parent);
		Weapon.GetComponent<Aim>().crosshair = crosshair.transform;
	}
	
	public void TakeDamage(float damage)
	{
		playerHealth -= damage;
		Debug.Log("Player health: "+playerHealth);

	}

}
