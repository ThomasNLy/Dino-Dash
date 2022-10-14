using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

/**
 * Used to save the games data such as high score and game settings 
 * The save data is stored in a json file
 */
public class SaveData : MonoBehaviour
{
    //string saveFile;
    

    // only 1 instance of the save data game object can exist at a time 
    public static SaveData Instance;
    
    //various settings to save
    private const string MUSIC = "Music";
    private const string SOUNDEFFECT = "Sound Effect";
    
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
            GameData.bgMusicVolume = 1;
            GameData.soundEffectVolume = 0.69f;
            //saveFile = Application.persistentDataPath + "SaveFile.json";
            //try
            //{
                
            //    if (File.Exists(saveFile))
            //    {
                
                    
            //    }
                
            //    // inital/default settings if a save file doesn't exist, stored as a json object 
            //    else
            //    {
            //        gameData = new GameData();
            //        gameData.score = 0;
            //        gameData.bgMusicVolume = 1;
            //        gameData.soundEffectVolume = 0.69f;
            //        string jsonString = JsonUtility.ToJson(gameData);
            //        File.WriteAllText(saveFile, jsonString);
                    
            //    }
            //}
            //catch (FileNotFoundException e)
            //{
            //    Debug.LogError(e.Message);
                
            //}


        }
        
       

    }
    /**
     * Saves the current game data by overwritting the current save file in json format. 
     */
    //public void Save()
    //{
        
    //    //if (File.Exists(saveFile))
    //    //{
            
    //        string currentGameData = JsonUtility.ToJson(gameData);
           
    //        JsonUtility.FromJsonOverwrite(currentGameData, gameData);

    //        string gameDataJSonString = JsonUtility.ToJson(gameData);
    //        File.WriteAllText(saveFile, gameDataJSonString);
            
    //    //}
    //    //else 
    //    //{
            
    //    //    string jsonString = JsonUtility.ToJson(gameData);
           
    //    //    File.WriteAllText(saveFile, jsonString);

    //    //}
    //}

    public void SaveSettings(float volume, string name)
    {
        if(name == MUSIC)
        {
            GameData.bgMusicVolume = volume;
        }

        else if (name == SOUNDEFFECT)
        {
            GameData.soundEffectVolume = volume;
        }

       // Save();
    }

    public void SaveNewHighScore(int score)
    {
        GameData.score = score;
        //Save();
    }
  

    public int GetHighScore()
    {
        return GameData.score;
    }

    public float GetBGMusicVolume()
    {
        //gameData = Load();
        return GameData.bgMusicVolume;
    }

    public float GetSoundEffectVolume()
    {
        //gameData = Load();
        
        return GameData.soundEffectVolume;
    }

    // gets the volume setting name in order to save to the correct one and allows access to it, similar to a class property
    public string MusicVolume
    {
        get { return MUSIC; } 
    }

    public string SoundEffectVolume
    {
        get { return SOUNDEFFECT; }
    }
}
