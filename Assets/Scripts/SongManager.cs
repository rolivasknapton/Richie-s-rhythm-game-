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
    public AudioSource audioSource;

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
    float[] notes = {1,4,9,10,16,19,25,26,29,33,34, 36,36.5f,39,42.5f,43,45,49,51,53,55,57,62,64,65, 66,67.5f,68, 71,72.5f,74,75,76,81, 82,83,83.5f,84,85,86,87,88,89,91,93.5F,94.5F,95.5F,96.5F,97,98,99,100,101,103,104,104.5f,105,105.5f,106.5f,109,109.5f,110,110.5f,113,117,118,119,123,124,125,129,132,137,139,139.5f,140,141,143,145,148,149,151,153,155,156,157};
    float[] notes_r = {1,5, 8, 13,15, 17,20,21,24,31,33,35f, 35.5f,41,42,43.5f,44,47,48,50,54,60.5f,65,67,69,69.5f,70,73,75.5F,76.5F,81,82,83,83.5f,84,85,87,88.5F,92.5F,93,97,99,101,102,103,107,108.5f,111,113,114,115,116.5f,119.5f,120,120.5f,121,122,129,130,131,131.5f,133,135,137,138,145,146,147,149,151,153,155.5f,156.5f, 157};
    float[] notes_multi_l = { 80, 112, 127.5f, 133,159 };
    float[] notes_multi = {11,27,37,72,78,90,125.5f ,141,159};
    

    
    float [] notes_space_left= { 11, 11.5f, 12.5f, 14.5f, 16, 16.5f, 17.5f, 18, 21, 22, 23, 24, 26.5f, 27, 29, 31, 32.5f, 35, 37, 39, 40.5F, 45, 49, 50, 51, 54, 59, 61.5f, 61.75f, 62.5f, 63, 64, 66, 66.75f, 73.75f, 75, 77.5f, 79, 81.75f, 83.5f, 83.75f, 84, 84.25f, 84.5f, 86, 86.5f, 88.5f, 89, 89.75f, 90.5f, 93,  94,94.5f , 97.5f,98,99.5f,100.5f ,101.5f, 102.5f, 103.5f, 104.5f, 105.5f, 106.5f, 107};
    float[] notes_space_right= { 13.5f, 14, 15, 18.5f, 19, 19.5F, 20.5f, 24.5f, 26, 27.5f, 28.5f, 29.5f, 30, 30.5f, 31, 32, 33.5F, 34, 34.5f, 34.75f, 35, 36, 36.5F, 37, 38, 39, 40, 44, 46, 49.5f, 50.5f, 52, 53, 54, 54.5f, 55, 57, 57.75f, 58.5f, 59, 61, 62.5f, 63, 65, 66.5f, 70,70.5f, 71,73,74.5f,75,78.25f,78.5f,80,80.5f,85,87, 87.75f,90.75f,92.75f, 95.75f,96,96.25f, 97.50f ,98,99, 100 ,101,102,103,104,105,106,};
                                                                                                                                                                                                                                                float[] notes_space_left_multi ={43,76,81,87};
                                                                                                                                                                                                                                               float[] notes_space_right_multi ={  47.5f,67,77,107};
    
    //the index of the next note to be spawned
    private static int shift = 0;
    public static int nextIndex = 0+shift;
    public static int nextIndex_r = 0+shift;
    public static int nextIndex_multi = 0;
    public static int nextIndex_multi_l = 0;



    //just some logic on metro
    bool metroisnothere = true;

    //the offset
    public float firstBeatOffset;
    Renderer cubeRenderer;


    
    // Start is called before the first frame update
    void Start()
    {
        firstBeatOffset =0f;
        Setbeatsperminute();
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 0;
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
    public virtual void Update()
    {
        
        //calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong - firstBeatOffset);
        
        


        //calculate the position in beats
        songPosInBeats = (songPosition / secPerBeat)+shift ;

        //note spawners
        if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote, new Vector3(-.92f, 4.76f, 0), Quaternion.identity);

            


            nextIndex++;
        }
        if (nextIndex_r < notes_r.Length && notes_r[nextIndex_r] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_R, new Vector3(.92f, 4.76f, 0), Quaternion.identity);




            nextIndex_r++;
        }
        if (nextIndex_multi < notes_multi.Length && notes_multi[nextIndex_multi] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_Multi, new Vector3(.92f, 4.76f, 0), Quaternion.identity);




            nextIndex_multi++;
        }
        if (nextIndex_multi_l < notes_multi_l.Length && notes_multi_l[nextIndex_multi_l] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_Multi_l, new Vector3(-.92f, 4.76f, 0), Quaternion.identity);




            nextIndex_multi_l++;
        }



        //spawns the metronome when the first beat is played. 
        /*if (songPosInBeats >= 16 &&metroisnothere)
        {
            Instantiate(metro, new Vector3(0, 0, 0), Quaternion.identity); metroisnothere = false;
        }*/
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

    //space notes update
    public void Space_Notes()
    {
        //calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong - firstBeatOffset);




        //calculate the position in beats
        songPosInBeats = (songPosition / secPerBeat);

        //note spawners
        if (nextIndex < notes_space_left.Length && notes_space_left[nextIndex] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote, new Vector3(-.92f, 4.76f, 0), Quaternion.identity);




            nextIndex++;
        }
        if (nextIndex_r < notes_space_right.Length && notes_space_right[nextIndex_r] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_R, new Vector3(.92f, 4.76f, 0), Quaternion.identity);




            nextIndex_r++;
        }
        if (nextIndex_multi < notes_space_right_multi.Length && notes_space_right_multi[nextIndex_multi] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_Multi, new Vector3(.92f, 4.76f, 0), Quaternion.identity);




            nextIndex_multi++;
        }
        if (nextIndex_multi_l < notes_space_left_multi.Length && notes_space_left_multi[nextIndex_multi_l] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_Multi_l, new Vector3(-.92f, 4.76f, 0), Quaternion.identity);




            nextIndex_multi_l++;
        }
        //spawns the metronome when the first beat is played. 
        if (songPosInBeats >= 8 && metroisnothere)
        {
            Instantiate(metro, new Vector3(0, 0, 0), Quaternion.identity); metroisnothere = false;
        }
        //Debug.Log(songPosInBeats);   
    }

}
