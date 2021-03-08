using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int xSpeed;
    public int ySpeed;
    public int zSpeed;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        // Rotate the pickup to make it look nice
        transform.Rotate(xSpeed, ySpeed, zSpeed * Time.deltaTime); // Allows designers to change speed on a whim
    }
}
