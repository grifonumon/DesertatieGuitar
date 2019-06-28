using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsAndConstants : MonoBehaviour
{
    public static string NOTE_PATH = "Audio/Strings/";

    public enum StringColors
    {
        EColor,
        AColor,
        DColor,
        GColor,
        BColor,
        eColor
    }

    public Color GetStringColor(StringColors color)
    {
        Color c = Color.red;
        switch (color)
        {
            case StringColors.EColor:
                c = Color.red;
                break;

            case StringColors.AColor:
                c = Color.yellow;
                break;

            case StringColors.DColor:
                c = new Color(0.035f, 0.91f, 0.92f);
                break;

            case StringColors.GColor:
                c = new Color(0.93f, 0.45f, 0.047f);
                break;

            case StringColors.BColor:
                c = Color.green;
                break;

            case StringColors.eColor:
                c = Color.magenta;
                break;
        }
        return c;
    }
}