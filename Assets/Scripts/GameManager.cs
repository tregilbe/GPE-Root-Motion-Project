using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Public reference to current player, for UI
    public float playerHealth;
    public Weapon playerWeapon;

    // Canvas's for game over and pause and win
    public Canvas pauseMenu;
    public Canvas gameOver;
    public Canvas WinScreen;

    // Any time a GameManager is spawned it sets the static Instance variable to reference itself
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;

        // Player = GameObject.FindGameObjectWithTag("Player");
        SpawnPlayer();

        // Disable both menus till needed
        pauseMenu.enabled = false;
        gameOver.enabled = false;
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

        playerHealth = GameManager.Instance.Player.GetComponent<Health>().currentHealth;

        playerWeapon = GameManager.Instance.Player.GetComponent<HumanoidPawn>().weapon;
    }

    private void SpawnPlayer()
    {
        Player = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
    }

    public void HandlePlayerDeath()
    {
        if (Lives <= 0)
        {
            // Game Over!
            Debug.Log("0 LIVES DETECTED");
            gameOver.enabled = true; // enable game over menu
        }
        else
        {
            Debug.Log("PLAYER HAS LIVES LEFT");
            Invoke("SpawnPlayer", playerRespawnDelay);
            Lives--;
        }       
    }

    // Functions for UI
    public void Pause()
    {
        isPaused = true; // sett bool to true
        Time.timeScale = 0f; // time scale to 0, time stops
        pauseMenu.enabled = true; // enable pause menu canvas SET IN INSPECTOR
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.enabled = false;
    }

    public void QuitCurrentGame() // Pause menu quit, returns to main menu
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ButtonQuit() // Closes game 
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ButtonContinue()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void WinGame()
    {
        isPaused = true; // sett bool to true
        Time.timeScale = 0f; // time scale to 0, time stops
        WinScreen.enabled = true;
    }
}
