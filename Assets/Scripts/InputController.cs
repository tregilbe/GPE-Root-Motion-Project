using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    // private Animator anim;

    // Start is called before the first frame update
    public override void Start()
    {
        // anim = GetComponent<Animator>();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // anim.SetFloat("Forward", Input.GetAxis("Vertical"));
        // anim.SetFloat("Right", Input.GetAxis("Horizontal"));

        // Every frame, send movement to Pawn
        pawn.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        base.Update();
    }
}
