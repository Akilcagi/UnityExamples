using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenu : MonoBehaviour
{
    public GameObject ayarlarPaneli;
    public void YeniOyunBaslat()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    public void AyarlariAc()
    {
        ayarlarPaneli.SetActive(!ayarlarPaneli.activeSelf);
    }

    public void OyunuKapat()
    {
        Application.Quit();
    }
}
