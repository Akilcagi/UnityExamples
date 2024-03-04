using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AyarlarKontrol : MonoBehaviour
{
    public Dropdown grafikKalitesiDropdown;
    public Slider sesSeviyesiSlider;
    public GameObject settingsPanel; 

   
    
    void Start()
    {


        
        sesSeviyesiSlider.value = AudioListener.volume;
        sesSeviyesiSlider.onValueChanged.AddListener(SesSeviyesiniAyarla);

        grafikKalitesiDropdown.ClearOptions();

        
        List<string> options = new List<string>();
        foreach (string name in QualitySettings.names)
        {
            options.Add(name);
        }
        grafikKalitesiDropdown.AddOptions(options);

       
        grafikKalitesiDropdown.value = QualitySettings.GetQualityLevel();
        grafikKalitesiDropdown.RefreshShownValue(); 
    }
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false); 
                                        
    }

    public void SesSeviyesiniAyarla(float volume)
    {
        AudioListener.volume = volume;
    }
    public void GrafikKalitesiniAyarla(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
