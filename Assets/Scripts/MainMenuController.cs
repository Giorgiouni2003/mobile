using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject storyPanel;
    public Slider volumeSlider;
    public AudioClip volumeTickSound;

    private void Start()
    {
        volumeSlider.value = AudioManager.Instance.musicVolume;
        volumeSlider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
        volumeSlider.onValueChanged.AddListener(PlayVolumeTick);
        settingsPanel.SetActive(false);
        storyPanel.SetActive(false);
    }

    private void PlayVolumeTick(float value)
    {
        AudioManager.Instance.PlaySfx(volumeTickSound, 0.5f);
    }

    public void Play()
    {
        mainPanel.SetActive(false);
        storyPanel.SetActive(true);
    }

    public void StartGame()
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
