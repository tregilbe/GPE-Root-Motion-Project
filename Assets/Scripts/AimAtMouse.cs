using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 90f;

    private void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
