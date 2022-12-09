using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    [SerializeField]
    GameObject[] targets;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
