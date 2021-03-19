using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    public bool Pistol;
    public bool Shotgun;
    public bool Rifle; 

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
        if (other.gameObject.GetComponent<HumanoidPawn>() != null && other.gameObject.GetComponent<Health>().currentHealth > 0) // If the other game object has a humanoid pawn script
        {
            if (Pistol == true) // If this is a pistol
            {
                other.gameObject.GetComponent<HumanoidPawn>().EquipPistol();
            }

            if (Shotgun == true) // If this is a Shotgun
            {
                other.gameObject.GetComponent<HumanoidPawn>().EquipShotgun();
            }

            if (Rifle == true) // If this is a Rifle
            {
                other.gameObject.GetComponent<HumanoidPawn>().EquipRifle();
            }

            Destroy(this.gameObject); // Destroy this object, as the event system handles it
        }
    }
}
