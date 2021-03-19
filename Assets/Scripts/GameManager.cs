using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Add a static GameManager reference
    public static GameManager Instance { get; private set; }

    public GameObject Player;
    public GameObject playerPrefab;
    public Transform playerSpawnPoint;
    public int playerRespawnDelay;
    public int Lives;
    public bool isPaused = false;

    // Any time a GameManager is spawned it sets the static Instance variable to reference itself
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Player = GameObject.FindGameObjectWithTag("Player");
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Pause();
            } 
            else if (isPaused == true)
            {
                Unpause();
            }
        }
    }

    private void SpawnPlayer()
    {
        Player = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
    }

    public void HandlePlayerDeath()
    {
        if (Lives > 0)
        {
            Invoke("SpawnPlayer", playerRespawnDelay);
            Lives--;
        }
        else
        {
            // Game Over!
        }
        
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
