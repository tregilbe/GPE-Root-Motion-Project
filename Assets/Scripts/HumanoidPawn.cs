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
    [Range(0, 1)] public float accuracy;
    // public Weapon weapon;
    public Transform PistolAttachPoint;
    public Transform RifleAttachPoint;
    public Transform ShotgunAttachPoint;
    public Weapon Pistol;
    public Weapon Rifle;
    public Weapon Shotgun;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipPistol();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipRifle();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipShotgun();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UnequipWeapon();
        }
    }

    public void OnAnimatorIK(int layerIndex)
    {
        // If I have no weapon, don't do IK 
        if (!weapon)
            return;

        if (weapon.rightHandPoint) // if weapon has a right hand point, use it - set pos and rot
        {
            _anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            _anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);
            _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }
        else // If there is no right hand, go to default position
        {
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
        }

        if (weapon.leftHandPoint) // if weapon has a left hand point, use it - set pos and rot
        {
            _anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            _anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
            _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        }
        else // If there is no left hand, go to default position
        {
            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
        }
    }

    public void EquipPistol()
    {
        if (weapon != null)
        {
            UnequipWeapon();
        }

        weapon = Instantiate(Pistol) as Weapon;

        weapon.transform.SetParent(PistolAttachPoint);

        weapon.transform.localPosition = PistolAttachPoint.transform.localPosition;
        weapon.transform.localRotation = PistolAttachPoint.transform.localRotation;
    }

    public void EquipRifle()
    {
        if (weapon != null)
        {
            UnequipWeapon();
        }

        weapon = Instantiate(Rifle) as Weapon;

        weapon.transform.SetParent(ShotgunAttachPoint);

        weapon.transform.localPosition = RifleAttachPoint.transform.localPosition;
        weapon.transform.localRotation = RifleAttachPoint.transform.localRotation;
    }

    public void EquipShotgun()
    {
        if (weapon != null)
        {
            UnequipWeapon();
        }

        weapon = Instantiate(Shotgun) as Weapon;

        weapon.transform.SetParent(ShotgunAttachPoint);

        weapon.transform.localPosition = ShotgunAttachPoint.transform.localPosition;
        weapon.transform.localRotation = ShotgunAttachPoint.transform.localRotation;
    }

    public void UnequipWeapon()
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
            weapon = null;
        }
    }
}
