using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RadioButtonsDifficulty : MonoBehaviour
{
    public Toggle[] RadioButtons;
    public GameObject[] TabPanels;
    public ToggleGroup tg;

    int difficulty = 0;

    void Start()
    {
        SetDifficulty();
    }

    void SetDifficulty()
    {
        foreach ( Toggle radio in RadioButtons )
        {
            radio.isOn = false;
        }

        foreach( GameObject tab in TabPanels )
        {
            tab.SetActive(false);
        }


        RadioButtons[difficulty].isOn = true;
        TabPanels[difficulty].SetActive(true);
    }

    public void ChangeDifficulty()
    {
        difficulty = int.Parse(tg.ActiveToggles().FirstOrDefault().name);
        foreach (GameObject tab in TabPanels)
        {
            tab.SetActive(false);
        }
        TabPanels[difficulty].SetActive(true);

        PlayerPrefs.SetInt("difficulty", difficulty);
    }
}
