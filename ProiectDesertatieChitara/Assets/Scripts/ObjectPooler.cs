using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> notePool = new List<GameObject>();
    public Transform NoteParrent;

    public GameObject CheckNotePool(string noteName, PathsAndConstants.StringColors color)
    {
        foreach (var note in notePool)
        {
            if (!note.activeSelf)
            {
                GameObject newNote = note;
                newNote.SetActive(true);
                newNote.GetComponent<ToHitNote>().SetupNote(noteName, color);
                return newNote;
            }
        }
        return AddNoteInPool(noteName, color);
    }

    public GameObject AddNoteInPool(string noteName, PathsAndConstants.StringColors color)
    {
        GameObject newNote = Instantiate(Resources.Load<GameObject>(PathsAndConstants.PREFAB_PATH + "NoteToHit"));
        newNote.transform.SetParent(NoteParrent);
        notePool.Add(newNote);
        newNote.GetComponent<ToHitNote>().SetupNote(noteName, color);
        return newNote;
    }
}