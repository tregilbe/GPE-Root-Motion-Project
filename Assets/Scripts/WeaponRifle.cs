using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : Weapon
{
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

    public void CheckAndDoTracer()
    {
        // TODO: Check if this is every 5th shot, if so, fire tracer instead of normal bullet
    }

    public void CheckForJam()
    {
        // TODO: Check is the jam chance roll failed -- if so, jam gun
    }

    public void ShootBullet()
    {
        // TODO: Instantiate a bullet and let the bullet code do the rest of the work
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
