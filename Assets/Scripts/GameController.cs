using System.Collections;
using System.Collections.Generic;
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
    
    [SerializeField]
    private int powerUpPoints;

    private int powerUpPointsMax;
    [SerializeField]
    private int points;



    public GameObject pauseText;
    public GameObject gameOverText;
    public GameObject scoreGameObject;
    public GameObject powerUpBarText;
    public GameObject powerUpBar;
    public GameObject outOfBoundsBarrier;
    public GameObject spawnLoc;
    
    
   

    private Slider powerUpBarFill;

    RectTransform powerUpBarRectContainer;


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
        gameOverText.SetActive(false);
        points = 0;
        powerUpPoints = 0;
        
        powerUpBarFill = powerUpBar.GetComponent<Slider>();
        powerUpPointsMax = (int)powerUpBar.GetComponent<Slider>().maxValue;





    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && gameOver)
        {
            Restart();
        }

        if (gameOver)
        {
            gameOverText.SetActive(gameOver);
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
            scoreGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + points;
            powerUpBarText.GetComponent<TMPro.TextMeshProUGUI>().text = "Power up: " + powerUpPoints;

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

    void Pause()
    {
        Time.timeScale = 0f;
        pauseText.SetActive(paused);
    }
    void UnPause()
    {
        Time.timeScale = 1f;
        pauseText.SetActive(paused);
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
}
