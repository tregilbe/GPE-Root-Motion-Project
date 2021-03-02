using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    public float rotationSpeed = 90f;

    private void Update()
    {
        //Detect when there is a mouse click
        //if (Input.GetMouseButton(0))
        //{
            // Create a plane that the mouse can click on
            Plane plane = new Plane(Vector3.up, transform.position);

            //Create a ray from the Mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Use UnityEngine.Camera since I have a script named Camera - bad choice - FIXED

            //Initialise the enter variable
            float enter = 0.0f;

            if (plane.Raycast(ray, out enter))
            {
                //Get the point that is clicked
                Vector3 hitPoint = ray.GetPoint(enter);

                // Rotate towards the mouse
                Quaternion targetRotation = Quaternion.LookRotation(hitPoint - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        //}
    }
}
