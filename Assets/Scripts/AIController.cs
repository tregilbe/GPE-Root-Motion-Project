using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    public GameObject target;
    private NavMeshAgent agent;
    private Animator anim;

    public float rotationSpeed = 45f;

    // Start is called before the first frame update
    public override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = pawn.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Create a path to our target
        agent.SetDestination(target.transform.position);

        // Pass that to my pawn
        pawn.Move(agent.desiredVelocity);

        // NOTE: At this point, both the animator and the navmesh agent are moving

        // Test the fire funcion
        if (pawn.weapon != null)
        {
            pawn.weapon.AttackStart();
        }

        // Rotate towards player
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        base.Update();
    }

    // OnAnimtorMove runs after the animator has finished determining its changes
    public void OnAnimatorMove()
    {
        agent.velocity = anim.velocity;
    }
}
