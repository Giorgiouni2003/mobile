using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = AudioManager.Instance.musicVolume;
        volumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
        settingsPanel.SetActive(false);
    }

    public void Play()
    {
        GameManager.Instance.NewGame();
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

}
