using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 1.0f;

    // The target position
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        Vector3 targetArea = new Vector3(target.position.x, target.position.y + 10, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetArea, step);
    }
}
