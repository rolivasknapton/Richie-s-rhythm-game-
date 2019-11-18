using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    int note_number;
    public GameObject MusicNote;
    public GameObject MusicNote_R;
    public GameObject metro;
    public static float beatsShownInAdvance;
    //the current position of the song (in seconds)
    public static float songPosition;


    //the current position of the song (in beats)
    public static float songPosInBeats;
    //the duration of a beat
   float secPerBeat;

    //how much time (in seconds) has passed since the song started
    public  float dsptimesong;

    //beats per minute of a song
    public static float bpm = 140f;

    //keep all the position-in-beats of notes in the song
    float[] notes = {1,4.5f,5,5.5f,6,7,8,9,10,11,12,13,14,15,16 };
    float[] notes_r = { 1, 4.5f, 5, 5.5f, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

    //the index of the next note to be spawned
    public static int nextIndex = 0;
    public static int nextIndex_r = 0;



    //just some logic on metro
    bool metroisnothere = true;

    //the offset
    public float firstBeatOffset;
    Renderer cubeRenderer;

    

    // Start is called before the first frame update
    void Start()
    {
        firstBeatOffset =.5f;

       

        //Create a new cube primitive to set the color on



        //calculate how many seconds is one beat
        //we will see the declaration of bpm later
        secPerBeat = 60f / bpm;

        //record the time when the song starts
        dsptimesong = (float)AudioSettings.dspTime;


        //start the song
        StartCoroutine("songStart");
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong - firstBeatOffset);
        
        


        //calculate the position in beats
        songPosInBeats = songPosition / secPerBeat;

        if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote, new Vector3(-.92f, 3.76f, 0), Quaternion.identity);

            


            nextIndex++;
        }
        if (nextIndex_r < notes_r.Length && notes_r[nextIndex_r] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_R, new Vector3(.92f, 3.76f, 0), Quaternion.identity);




            nextIndex_r++;
        }



        //spawns the metronome when the first beat is played. 
        if (songPosInBeats >= 1&&metroisnothere)
        {
            //Instantiate(metro, new Vector3(0, 0, 0), Quaternion.identity); metroisnothere = false;
        }
        //Debug.Log(songPosInBeats);
    }
    IEnumerator songStart()
    {
        GetComponent<AudioSource>().Play();
        
        
        yield return null;

    }
    
}
