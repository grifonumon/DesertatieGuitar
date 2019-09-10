using UnityEngine;
using System.Collections;
using NAudio.Midi;
using System.IO;

public class MidiReader : MonoBehaviour
{
    public MidiFile midi;
    public float ticks;
    public float offset;
    public NoteSpowner noteSpowner;

    private void Start()
    {
        PlaySelectedMidi();
    }

    public void PlaySelectedMidi(string midiName = "AllNotesInOrder")
    {
        //Loading midi file "mainSong.bytes" from resources folder
        //Its a midi file, extension has been changed to .bytes manually

        TextAsset asset = Resources.Load(midiName) as TextAsset;
        Stream s = new MemoryStream(asset.bytes);

        //Read the file
        midi = new MidiFile(s, true);

        //Ticks needed for timing calculations
        ticks = midi.DeltaTicksPerQuarterNote;

        StartPlayback();
    }

    public void StartPlayback()

    {
        //9 is the number of the track we are reading notes from
        //you'll have to experiment with that, i cant remember why i chose 9 here
        for (int i = 1; i < midi.Events.Tracks; i++)
        {
            foreach (MidiEvent note in midi.Events[i])

            {
                //If its the start of the note event

                if (note.CommandCode == MidiCommandCode.NoteOn)

                {
                    //Cast to note event and process it

                    NoteOnEvent noe = (NoteOnEvent)note;

                    NoteEvent(noe, i);
                }
            }
        }
    }

    public void NoteEvent(NoteOnEvent noe, int track)

    {
        //The bpm(tempo) of the track
        float bpm = 150;
        //Time until the start of the note in seconds
        float time = (60 * noe.AbsoluteTime) / (bpm * ticks);
        int noteNumber = noe.NoteNumber;

        //Start coroutine for each note at the start of the playback
        //Really awful way to do stuff, but its simple
        StartCoroutine(CreateAction(time, noteNumber, noe.NoteLength, track));
    }

    private IEnumerator CreateAction(float t, int noteNumber, float length, int track)

    {
        //Wait for the start of the note
        yield return new WaitForSeconds(t);

        //The note is about to play
        switch (track)
        {
            case 1:
                noteNumber -= 40;
                break;

            case 2:
                noteNumber -= 45;
                break;

            case 3:
                noteNumber -= 50;
                break;

            case 4:
                noteNumber -= 55;
                break;

            case 5:
                noteNumber -= 59;
                break;

            case 6:
                noteNumber -= 64;
                break;

            default:
                break;
        }

        string noteName = noteNumber.ToString() + track.ToString();
        switch (track)
        {
            case 1:
                noteSpowner.SpownNote(noteNumber, PathsAndConstants.StringColors.EColor, noteName);
                break;

            case 2:
                noteSpowner.SpownNote(noteNumber, PathsAndConstants.StringColors.AColor, noteName);
                break;

            case 3:
                noteSpowner.SpownNote(noteNumber, PathsAndConstants.StringColors.DColor, noteName);
                break;

            case 4:
                noteSpowner.SpownNote(noteNumber, PathsAndConstants.StringColors.GColor, noteName);
                break;

            case 5:
                noteSpowner.SpownNote(noteNumber, PathsAndConstants.StringColors.BColor, noteName);
                break;

            case 6:
                noteSpowner.SpownNote(noteNumber, PathsAndConstants.StringColors.eColor, noteName);
                break;

            default:
                break;
        }

        Debug.Log("Playing note: " + noteName);
    }
}