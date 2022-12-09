using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damageDealt;
    private bool targetHit;

    [Header("References")]
    public ThrowingThings throwScript;

    [Header("Health")]
    [SerializeField]
    GameObject[] target;
    int currentHealth;
    int maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            //Destroy(target);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            if (targetHit)

                return;
            else
                targetHit = true;

            currentHealth -= damageDealt;
        }
    }
}
