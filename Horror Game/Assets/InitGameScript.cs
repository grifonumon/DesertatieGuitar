using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InitGameScript : MonoBehaviour
{
    public GameObject ControllerCanvas;
    public GameObject MainMenuPanel;
    public GameObject DifficultyPanel;
    public GameObject PostProcessing;
    public GameObject MenuCameras;

    public GameObject enemy1, enemy2;

    // Start is called before the first frame update
    void Start()
    {
        ControllerCanvas.SetActive(false);
        DifficultyPanel.SetActive(false);

        MainMenuPanel.SetActive(true);
        PostProcessing.SetActive(true);
    }


    public void NextScreen()
    {
        if (MainMenuPanel.activeSelf)
        {
            MainMenuPanel.SetActive(false);
            DifficultyPanel.SetActive(true);
        }
    }

    public void BackScreen()
    {
        if (MainMenuPanel.activeSelf)
        {
            return;
        }

        if (DifficultyPanel.activeSelf)
        {
            MainMenuPanel.SetActive(true);
            DifficultyPanel.SetActive(false);
        }
    }


    public void StartGame()
    {

        ControllerCanvas.SetActive(true);
        MainMenuPanel.SetActive(false);
        DifficultyPanel.SetActive(false);
        PostProcessing.SetActive(false);
        MenuCameras.SetActive(false);
        GetComponent<PlayableDirector>().enabled = false;

        enemy1.SetActive(true);
    }
}
