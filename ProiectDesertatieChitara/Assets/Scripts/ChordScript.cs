using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordScript : MonoBehaviour
{
    private float fadeTime = 0.3f;
    private bool fading = false;
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        PopulateAudioForButtons();
        audioSource = GetComponent<AudioSource>();
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
        if (fading && audioSource.volume > 0)
            audioSource.volume -= 1 * Time.deltaTime / fadeTime;
    }

    public void NotePressed()
    {
        fading = false;
        audioSource.volume = 1;
    }

    public void NoteRelesed()
    {
        fading = true;
    }
}