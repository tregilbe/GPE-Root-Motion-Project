using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Every frame, send movement to Pawn
        pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        base.Update();

        if (Input.GetButtonDown("Fire1"))
        {
            pawn.weapon.AttackStart();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            pawn.weapon.AttackEnd();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            pawn.weapon.AltAttackStart();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            pawn.weapon.AltAttackEnd();
        }
    }
}
