using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Toggle toggleMute;
    [SerializeField] Slider sliderMaster;
    [SerializeField] TextMeshProUGUI masterVolume;
    [SerializeField] Slider sliderMusic;
    [SerializeField] TextMeshProUGUI musicVolume;
    [SerializeField] Slider sliderSFX;
    [SerializeField] TextMeshProUGUI sfxVolume;
    [SerializeField] TMP_Dropdown resolutionVideo;
    [SerializeField] TMP_Dropdown windowVideo;
    [SerializeField] TMP_Dropdown fpsVideo;
    [SerializeField] FullScreenMode fullScreenMode;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mute()
    {
        if(toggleMute.isOn)
        {
            sliderMaster.interactable = false;
            sliderMusic.interactable = false;
            sliderSFX.interactable = false;
            Debug.Log("Volume Audio : Muted");
        }
        else
        {
            sliderMaster.interactable = true;
            sliderMusic.interactable = true;
            sliderSFX.interactable = true;
            Debug.Log("Volume Audio : Unmuted");
        }
    }

    public void MasterVolumeChanged(float sliderValue)
    {
        var masterValue = Mathf.FloorToInt(sliderValue * 100);
        masterVolume.text = masterValue.ToString();
        Debug.Log("Volume Master : " + masterVolume.text);
    }

    public void MusicVolumeChanged(float sliderValue)
    {
        var musicValue = Mathf.FloorToInt(sliderValue * 100);
        musicVolume.text = musicValue.ToString();
        Debug.Log("Volume BGM : " + musicVolume.text);
    }

    public void SFXVolumeChanged(float sliderValue)
    {
        var sfxValue = Mathf.FloorToInt(sliderValue * 100);
        sfxVolume.text = sfxValue.ToString();
        Debug.Log("Volume SFX : " + sfxVolume.text);
    }

    public void ResolutionChanged()
    {
        var resolution = resolutionVideo.options[resolutionVideo.value].text;
        if(resolution == "1920 x 1080")
        {
            Screen.SetResolution(1920, 1080, fullScreenMode);
        }
        else if(resolution == "1600 x 900")
        {
            Screen.SetResolution(1600, 900, fullScreenMode);
        }
        else if(resolution == "1280 x 720")
        {
            Screen.SetResolution(1280, 720, fullScreenMode);
        }
        else if(resolution == "640 x 360")
        {
            Screen.SetResolution(640, 360, fullScreenMode);
        }
        Debug.Log("Resolution : " + resolution);
        Debug.Log("Window : " + fullScreenMode.ToString());
    }

    public void WindowChanged()
    {
        var window = windowVideo.options[windowVideo.value].text;
        Resolution currentResolution = Screen.currentResolution;
        if(window == "Fullscreen")
        {
            fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else if(window == "Maximized Window")
        {
            fullScreenMode = FullScreenMode.MaximizedWindow;
        }
        else if(window == "Windowed")
        {
            fullScreenMode = FullScreenMode.Windowed;
        }
        Screen.SetResolution(currentResolution.width, currentResolution.height, fullScreenMode);
        Debug.Log("Resolution : " + currentResolution.width.ToString() + " x " + currentResolution.height.ToString());
        Debug.Log("Window : " + window);
    }

    public void FPSChanged()
    {
        QualitySettings.vSyncCount = 0;
        var fps = fpsVideo.options[fpsVideo.value].text;
        if(fps == "144")
        {
            Application.targetFrameRate = 144;
        }
        else if(fps == "120")
        {
            Application.targetFrameRate = 120;
        }
        else if(fps == "90")
        {
            Application.targetFrameRate = 90;
        }
        else if(fps == "60")
        {
            Application.targetFrameRate = 60;
        }
        else if(fps == "45")
        {
            Application.targetFrameRate = 45;
        }
        else if(fps == "30")
        {
            Application.targetFrameRate = 30;
        }
        else if(fps == "Unlimited")
        {
            QualitySettings.vSyncCount = 1;
        }
        Debug.Log("Max FPS : " + fps);
    }
    public void SaveSettings()
    {
        Debug.Log("Setting Preferences Saved");
    }

    public void QuitSettings()
    {
        Debug.Log("Setting Preferences not Saved");
    }

    public void LoadScene(int sceneIndex)
    {
        Debug.Log("Changing to Scene " + sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }
}
