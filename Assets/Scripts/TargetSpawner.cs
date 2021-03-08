using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetprefab;
    public GameObject currentTarget;

    public float timeBetween;
    public float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null)
        {
            nextSpawnTime += Time.deltaTime;
            if (nextSpawnTime > timeBetween)
            {
                nextSpawnTime = Time.time;
                currentTarget = Instantiate(targetprefab, transform.position, transform.rotation);
                nextSpawnTime = 0;
            }
        }
    }
}
