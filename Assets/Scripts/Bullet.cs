using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireSpeed;
    public float damageDone;
    public GameObject owner;
    public float lifespan = 1.5f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Set my lifespan so I destro after time
        Destroy(gameObject, lifespan);

        // Start our bullet moving forward method 1 with rigidbody
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * fireSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Move bullet forward with transform per frame
        // transform.position += transform.forward * (fireSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        // Get the object we hit
        GameObject otherObject = other.gameObject;

        // If it has health, tell it to take damage
        Health otherHealth = otherObject.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone);
        }

        // TODO: Whatever a bullet does when it hitsthat I forgot to add

        // Destroy this bullet
        Destroy(gameObject);
    }
}
