using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    int note_number;
    
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
    [SerializeField]
    public static float bpm;

    public GameObject MusicNote;
    public GameObject MusicNote_R;
    public GameObject MusicNote_Multi;
    public GameObject MusicNote_Multi_l;
    //keep all the position-in-beats of notes in the song
    float[] notes = {1,4,9,10,16,19,25,26,29,33,34, 36,36.5f,39,42.5f,43,45,49,51,53,55,57,62,64,65, 66,67.5f,68, 71,72.5f,74,75,76};
    float[] notes_r = {1,5, 8, 13,15, 17,20,21,24,31,33,35f, 35.5f,41,42,43.5f,44,47,48,50,54,60.5f,65,67,69,69.5f,70,73,75.5F,76.5F};
    float[] notes_multi = {11,27,37,72,78, };
    float[] notes_multi_l = { 79 };
    //the index of the next note to be spawned
    public static int nextIndex = 0;
    public static int nextIndex_r = 0;
    public static int nextIndex_multi = 0;
    public static int nextIndex_multi_l = 0;



    //just some logic on metro
    bool metroisnothere = true;

    //the offset
    public float firstBeatOffset;
    Renderer cubeRenderer;


    private float shift = 10f;
    // Start is called before the first frame update
    void Start()
    {
        firstBeatOffset =0f;
        Setbeatsperminute();
       

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
        songPosInBeats = songPosition / secPerBeat ;

        //note spawners
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
        if (nextIndex_multi < notes_multi.Length && notes_multi[nextIndex_multi] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_Multi, new Vector3(.92f, 3.76f, 0), Quaternion.identity);




            nextIndex_multi++;
        }
        if (nextIndex_multi_l < notes_multi_l.Length && notes_multi_l[nextIndex_multi_l] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_Multi_l, new Vector3(-.92f, 3.76f, 0), Quaternion.identity);




            nextIndex_multi_l++;
        }



        //spawns the metronome when the first beat is played. 
        if (songPosInBeats >= 2&&metroisnothere)
        {
            //Instantiate(metro, new Vector3(0, 0, 0), Quaternion.identity); metroisnothere = false;
        }
        //Debug.Log(songPosInBeats);
    }

    public virtual void Setbeatsperminute()
    {
        bpm = 161f;
    }
        //why is this an IEnumerator?
    IEnumerator songStart()
    {
        GetComponent<AudioSource>().Play();
        
        
        yield return null;

    }
    
}
