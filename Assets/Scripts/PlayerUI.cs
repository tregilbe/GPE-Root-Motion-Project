using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerUI : MonoBehaviour
{
    public Canvas playerUI;
    public Health health;
    public Text text;
    public Slider slider;
    public Text livesCounter;
    public RawImage Pistol;
    public RawImage Rifle;
    public RawImage Shotgun;
    private Weapon currentWeapon;
    private float currentPlayerHealth;

    private void Awake()
    {
        //text = GetComponent<Text>();
        //slider = GetComponent<Slider>();
        playerUI = GetComponent<Canvas>();
    }

    private void Update()
    {
        currentPlayerHealth = GameManager.Instance.playerHealth;

        // Health Bar
        // text.text = string.Format("Health: " + health.currentHealth + "%"); // Text format
        // slider.value = health.currentHealth; // set the slider value to the current health each frame draw
        text.text = string.Format("Health: " + currentPlayerHealth + "%"); // Text format using float
        slider.value = currentPlayerHealth;

        // Lives counter
        livesCounter.text = string.Format("x" + GameManager.Instance.Lives);

        // if health is at 0, disable this canvas
        if (currentPlayerHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        // Weapon Display
        if (GameManager.Instance.Player.GetComponent<HumanoidPawn>() != null && GameManager.Instance.Player.GetComponent<HumanoidPawn>().weapon.name == "Pistol Variant(Clone)") // Check weapon based on the name, since it changes when spawned
        {
            Pistol.enabled = true;
            Rifle.enabled = false;
            Shotgun.enabled = false;
        }
        else if (GameManager.Instance.Player.GetComponent<HumanoidPawn>() != null && GameManager.Instance.Player.GetComponent<HumanoidPawn>().weapon.name == "Basic Rifle Variant(Clone)")
        {
            Pistol.enabled = false;
            Rifle.enabled = true;
            Shotgun.enabled = false;
        }
        else if (GameManager.Instance.Player.GetComponent<HumanoidPawn>() != null && GameManager.Instance.Player.GetComponent<HumanoidPawn>().weapon.name == "Shotgun Variant(Clone)")
        {
            Pistol.enabled = false;
            Rifle.enabled = false;
            Shotgun.enabled = true;
        }



        /*
        if (GameManager.Instance.playerWeapon.name == "Pistol Variant(Clone)") // Check weapon based on the name, since it changes when spawned
        {
            Pistol.enabled = true;
            Rifle.enabled = false;
            Shotgun.enabled = false;
        }
        else if (GameManager.Instance.playerWeapon.name == "Rifle Variant(Clone)")
        {
            Pistol.enabled = false;
            Rifle.enabled = true;
            Shotgun.enabled = false;
        }
        else if (GameManager.Instance.playerWeapon.name == "Shotgun Variant(Clone)")
        {
            Pistol.enabled = false;
            Rifle.enabled = false;
            Shotgun.enabled = true;
        }
        */
    }
}
