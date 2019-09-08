using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PathsAndConstants;

public class NoteSpowner : MonoBehaviour
{
    public ObjectPooler objectPooler;

    private void Start()
    {
    }

    public void SpownNote(int poz, StringColors stringColor, string noteName, float duration = 0)
    {
        var note = objectPooler.CheckNotePool(noteName, stringColor);
        note.transform.position = transform.GetChild(poz).transform.position;
    }
}