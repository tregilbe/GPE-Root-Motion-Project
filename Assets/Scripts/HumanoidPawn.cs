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

    // Ragdoll 
    private Rigidbody[] childRigidbodies;
    private Collider[] childColliders;
    private Collider topCollider;
    private Rigidbody topRigidbody;
    // Also needs animator, already have it as _anim

    // Boolean for cheats
    public bool CheatsEnabled = false;

    // Boolean for starting weapon
    public bool StartWithPistol = false;
    public bool StartWithRifle = false;
    public bool StartWithShotgun = false;

    // Start is called before the first frame update
    public override void Start()
    {
        // Load our components
        _anim = GetComponent<Animator>();

        // Get our main collider and rigidbody
        topCollider = GetComponent<Collider>();
        topRigidbody = GetComponent<Rigidbody>();

        // Get our child components (Note: Also includes self!)
        childColliders = GetComponentsInChildren<Collider>();
        childRigidbodies = GetComponentsInChildren<Rigidbody>();

        // If a starting weapon is choosen, equip it
        if (StartWithPistol == true)
        {
            EquipPistol();
        }
        else if (StartWithRifle == true)
        {
            EquipRifle();
        }
        else if (StartWithShotgun == true)
        {
            EquipShotgun();
        }

        // Stop Ragdoll at start
        StopRagdoll();
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

        if (CheatsEnabled == true)
        {
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

    public void StartRagdoll()
    {
        // Turn on all child colliders
        foreach (Collider collider in childColliders)
        {
                collider.enabled = true;          
        }

        // Turn on all child rigidbodies
        foreach (Rigidbody rb in childRigidbodies)
        {
            rb.isKinematic = false;
        }

        // Turn off animator
        _anim.enabled = false;

        // Turn off top collider
        topCollider.enabled = false;

        // Turn off my top rigidbody
        topRigidbody.isKinematic = true;

        // Turn off aim at mouse
        if (this.GetComponent<AimAtMouse>() != null)
        {
            this.GetComponent<AimAtMouse>().enabled = false;
        }

        // turn off current weapon if any
        if (weapon != null)
        {
            UnequipWeapon();
        }

        // Remove target, to disable movement
        if (this.GetComponent<AIController>() != null)
        {
            this.GetComponent<AIController>().target = null;
        }
    }

    public void StopRagdoll()
    {
        // Turn off all child colliders
        foreach (Collider collider in childColliders)
        {
            collider.enabled = false;
        }

        // Turn off all child rigidbodies
        foreach (Rigidbody rb in childRigidbodies)
        {
            rb.isKinematic = true;
        }

        // Turn on top collider
        topCollider.enabled = true;

        // Turn on my top rigidbody
        topRigidbody.isKinematic = false;

        // Turn on animator
        _anim.enabled = true;

        // Turn on aim at mouse
        if (this.GetComponent<AimAtMouse>() != null)
        {
            this.GetComponent<AimAtMouse>().enabled = true;
        }

        // turn on current weapon if any
        if (weapon != null)
        {
            weapon.enabled = true;
        }
    }
}
