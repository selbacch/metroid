﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector] public PlayerMovement pm;
    public int curHealth = 0;
    public int maxHealth = 100;
    public bool hit = false;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamagePlayer(10);
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        hit = true;

        healthBar.SetHealth(curHealth);
    }

    public void hitOff() { hit = false; }


}