using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PathsAndConstants;

public class ToHitNote : MonoBehaviour
{
    private int NumberOfStrings = 1;
    public float Speed = 80f;
    public float DestroyDistance = 4;
    private Image imgComponent;
    private string noteName;


    private void Awake()
    {
        imgComponent = Instantiate(Resources.Load<GameObject>("Prefabs/CircleFill"), transform).GetComponent<Image>();

        //GetNoteColor(1, new Color[1] { PathsAndConstants.GetStringColor(PathsAndConstants.StringColors.EColor) });
    }

    public void SetupNote(string note_Name, StringColors color)
    {
        noteName = note_Name;
        imgComponent.color = GetStringColor(color);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
        CheckDestroy();
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

    private void CheckDestroy()
    {
        if (transform.localPosition.y < DestroyDistance)
        {
            gameObject.SetActive(false);
        }
    }
}

//for (int i = 0; i<stringNumber; i++)
//       {
//           Instantiate(Resources.Load<GameObject>("Prefabs/Note"),transform.);
//       }