﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public int maxHP = 3;

    public float maxShield = 100;
    
    public float shieldRechargeRate = 2f;

    public int currentHP;
    public float currentShield;

    private HpBar hpUIController;
    private Slider shieldSlider;

    private bool shielded;

    private bool recharging;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        currentShield = maxShield;

        hpUIController = GameObject.Find("Health Bar").GetComponent<HpBar>();

        shielded = false;
        recharging = false;
    }

    private void Update()
    {
        Recharge();
    }

    private void Recharge()
    {
        if (recharging)
        {
            if (currentShield < maxShield)
            {
                currentShield += shieldRechargeRate * Time.deltaTime;
            }

            if (currentShield > maxShield)
            {
                currentShield = maxShield;
            }
        }
    }

    public void TakeDamage(int dmg)
    {
        if (!shielded)
        {
            currentHP -= dmg;
            hpUIController.updateHealth(dmg);
        }
        else
        {
            currentShield -= dmg * 10;
        }

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ActivateShield()
    {
        shielded = true;
    }

    public void DeactivateShield()
    {
        shielded = false;
    }

    public void ActivateRecharge()
    {
        recharging = true;
    }

    public void DeactivateRecharge()
    {
        recharging = false;
    }
}
