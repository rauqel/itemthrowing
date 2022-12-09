using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealth : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    int maxHealth;
    public Slider healthBar;

    [Header("References")]
    public KnifeStickScript tkDamageScript;
    public KnifeStickScript sbDamageScript;

    private void Start()
    {
        healthBar.gameObject.SetActive(false);
        maxHealth = health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        healthBar.value = health;

        if(health < maxHealth)
        {
            healthBar.gameObject.SetActive(true);
        }
       
    }
}
