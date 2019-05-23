using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        PopulateAudioForButtons();
    }

    private void PopulateAudioForButtons()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (name[1] != 'm')
                transform.GetChild(i).GetComponent<NoteScript>().SetAudioClip(name[0] + i.ToString());
            else
                transform.GetChild(i).GetComponent<NoteScript>().SetAudioClip("em" + i.ToString());
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}