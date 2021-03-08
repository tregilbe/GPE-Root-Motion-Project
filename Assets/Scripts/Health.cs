using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Events")]
    [SerializeField, Tooltip("Raised every time the object is healed.")]
    private UnityEvent onHeal;
    [SerializeField, Tooltip("Raised every time the object is damaged.")]
    private UnityEvent onDamage;
    [SerializeField, Tooltip("Raised once when the object's health reaches 0.")]
    private UnityEvent onDie;

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

    public void Heal(float healingdone)
    {
        // If health is below max, heal
        if (currentHealth < maxHealth) 
        {
            currentHealth += healingdone;

            // If the healing goes above the max, set the current health to the max
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    public void Die()
    {
        // TODO: What happens when the object dies
        Destroy(this.gameObject); // Placeholder for death aniimation or effect
        // TODO: Add Ragdoll Effect
    }
}
