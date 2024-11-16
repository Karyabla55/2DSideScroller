using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
	public Transform crosshair;
	private Vector3 aimDirection;
	public Weapon weapon;


	void Update()
	{

		aimDirection = crosshair.position - transform.position;

		float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

		if (crosshair.localPosition.x < 0)
		{
			transform.rotation = Quaternion.Euler(180, 0, -angle);
		}
		else if (crosshair.localPosition.x > 0)
		{
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
		if (Input.GetMouseButton(0))
		{
			weapon.shoot();

		}
		if (Input.GetKey(KeyCode.R))
		{
			weapon.reload();

		}
	}

	public Transform GetCrossPos()
	{
		return crosshair;
	}



}
