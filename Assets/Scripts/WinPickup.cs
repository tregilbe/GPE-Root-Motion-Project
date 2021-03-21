using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPickup : Pickup
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // If the other object is the player
        {
            GameManager.Instance.WinGame(); // Run the Win game function from the game manager
            Destroy(this.gameObject);
        }
    }
}
