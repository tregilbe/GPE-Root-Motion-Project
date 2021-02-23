using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidPawn : Pawn
{
    // Animator
    [Header("Components")]
    [SerializeField] private Animator _anim;
    [Header("Data")]
    public float speed = 1;
    public Weapon weapon;

    // Start is called before the first frame update
    public override void Start()
    {
        // Load our components
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {

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
        
        if (Input.GetKeyDown(KeyCode.Space)) // If the player presses Space, run this
        {
            // Activate the trigger to start the jump animaton
            _anim.SetTrigger("Jump");
        }
    }

    public void OnAnimatorIK(int layerIndex)
    {
        // Onyl works if IK PASS is on for that layer

        // If I have no weapon, don't do IK - DO LECTURES ON SHELL

        // NOTE: I am assuming we have a weapon ad it is both right and left hand points
        // If not, this fails -- DON'T DO THIS ! MAKE IF STATEMENTS TO MAKE THIS FAILSAFE

        _anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHadPoint.position);
        _anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
        _anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHadPoint.rotation);
        _anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);

        _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

    }

}
