using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using static PathsAndConstants;

public class Game : MonoBehaviour
{
    public static float Life = 100;
    private static PathsAndConstants.GameDificulty Dificulty;
    private SongNames songSelected;

    public void LoadLevel(string levelName)
    {
        try
        {
            SceneManager.LoadScene(levelName);
        }
        catch (Exception e) { Debug.LogError(e); }
    }

    public void SelectSong(SongNames songName)
    {
        songSelected = songName;
    }

    public static void NoteMiss()
    {
      

        int multyplier = 0;
       // Life -= 5 * PathsAndConstants.DictDificulty.TryGetValue(Dificulty, multyplier);
    }
}