using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponPickup : Pickup
{
    [Header("Events")]
    [SerializeField, Tooltip("Which Weapon to equip.")]
    public UnityEvent onEquip;
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
        if (other.gameObject.GetComponent<HumanoidPawn>() != null) // If the other ame object has a humanoid pawn script
        {
            Destroy(this.gameObject); // Destroy this object, as the event system handles it
        }
    }
}
