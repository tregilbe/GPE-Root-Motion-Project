using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerUI : MonoBehaviour
{
    public Health health;
    public Text text;
    public Slider slider;
    public Text livesCounter;
    public RawImage Pistol;
    public RawImage Rifle;
    public RawImage Shotgun;
    private Weapon currentWeapon;

    private void Awake()
    {
        //text = GetComponent<Text>();
        //slider = GetComponent<Slider>();
       
    }

    private void Update()
    {
        // Health Bar
        text.text = string.Format("Health: " + health.currentHealth + "%"); // Text format
        slider.value = health.currentHealth; // set the slider value to the current health each frame draw

        // Lives counter
        livesCounter.text = string.Format("x" + GameManager.Instance.Lives);

        // Weapon Display
            if (GameManager.Instance.Player.GetComponent<HumanoidPawn>().weapon.name == "Pistol Variant(Clone)") // Check weapon based on the name, since it changes when spawned
            {
                Pistol.enabled = true;
                Rifle.enabled = false;
                Shotgun.enabled = false;
            }
            else if (GameManager.Instance.Player.GetComponent<HumanoidPawn>().weapon.name == "Basic Rifle Variant(Clone)")
            {
                Pistol.enabled = false;
                Rifle.enabled = true;
                Shotgun.enabled = false;
            }
            else if (GameManager.Instance.Player.GetComponent<HumanoidPawn>().weapon.name == "Shotgun Variant(Clone)")
            {
                Pistol.enabled = false;
                Rifle.enabled = false;
                Shotgun.enabled = true;
            }
    }
}
