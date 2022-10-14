using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * an object used to represent the various properties in order to save the game
 * static class for webgl version to allow it to persist across scenes 
 */
public static class GameData
{
    public static int score;
    public static float bgMusicVolume;
    public static float soundEffectVolume;
}
