using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
  
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public Button restartButton;
    public Button mainMenuButton;
    public Button quitButton;

    void Start()
    {
      
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        quitButton.onClick.AddListener(QuitGame);
        volumeSlider.value = AudioListener.volume;
        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    
    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

   
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

   
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("AnaMenu"); 
        Time.timeScale = 1;
    }

   
    public void QuitGame()
    {
        Application.Quit();
    }
}
