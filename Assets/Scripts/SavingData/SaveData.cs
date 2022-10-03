using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    string saveFile;
    private GameData gameData; 

    public static SaveData Instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && this != Instance)
        {
            Destroy(this);
        }
        else 
        {
            Instance = this;
            saveFile = Application.persistentDataPath + "highscore.json";
            gameData = Load();
        }
        
       

    }
    public void Save()
    {
        
        if (File.Exists(saveFile))
        {
            //overide the file
            //Debug.Log(Application.persistentDataPath);
            //gameData.score = score;
            string currentGameData = JsonUtility.ToJson(gameData);
           
            JsonUtility.FromJsonOverwrite(currentGameData, gameData);

            string gameDataJSonString = JsonUtility.ToJson(gameData);
            File.WriteAllText(saveFile, gameDataJSonString);
            
        }
        else 
        {
            
            string jsonString = JsonUtility.ToJson(gameData);
           
            File.WriteAllText(saveFile, jsonString);
            // create file 
            // StreamWriter writer = new StreamWriter(saveFile);
            //writer.WriteLine("hello");
            // writer.Close();

        }
    }

    public void SaveSettings(float volume)
    {
        gameData.bgMusicVolume = volume;
        Save();
    }

    public void SaveNewHighScore(int score)
    {
        gameData.score = score;
        Save();
    }
    public GameData Load()
    {
        return JsonUtility.FromJson<GameData>(File.ReadAllText(saveFile));
        
    }

    public int GetHighScore()
    {
        return gameData.score;
    }

    public float GetBGMusicVolume()
    {
        gameData = Load();
        return gameData.bgMusicVolume;
    }
}
