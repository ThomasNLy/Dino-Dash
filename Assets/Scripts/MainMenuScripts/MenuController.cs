using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string levelSelected;
    public SceneLoader sceneLoad;
    public Button playBtn;
    public Button controlBtn;
    public Button backBtn;
    public Button exitBtn;
    public GameObject controlMenu;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoad = gameObject.GetComponent<SceneLoader>();
        playBtn = playBtn.GetComponent<Button>();
        playBtn.onClick.AddListener(PlayGame);
        controlBtn = controlBtn.GetComponent<Button>();
        controlBtn.onClick.AddListener(ShowControlMenu);
        controlMenu.SetActive(false);
        backBtn = backBtn.GetComponent<Button>();
        backBtn.onClick.AddListener(CloseControlMenu);
        exitBtn = exitBtn.GetComponent<Button>();
        exitBtn.onClick.AddListener(ExitGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayGame()
    {
        sceneLoad.LoadScene(levelSelected);
    }

    void ShowControlMenu()
    {
        controlMenu.SetActive(true);
    }
    void CloseControlMenu()
    {
        controlMenu.SetActive(false);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
