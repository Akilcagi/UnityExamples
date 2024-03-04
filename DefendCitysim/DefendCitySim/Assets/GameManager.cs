using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int PlayerResources = 200;
    public Text resourcesText; 
    public TextMeshProUGUI warningText; 
    public float warningDuration = 2.0f; 
    public Slider healthBarSlider;
    public int currentLevel = 1;
    public int enemiesKilled = 0;
    public int enemiesToNextLevel = 10; 
    public GameObject[] turretButtons; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    void Start()
    {


        ResetGame();
        InitializeTurretButtons();
        UpdateUI(); 
    }
   

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
        ResetGame(); // Oyunu resetle

        GameObject canvasObj = GameObject.Find("Canvas");
        if (canvasObj != null)
        {
            Transform warningTextTransform = canvasObj.transform.Find("WarningText");
            if (warningTextTransform != null)
            {
                warningText = warningTextTransform.GetComponent<TextMeshProUGUI>();
                warningText.gameObject.SetActive(false); 
            }
            else
            {
                Debug.LogError("Canvas alt�nda WarningText objesi bulunamad�.");
            }
        }
        else
        {
            Debug.LogError("Sahnede Canvas objesi bulunamad�.");
        }
         GameObject canvasObj1 = GameObject.Find("Canvas");
    if (canvasObj != null)
    {
       
        Transform gameResultPanelTransform = canvasObj1.transform.Find("GameResultPanel");
        if (gameResultPanelTransform != null)
        {
           
            scoreText = gameResultPanelTransform.Find("InstantScore").GetComponent<TextMeshProUGUI>();
            highScoreText = gameResultPanelTransform.Find("HighScore").GetComponent<TextMeshProUGUI>();
            
            
            scoreText.text = "Score: " + score.ToString();
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        else
        {
            Debug.LogError("GameResultPanel bulunamad�.");
        }
    }
    else
    {
        Debug.LogError("Canvas objesi bulunamad�.");
    }
       
        for (int i = 0; i < turretButtons.Length; i++)
        {
            string buttonName = "TurretButton" + (i + 1);
            GameObject buttonObj = GameObject.Find(buttonName);
            if (buttonObj != null)
            {
                turretButtons[i] = buttonObj;
                buttonObj.SetActive(i < currentLevel);
            }
            else
            {
                Debug.LogError(buttonName + " objesi sahnede bulunamad�.");
            }
        }

        
        AssignUIElements();
        UpdateUI();
    }
   
    public void AddScore(int points)
    {
        score += points;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        UpdateUI();
    }
    void AssignUIElements()
    {
        resourcesText = FindComponent<Text>("KrediMiktar�");
        
        healthBarSlider = FindComponent<Slider>("HealtBar");
       
    }

    T FindComponent<T>(string name) where T : Component
    {
        GameObject obj = GameObject.Find(name);
        if (obj != null)
        {
            return obj.GetComponent<T>();
        }
        else
        {
            Debug.LogError(name + " objesi sahnede bulunamad�.");
            return null;
        }
    }

    void ResetGame()
    {
        
        PlayerResources = 200;
        currentLevel = 1;
        enemiesKilled = 0;
        
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        AddScore(1);
        Debug.Log("D��man �ld�r�ld�: " + enemiesKilled + " / " + enemiesToNextLevel);
        if (enemiesKilled >= enemiesToNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        currentLevel++;
        enemiesKilled = 0; 

        
        if (currentLevel - 1 < turretButtons.Length)
        {
            turretButtons[currentLevel - 1].SetActive(true);
        }

       
    }

    void InitializeTurretButtons()
    {
        foreach (var button in turretButtons)
        {
            button.SetActive(false);
        }
        for (int i = 0; i < turretButtons.Length; i++)
        {
            if (i < currentLevel)
            {
                turretButtons[i].SetActive(true); 
            }
            else
            {
                turretButtons[i].SetActive(false); 
            }
        }
    }

   

    

    public void ShowWarning(string message)
    {
        if (warningText != null) 
        {
            warningText.text = message;
            warningText.gameObject.SetActive(true);
            Invoke("HideWarning", warningDuration); 
        }
    }

   
    void HideWarning()
    {
        if (warningText != null) 
        {
            warningText.gameObject.SetActive(false);
        }
    }

    public void UpdateResources(int cost)
    {
        PlayerResources += cost;
        UpdateUI(); 
    }

    public void AddResources(int amount)
    {
        PlayerResources += amount; 
        UpdateUI(); 
    }

    public void UpdateUI()
    {
        if (resourcesText != null)
        {
            resourcesText.text = "Kaynaklar: $" + PlayerResources.ToString();
        }
        if (scoreText != null) scoreText.text = "Skorun: " + score;
        if (highScoreText != null) highScoreText.text = "Rekor: " + highScore;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }
}
