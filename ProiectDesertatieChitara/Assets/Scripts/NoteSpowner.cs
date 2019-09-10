using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PathsAndConstants;

public class NoteSpowner : MonoBehaviour
{
    public ObjectPooler objectPooler;
    private int maxNotes;

    private void Start()
    {
        maxNotes = transform.childCount;
    }

    public void SpownNote(int poz, StringColors stringColor, string noteName, float duration = 0)
    {
        if (poz < maxNotes)
        {
            var note = objectPooler.CheckNotePool(noteName, stringColor);
            note.transform.position = transform.GetChild(poz).transform.position;
        }
    }
}