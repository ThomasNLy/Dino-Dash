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

    private float scoreTimer;

    [SerializeField]
    private int scoreTimerLimit = 3;

    public GameObject pauseText;
    public GameObject gameOverText;
    public GameObject scoreGameObject;
    public GameObject powerUpBarText;
    public GameObject powerUpBar;
    public GameObject outOfBoundsBarrier;
    public GameObject spawnLoc;
    [SerializeField]
    private int powerUpPoints;

    private int points;

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
        powerUpBarRectContainer = powerUpBar.GetComponent<RectTransform>();
        powerUpBarRectContainer.sizeDelta = new Vector2(10, powerUpBarRectContainer.sizeDelta.y);
      
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
            }
            if (powerUpPoints >= 10)
            {
                powerUpPoints = 10;
            }
            scoreGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + points;
            powerUpBarText.GetComponent<TMPro.TextMeshProUGUI>().text = "Power up: " + powerUpPoints;
            
            powerUpBarRectContainer.sizeDelta = new Vector2(powerUpPoints  * 10, powerUpBarRectContainer.sizeDelta.y);
          
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
}
