using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : Weapon
{

    public float timeBetweenShots;
    public GameObject bulletPrefab;
    public float damageDone;
    public Transform firePoint;
    private float nextShootTime;
    private bool _isShootingFullAuto; // Private varible for machine gun has _ to know it is private, aka a member variable
    [Range(0, 1)] public float accuracy;
    public float maxWeaponAccuracyAngle = 10;

    // Start is called before the first frame update
    public override void Start()
    {
        nextShootTime = Time.time;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (_isShootingFullAuto)
        {
            ShootBullet();
        }

        base.Update();
    }

    public override void AttackStart()
    {
        base.AttackStart();
    }

    public override void AttackEnd()
    {
        base.AttackEnd();
    }

    public void MuzzleFlash()
    {
        // TODO: Create muzzle flash
    }

    public void StatFullAuto()
    {
        _isShootingFullAuto = true;
    }

    public void StopFullAuto()
    {
        _isShootingFullAuto = false;
    }

    public void CheckAndDoTracer()
    {
        // TODO: Check if this is every 5th shot, if so, fire tracer instead of normal bullet
    }

    public void CheckForJam()
    {
        // TODO: Check is the jam chance roll failed -- if so, jam gun
    }

    public void Shoot3Bullets()
    {
        if (Time.time >= nextShootTime)
        {
            for (int i = 0; i < 3; i++)
            {
                // Allow me to shoot right now
                nextShootTime = Time.time;
                // Shoot
                ShootBullet();
            }
            // delay our next shot
            nextShootTime = Time.time + timeBetweenShots;
        }
    }

    public void ShootBullet()
    {
        if (Time.time >= nextShootTime)
        {
            // Instantiate a bullet and let the bullet code do the rest of the work
            GameObject myBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet myBulletScript = myBullet.GetComponent<Bullet>();

            // TODO: Send all appropriate data to the bullet
            myBulletScript.damageDone = damageDone;

            // Handle Accuracy
            float randomValue = Random.Range(0, maxWeaponAccuracyAngle);
            if (Random.value > 0.5f)
            {
                randomValue = (1 - accuracy) * randomValue;
            }
            else
            {
                randomValue = -((1 - accuracy) * randomValue);
            }
            myBullet.transform.Rotate(Vector3.up, randomValue);

            // delay our next shot
            nextShootTime = Time.time + timeBetweenShots;
        }
    }

    public void ShootRocket()
    {
        // TODO: Fire a rocket
    }

    public void AimDownScope()
    {
        // TODO: Change view to aim down scope
    }

    public void ReturnToNormalAim()
    {
        // TODO: Change view back to normal
    }
}
