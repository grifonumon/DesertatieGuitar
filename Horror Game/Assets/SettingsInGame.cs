using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsInGame : MonoBehaviour
{
    public CodeLock keypad;
    public TMPro.TextMeshPro keypadCodeHolder;

    private void OnEnable()
    {
        Application.targetFrameRate = 300;
        Time.fixedDeltaTime = 0.03f;

        InitGame();
    }

    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(1f, 0.0f, 0.0f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }


    private void InitGame()
    {
        //Set password for keypad
        keypad.password = Random.Range(1,9) + ""+Random.Range(1, 9) + "" + Random.Range(1, 9)+"" + Random.Range(1, 9);
        keypadCodeHolder.text = "CODE\n\n"+keypad.password;
    }
}
