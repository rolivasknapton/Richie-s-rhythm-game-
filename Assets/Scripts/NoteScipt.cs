using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScipt : MonoBehaviour
{
    Vector2 SpawnPos;
    Vector2 RemovePos;
   

    public float beatOfThisNote;
    float positionInSong;
    public bool canBePressed;
    public bool overLap = true;
    public int noteCountCollisions = 0;
    private int  activatorCountCollisions = 0;

    bool note_Early;
    GameObject box;


    public float LerpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = new Vector2(-.92f, 3.76f);
        RemovePos = new Vector2(-.92f, -5.7f);
            
        beatOfThisNote = SongManager.songPosInBeats;

        
        // Pick a random, saturated and not-too-dark color
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        

        //name
        //this.gameObject.name = "" + beatOfThisNote;
        //this.name = "0" + beatOfThisNote;

        
        //checks if the notes are overlapping
        //counts note collisions on spawn
        int noteTotalCollisions = 0;
        for (int i = 0; i < 3; ++i)
        {
            noteTotalCollisions += noteCountCollisions;
            
        }
        int activatorTotalCollisions = 0;
        for (int i = 0; i < 3; ++i)
        {
            activatorTotalCollisions += activatorCountCollisions;

        }

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Pressed();
        //how fast the notes fall

        LerpSpeed = ((beatOfThisNote - SongManager.songPosInBeats) * -1) / 7;
        

        //activator
        if(activatorCountCollisions >=2)
        {
            canBePressed = true;
            //Debug.Log("yo");
        }
        //deactivator 
        if (overLap == true)
        {
            canBePressed = false;
            
        }
        positionInSong = SongManager.songPosition;
        ///this one adds to the vector over time
        ///
        ///transform.position -= new Vector3(0f, 140f/60 *Time.deltaTime, 0f);

        ///this one sets their position
        ///
        ///transform.position = Vector2.Lerp(SpawnPos,RemovePos,(beatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / beatsShownInAdvance);
        
        ///Debug.Log(beatOfThisNote - SongManager.songPosInBeats);
        ///

        //early checker
        if (note_Early)
        {
             box = GameObject.Find("timing_checker");
            box.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            box.GetComponent<Renderer>().material.color = Color.white;
        }


    }
    public virtual void Move()
    {
        transform.position = Vector2.Lerp(SpawnPos, RemovePos, LerpSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            activatorCountCollisions++;
        }
        if (other.tag == "Activator_Early")
        {
            note_Early=true;
            activatorCountCollisions++;
        }

        //if the music note is touching another music note
        /*if (other.tag == "MusicNote")
        {

            overLap = true;
          noteCountCollisions++;

        }*/
        //destroy this object when colliding with the end position
        if (other.tag == "EndPosition")
        {
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            songInput.pressed = false;
            gameObject.tag = "Unactive";
            //gameObject.SetActive(false);
        }
        if (other.tag == "MusicNote")
        {
            
        }

        if (other.tag == "Activator_Early")
        {
            note_Early = false;
            
        }




    }
    public virtual void Pressed()
    {
        if (songInput.pressed && canBePressed)
        {
            print("pressed");
            this.gameObject.SetActive(false);
        }
    }
    
}






