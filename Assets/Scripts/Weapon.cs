using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [Header("IK Points")]
    public Transform rightHandPoint;
    public Transform leftHandPoint;

    [Header("Firing Events")]
    public UnityEvent OnAttackStart;
    public UnityEvent OnAttackEnd;
    public UnityEvent OnAltAttackStart;
    public UnityEvent OnAltAttackEnd;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void AttackStart()
    {
        // TODO: This is what happens when I pull ANY trigger / start any attack
        OnAttackStart.Invoke();
    }

    public virtual void AttackEnd()
    {
        // TODO: This is what happens when my attack ends
        OnAttackEnd.Invoke();
    }

    public void AltAttackStart()
    {
        OnAltAttackStart.Invoke();
    }

    public void AltAttackEnd()
    {
        OnAltAttackEnd.Invoke();
    }
}
