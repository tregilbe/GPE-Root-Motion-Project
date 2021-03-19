using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetprefab;
    public GameObject currentTarget;

    public float timeBetween;
    public float nextSpawnTime;

    public Vector3 scale;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPaused)
            return;

        if (currentTarget == null)
        {
            nextSpawnTime += Time.deltaTime;
            if (nextSpawnTime > timeBetween)
            {
                nextSpawnTime = Time.time;
                currentTarget = Instantiate(targetprefab, transform.position + offset, transform.rotation);
                nextSpawnTime = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.Lerp(Color.cyan, Color.clear, 0.5f);
        Gizmos.DrawCube(Vector3.up * scale.y / 2f, scale);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(Vector3.zero, Vector3.forward * 0.4f);
    }
}
