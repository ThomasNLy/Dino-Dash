using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    string saveFile;
    private GameData gameData; 
    // Start is called before the first frame update
    void Awake()
    {
        saveFile = Application.persistentDataPath + "highscore.json";
        //gameData = new GameData();
        gameData = Load();

    }
    public void Save(int score)
    {
        
        if (File.Exists(saveFile))
        {
            //overide the file
            Debug.Log(Application.persistentDataPath);
            gameData.score = score;
            string jsonString = JsonUtility.ToJson(gameData);
            File.WriteAllText(saveFile, jsonString);
            
        }
        else 
        {
            
            gameData.score = score;
            string jsonString = JsonUtility.ToJson(gameData);
           
            File.WriteAllText(saveFile, jsonString);
            // create file 
            // StreamWriter writer = new StreamWriter(saveFile);
            //writer.WriteLine("hello");
            // writer.Close();

        }
    }
    public GameData Load()
    {
        return JsonUtility.FromJson<GameData>(File.ReadAllText(saveFile));
        
    }

    public int GetHighScore()
    {
        return gameData.score;
    }
}
