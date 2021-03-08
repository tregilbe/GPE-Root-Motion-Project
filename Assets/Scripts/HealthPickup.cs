using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public int health;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Health>() != null) // if the other object has a health component
        {
            if (other.gameObject.GetComponent<Health>().currentHealth < other.gameObject.GetComponent<Health>().maxHealth) // if current is less than max
            {               
                other.gameObject.GetComponent<Health>().Heal(health); // heal
                Destroy(this.gameObject); // Then destroy this component
            }
            else
            {
                // else do nothing
            }
        }
    }
}
