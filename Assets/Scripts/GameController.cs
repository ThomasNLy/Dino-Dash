using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField]
    private bool gameOver;
    [SerializeField]
    private bool paused;

    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float maxScrollSpeed = -6f;
    [SerializeField]
    private int obstacleSpawnRate = 10;
    [SerializeField]
    private int maxObstacleSpawnRate = 4;

    
    [SerializeField]
    private int difficultyIncrease = 5; // everytime points are increased by said amount game difficulty increases


    [SerializeField]
    private int scoreTimerLimit = 3;

    private float scoreTimer;

    [Header("Level Bounds")]
    public GameObject outOfBoundsBarrier;
    public GameObject spawnLoc;
    
    [Header("UI variables")]     
    [SerializeField]
    private int powerUpPoints;

    private int powerUpPointsMax;
    [SerializeField]
    private int points;



    public GameObject pauseText;
    public GameObject gameOverScreen;
    public TMP_Text scoreText;
   
    public GameObject powerUpBar;
    
     
    
    
   

    private Slider powerUpBarFill;

    public Button pauseButton;
    public GameObject mainMenuButton;

    [Header("Game Over Screen Variables")]
    public TMP_Text highScoreValue;
    public TMP_Text currentScoreValue;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            scrollSpeed = -3.25f;
        }



    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        paused = false;
        pauseText.SetActive(false);
        gameOverScreen.SetActive(false);
        points = 0;
        powerUpPoints = 0;
        
        powerUpBarFill = powerUpBar.GetComponent<Slider>();
        powerUpPointsMax = (int)powerUpBar.GetComponent<Slider>().maxValue;

        pauseButton.onClick.AddListener(PauseButtonClicked);
        Time.timeScale = 1f;



    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && gameOver)
        {
            SaveData saveData = this.GetComponent<SaveData>();
           
            if (saveData.GetHighScore() < points)
            {
                saveData.SaveNewHighScore(points);
            }
            
            Restart();
        }

        if (gameOver)
        {
            gameOverScreen.SetActive(gameOver);
            int previousHighScore = this.GetComponent<SaveData>().GetHighScore();
            if (points > previousHighScore)
            {
                highScoreValue.text = points.ToString();
            }
            else 
            {
                highScoreValue.text = previousHighScore.ToString();
            }
            currentScoreValue.text = points.ToString();
            Time.timeScale = 0f;
           
        }

       

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }

        else
        {
            scoreTimer += Time.deltaTime;
            if (scoreTimer > scoreTimerLimit)
            {

                scoreTimer = 0;
                points += 1;
                if (points % difficultyIncrease == 0 )
                {
                    if (scrollSpeed >= maxScrollSpeed)
                    {
                        scrollSpeed -= 1;
                    }
                    if (obstacleSpawnRate > maxObstacleSpawnRate)
                    {
                        obstacleSpawnRate -= 1;
                    }

                }
               
            }

            if (powerUpPoints >= powerUpPointsMax)
            {
                powerUpPoints = powerUpPointsMax;
            }
            scoreText.text = "Score: " + points;
           

            powerUpBarFill.value = powerUpPoints;


        }



    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void GameOver()
    {
        gameOver = true;
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public bool IsPaused()
    {
        return paused;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseText.SetActive(paused);
        mainMenuButton.SetActive(true);
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        pauseText.SetActive(paused);
        mainMenuButton.SetActive(false);
    }

    public void IncreasePowerUpPoints()
    {
        powerUpPoints += 1;
    }
    public int GetPowerUpPoints()
    {
        return powerUpPoints;
    }

    public void ResetPowerUpPoints()
    {
        powerUpPoints = 0;
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }
    public float GetObstacleSpawnRate()
    {
        return obstacleSpawnRate;
    }

    public int GetPowerUpPointsMax()
    {
        return powerUpPointsMax;
    }

    private void PauseButtonClicked()
    {
        paused = !paused;
        if (paused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
    }
}
