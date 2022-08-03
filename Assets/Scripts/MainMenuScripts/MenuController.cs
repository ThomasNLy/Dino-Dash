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
    public GameObject controlMenu;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoad = gameObject.GetComponent<SceneLoader>();
        playBtn = playBtn.GetComponent<Button>();
        playBtn.onClick.AddListener(playGame);
        controlBtn = controlBtn.GetComponent<Button>();
        controlBtn.onClick.AddListener(showControlMenu);
        controlMenu.SetActive(false);
        backBtn = backBtn.GetComponent<Button>();
        backBtn.onClick.AddListener(closeControlMenu);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playGame()
    {
        sceneLoad.LoadScene(levelSelected);
    }

    void showControlMenu()
    {
        controlMenu.SetActive(true);
    }
    void closeControlMenu()
    {
        controlMenu.SetActive(false);
    }
}
