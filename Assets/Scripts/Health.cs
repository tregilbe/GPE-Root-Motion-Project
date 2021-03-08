using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float damageDone)
    {
        // Subtract from health
        currentHealth -= damageDone;
        // If health <0, then die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // TODO: Wht happens when the object dies
        Destroy(this.gameObject); // Placeholder for death aniimation or effect
        // TODO: Add Ragdoll Effect
    }
}
