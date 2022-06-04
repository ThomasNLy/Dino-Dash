using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField]
    private bool gameOver;
    [SerializeField]
    private bool paused;

    public GameObject pauseText;
    public GameObject gameOverText;

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
}
