using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    public GameObject target;
    private NavMeshAgent agent;
    private Animator anim;

    // Start is called before the first frame update
    public override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = pawn.GetComponent<Animator>();
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

        base.Update();
    }

    // OnAnimtorMove runs after the animator has finished determining its changes
    public void OnAnimatorMove()
    {
        agent.velocity = anim.velocity;
    }
}
