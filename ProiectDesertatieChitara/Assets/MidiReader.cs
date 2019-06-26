using UnityEngine;

//using System.Collections;

//using NAudio.Midi;

//using System.IO;

//using System.Linq;


public class MidiReader : MonoBehaviour
{


    //public MidiFile midi;


    //public float ticks;

    //public float offset;


    // Use this for initialization

    //void Start()
    //{

    //    //Loading midi file "mainSong.bytes" from resources folder

    //    //Its a midi file, extension has been changed to .bytes manually

    //    TextAsset asset = Resources.Load("mainSong") as TextAsset;

    //    Stream s = new MemoryStream(asset.bytes);

    //    //Read the file

    //    midi = new MidiFile(s, true);

    //    //Ticks needed for timing calculations

    //    ticks = midi.DeltaTicksPerQuarterNote;

    //}


    //public void StartPlayback()

    //{

    //    //9 is the number of the track we are reading notes from

    //    //you'll have to experiment with that, i cant remember why i chose 9 here

    //    foreach (MidiEvent note in midi.Events[9])

    //    {

    //        //If its the start of the note event

    //        if (note.CommandCode == MidiCommandCode.NoteOn)

    //        {

    //            //Cast to note event and process it

    //            NoteOnEvent noe = (NoteOnEvent)note;

    //            NoteEvent(noe);

    //        }

    //    }

    //}


    //public void NoteEvent(NoteOnEvent noe)

    //{

    //    //The bpm(tempo) of the track

    //    float bpm = 150;



    //    //Time until the start of the note in seconds

    //    float time = (60 * noe.AbsoluteTime) / (bpm * ticks);



    //    //The number (key) of the note. Heres a useful chart of number-to-note translation:

    //    //http://www.electronics.dit.ie/staff/tscarff/Music_technology/midi/midi_note_numbers_for_octaves.htm

    //    int noteNumber = noe.NoteNumber;


    //    //Start coroutine for each note at the start of the playback

    //    //Really awful way to do stuff, but its simple

    //    StartCoroutine(CreateAction(time, noteNumber, noe.NoteLength));

    //}


    //IEnumerator CreateAction(float t, int noteNumber, float length)

    //{

    //    //Wait for the start of the note

    //    yield return new WaitForSeconds(t);

    //    //The note is about to play, do your stuff here

    //    Debug.Log("Playing note: " + noteNumber);

    //}



}