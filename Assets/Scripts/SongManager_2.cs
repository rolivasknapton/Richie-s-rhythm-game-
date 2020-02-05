using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager_2 : SongManager
{
    bool metroisnothere = true;
    //delete this
    float [] notes_space_left= {  1, 4, 9, 10, 16, 19, 25, 26, 29, 33, 34, 36, 36.5f, 39, 42.5f, 43, 45, 49, 51, 53, 55, 57, 62, 64, 65, 66, 67.5f, 68, 71, 72.5f, 74, 75, 76, 81, 82, 83, 83.5f, 84, 85, 86, 87, 88, 89, 91, 93.5F, 94.5F, 95.5F, 96.5F, 97, 98, 99, 100, 101, 103, 104, 104.5f, 105, 105.5f, 106.5f, 109, 109.5f, 110, 110.5f, 113, 117, 118, 119, 123, 124, 125, 129, 133, 137, 141, 145, 149, 153, 157 };
    float[] notes_space_right= { 1, 66, 67.5f, 68, 71, 72.5f, 74, 75, 76, 81, 82, 83, 83.5f, 84, 85, 86, 87, 88, 89 };
    float[] notes_space_left_multi ={ 1, 66, 67.5f, 68, 71, 72.5f, 74, 75, 76, 81, 82, 83, 83.5f, 84, 85, 86, 87, 88, 89 };
    float[] notes_space_right_multi ={ 1, 66, 67.5f, 68, 71, 72.5f, 74, 75, 76, 81, 82, 83, 83.5f, 84, 85, 86, 87, 88, 89 };
    float secPerBeat = 60f / bpm;

    public override void Update()
    {
        Space_Notes();

        /*//calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong - firstBeatOffset);

        


        //calculate the position in beats
        songPosInBeats = (songPosition / secPerBeat);

        //note spawners
        if (nextIndex < notes_space_left.Length && notes_space_left[nextIndex] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote, new Vector3(-.92f, 3.76f, 0), Quaternion.identity);




            nextIndex++;
        }
        if (nextIndex_r < notes_space_right.Length && notes_space_right[nextIndex_r] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_R, new Vector3(.92f, 3.76f, 0), Quaternion.identity);




            nextIndex_r++;
        }
        if (nextIndex_multi < notes_space_right_multi.Length && notes_space_right_multi[nextIndex_multi] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_Multi, new Vector3(.92f, 3.76f, 0), Quaternion.identity);




            nextIndex_multi++;
        }
        if (nextIndex_multi_l < notes_space_left_multi.Length && notes_space_left_multi[nextIndex_multi_l] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(MusicNote_Multi_l, new Vector3(-.92f, 3.76f, 0), Quaternion.identity);




            nextIndex_multi_l++;
        }
        //spawns the metronome when the first beat is played. 
        if (songPosInBeats >= 8 && metroisnothere)
        {
            Instantiate(metro, new Vector3(0, 0, 0), Quaternion.identity); metroisnothere = false;
        }
        //Debug.Log(songPosInBeats);    */
    }

    public override void Setbeatsperminute()
    {
        bpm = 114.95f;
    }

}
