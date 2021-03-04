using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerUI : MonoBehaviour
{
    public Health health;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = string.Format("Health: " + health.currentHealth + "%");
        // text.text = string.Format("Health: {0}%", Mathf.RoundToInt(health.Percent * 100f));
    }
}
