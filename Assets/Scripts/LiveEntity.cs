﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }
    public virtual void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        //Do some stuff here with var
        TakeDamage(damage);
    }

    [ContextMenu("Self Destruct")]
    protected void Die()
    {
        dead = true;
        if(OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
}