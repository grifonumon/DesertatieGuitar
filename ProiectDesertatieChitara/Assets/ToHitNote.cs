using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToHitNote : MonoBehaviour
{
    private int NumberOfStrings = 1;
    private float speed = 70f;

    private void Start()
    {
        //GetNoteColor(6, new Color[6] { PathsAndConstants.GetStringColor(PathsAndConstants.StringColors.EColor),
        //    PathsAndConstants.GetStringColor(PathsAndConstants.StringColors.AColor),
        //    PathsAndConstants.GetStringColor(PathsAndConstants.StringColors.DColor),
        //    PathsAndConstants.GetStringColor(PathsAndConstants.StringColors.GColor),
        //    PathsAndConstants.GetStringColor(PathsAndConstants.StringColors.BColor),
        //    PathsAndConstants.GetStringColor(PathsAndConstants.StringColors.eColor)});

        GetNoteColor(1, new Color[1] { PathsAndConstants.GetStringColor(PathsAndConstants.StringColors.EColor) });
    }

    public void GetNoteColor(int numberOfStrings, Color[] colors)
    {
        NumberOfStrings = numberOfStrings;
        float fillPrecent = 1f / (float)numberOfStrings;
        float rotation = 360 / numberOfStrings;
        for (int i = 0; i < numberOfStrings; i++)
        {
            var part = Instantiate(Resources.Load<GameObject>("Prefabs/CircleFill"), transform);
            var imgComponent = part.GetComponent<Image>();
            imgComponent.color = colors[i];
            imgComponent.fillAmount = fillPrecent;
            part.transform.localRotation = Quaternion.Euler(0, 0, rotation * i);
        }
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }
}

//for (int i = 0; i<stringNumber; i++)
//       {
//           Instantiate(Resources.Load<GameObject>("Prefabs/Note"),transform.);
//       }