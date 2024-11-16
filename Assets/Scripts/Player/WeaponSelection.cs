using System;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
	private PlayerManagment PlayerManagment;

	private void Awake()
	{
		PlayerManagment = GetComponent<PlayerManagment>();
	}

	// Update is called once per frame
	void Update()
	{
		var v = Input.GetAxis("Mouse ScrollWheel");
		if (v < 0)
		{
			Console.WriteLine("up");
			if (PlayerManagment.currentWeapon == PlayerManagment.WeaponPrefabs.Length - 1)
			{
				PlayerManagment.currentWeapon = 0;
				Console.WriteLine("up");
			}
			else
				PlayerManagment.currentWeapon++; Console.WriteLine("up");
		}
		else if (v > 0)
		{
			Console.WriteLine("up");
			if (PlayerManagment.currentWeapon == 0)
			{
				PlayerManagment.currentWeapon = PlayerManagment.WeaponPrefabs.Length - 1;
			}
			else
				PlayerManagment.currentWeapon--;
		}


	}
}
