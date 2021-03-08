using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : Pickup
{
    public int damage;
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
            other.gameObject.GetComponent<Health>().TakeDamage(damage); // deal damage
            Destroy(this.gameObject); // Then destroy this component
        }
    }
}
