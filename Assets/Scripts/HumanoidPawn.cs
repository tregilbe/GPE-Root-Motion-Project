using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidPawn : Pawn
{
    // Animator
    [SerializeField] private Animator _anim;
    public float speed = 1;

    // Aiming cursor
    public Transform target;
    public float rotationSpeed = 90f;

    // Start is called before the first frame update
    public override void Start()
    {
        // Load our components
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public override void Move(Vector3 moveDirection)
    {
        // To make things fair for joysticks, limit my max distance of my move vector to 1
        moveDirection = moveDirection.normalized;

        // Convert the moveDirection from "stickSpace" to direction based on player rotation
        moveDirection = transform.InverseTransformDirection(moveDirection);

        // Set our animation parameters based on the move direction data
        _anim.SetFloat("Forward", moveDirection.z * speed);
        _anim.SetFloat("Right", moveDirection.x * speed);
        base.Move(moveDirection);
    }
}
