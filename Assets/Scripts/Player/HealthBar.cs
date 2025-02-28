using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private PlayerManagment playerManagment;
    public GameObject[] healthBarImageList;

    private void Start()
    {
        playerManagment = GameObject.FindWithTag("Player").GetComponent<PlayerManagment>();
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        for (int i = 0; i < healthBarImageList.Length; i++)
        {
            if (i == playerManagment.GetHealth()-1)
            {
                healthBarImageList[i].SetActive(true);
            }
            else
            {
                healthBarImageList[i].SetActive(false);
            }
        }
    }
}
