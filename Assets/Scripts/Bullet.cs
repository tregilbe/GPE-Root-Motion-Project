using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireSpeed;
    public float damageDone;
    public GameObject owner;
    public Transform origin;
    public float lifespan = 1.5f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Set my lifespan so I destro after time
        Destroy(gameObject, lifespan);

        // Start our bullet moving forward method 1 with rigidbody
        //  Unity physics take over, Tank game used this
        rb = GetComponent<Rigidbody>();
        // rb.velocity = transform.forward * fireSpeed;  
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPaused)
            return;

        // Move bullet forward with transform per frame method 2
        transform.position += transform.forward * (fireSpeed * Time.deltaTime); // Using this method cause it uses time.deltatime
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
        // Add force to the object i there is a rigidbody
        if (otherObject.GetComponent<Rigidbody>() != false)
        {
            if (otherObject.tag != "Enemy" && otherObject.tag != "Player") // Do not add force if the object is tagged as a player or Enemy
            {
                // otherObject.GetComponent<Rigidbody>().AddForce((transform.position - Camera.main.transform.position).normalized * 50);
                // otherObject.GetComponent<Rigidbody>().AddForceAtPosition(gameObject.transform.forward * 50f, otherObject, ForceMode.VelocityChange);
                // Vector3 forceDirection = (origin.transform.position - gameObject.transform.position);
                // otherObject.GetComponent<Rigidbody>().AddRelativeForce(forceDirection, ForceMode.VelocityChange);
            }
        }

        // Destroy this bullet
        Destroy(gameObject);
    }
}
