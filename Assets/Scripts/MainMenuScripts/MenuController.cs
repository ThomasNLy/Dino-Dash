using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string levelSelected;
    public SceneLoader sceneLoad;
    [Header("Menus variables")]
    public Button playBtn;
    public Button exitBtn;
    public GameObject controlMenu;
    public Button controlBtn;
    public Button controlMenuBackBtn;
    [Header("Settings Menu variables")]
    public GameObject settingsMenu;
    public Button settingsMenuBackBtn;
    public Button settingsBtn;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoad = gameObject.GetComponent<SceneLoader>();
        playBtn = playBtn.GetComponent<Button>();
        playBtn.onClick.AddListener(PlayGame);
        controlBtn = controlBtn.GetComponent<Button>();
        controlBtn.onClick.AddListener(ShowControlMenu);
        controlMenu.SetActive(false);
        controlMenuBackBtn = controlMenuBackBtn.GetComponent<Button>();
        controlMenuBackBtn.onClick.AddListener(CloseControlMenu);
        exitBtn = exitBtn.GetComponent<Button>();
        exitBtn.onClick.AddListener(ExitGame);

        //---------settings menu-----------
        settingsMenu.SetActive(false);
        settingsMenuBackBtn.onClick.AddListener(CloseSettingsMenu);
        settingsBtn.onClick.AddListener(ShowSettingsMenu);
        
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
    void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
    void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
