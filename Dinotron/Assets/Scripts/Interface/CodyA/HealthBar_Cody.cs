﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar_Cody : MonoBehaviour 
{
	//Public Variables ------------------------------------------
	public Image fillImage;

	[Header("Drag Dino's Damageable script here")]
	public PrototypeDamageable damageableScript;
	[Tooltip("Does this health bar go over an enemy?")]
	public bool isEnemy;

	//Private Variables -----------------------------------------
	Color fillColor;

	//-----------------------------------------------------------
	void Awake()
	{
		fillImage.fillAmount = 1;
		fillColor = fillImage.color;

		damageableScript.onHealthChange += RemoveHealth;

		//Add couroutine for healthpickup here
//		HealthPickUp.passHealth += AddHealth;
	}

	void AddHealth(float _health)
	{
		fillImage.fillAmount += _health;

		if (!isEnemy) 
		{
			if (fillColor.g < 1)
				fillColor.g += 2 * _health;
			else
				fillColor.r -= 2 * _health;

			if (fillColor.r < 0)
			{
				fillColor.r = 0;
				fillColor.g = 1;
			}

			fillImage.color = fillColor;
		}
	}

	void RemoveHealth(float currentHealth, float maxHealth)
	{
        float _health = 1f - (currentHealth / maxHealth);

		fillImage.fillAmount -= _health;

		if (!isEnemy) 
		{
			if (fillColor.r < 1)
				fillColor.r += 2 * _health;
			else
				fillColor.g -= 2 * _health;

			if (fillColor.g < 0)
			{
				fillColor.g = 0;
				fillColor.r = 1;
			}

			fillImage.color = fillColor;
		}
	}
}