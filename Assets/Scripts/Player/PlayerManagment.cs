using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagment : MonoBehaviour
{
	private int playerHealth = 5;
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
	
	public void TakeDamage(int damage)
	{
        playerHealth -= damage;
		if(playerHealth <= 0)
        {
            Debug.Log("Player is dead");
            SceneManager.LoadScene(0);
        }
		Debug.Log("Player health: "+playerHealth);

	}

	public int GetHealth()
    {
        return playerHealth;
    }

}
