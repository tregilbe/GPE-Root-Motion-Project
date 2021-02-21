using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
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
        Vector3 targetArea = new Vector3(target.position.x, target.position.y + 10, target.position.z); // Make the target area just above the player
        transform.position = Vector3.MoveTowards(transform.position, targetArea, step); // Moves the camera towards the target area made above, using te step speed to control th speed at which it moves
    }
}
