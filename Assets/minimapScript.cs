using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapScript : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.Player.transform;
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
