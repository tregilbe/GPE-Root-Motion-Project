using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float damageDone;
    public float fireSpeed;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        // Create the bullet gameobject
        GameObject myBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;

        // Get the Bullet Component from that Object
        Bullet myBulletScript = myBullet.GetComponent<Bullet>();

        // Set the data for that bullet
        myBulletScript.damageDone = damageDone;
        myBulletScript.fireSpeed = fireSpeed;
        myBulletScript.owner = this.gameObject;
    }
}
