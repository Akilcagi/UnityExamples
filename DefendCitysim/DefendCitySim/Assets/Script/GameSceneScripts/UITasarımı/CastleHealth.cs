using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleHealth : MonoBehaviour
{

    public float maxHealth = 100f;
    private float currentHealth;
    public GameObject gameOverPanel; 
    public Slider healthBar; 

    void Start()
    {
        currentHealth = maxHealth;
        gameOverPanel.SetActive(false);
        healthBar.maxValue = maxHealth; 
        healthBar.value = CalculateHealth(); 

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth; 
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }
    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    void GameOver()
    {
        Debug.Log("GameOver Fonksiyonu �a�r�ld�");
        gameOverPanel.SetActive(true);
        if (GameManager.instance != null)
        {
            GameManager.instance.AddScore(0); 
        }
        Time.timeScale = 0f; 
    }

   
    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("AnaMenu"); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
