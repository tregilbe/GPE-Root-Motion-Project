using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Slider masterVolumeSlider;
    public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;
    public Toggle fullscreenToggle;
    public Button applyButton;

    [SerializeField, Tooltip("The master audio mixer")] // Get main audio mixer
    private AudioMixer audioMixer;

    [SerializeField, Tooltip("The slider value vs decibel volume curve")] // Used to convert slider value to Db
    private AnimationCurve volumeVsDecibels;

    private void Awake()
    {
        /*
        // Build resolutions
        resolutionDropdown.ClearOptions();
        List resolutions = new List();
        for (int index = 0; index < Screen.resolutions.Length; index++)
        {
            resolutions.Add(string.Format("{0} x {1}", Screen.resolutions[index].width, Screen.resolutions[index].height));
        }
        resolutionDropdown.AddOptions(resolutions);
        // Build quality levels
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(QualitySettings.names.ToList());
        */
    }
    
    // Start is called before the first frame update
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("Master Volume", masterVolumeSlider.maxValue);
        fullscreenToggle.isOn = Screen.fullScreen;
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        applyButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //audioMixer.SetFloat("Master Volume", masterVolumeSlider.value);
        //audioMixer.SetFloat("Sound Volume", soundVolumeSlider.value);
        //audioMixer.SetFloat("Music Volume", musicVolumeSlider.value);

        audioMixer.SetFloat("Master Volume", volumeVsDecibels.Evaluate(masterVolumeSlider.value));
        audioMixer.SetFloat("Sound Volume", volumeVsDecibels.Evaluate(soundVolumeSlider.value));
        audioMixer.SetFloat("Music Volume", volumeVsDecibels.Evaluate(musicVolumeSlider.value));
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Level 1");  // For Main menu, load the main scene/level
    }

    public void ButtonQuit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
