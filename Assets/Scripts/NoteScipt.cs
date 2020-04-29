using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteScipt : MonoBehaviour
{
    Vector2 SpawnPos;
    Vector2 RemovePos;
   

    public float beatOfThisNote;
    float positionInSong;
    public bool canBePressed;
    public bool overLap = true;
    public int noteCountCollisions = 0;
    public int  activatorCountCollisions = 0;

    private bool note_Early;
    GameObject box;
    GameObject text;
    public GameObject sprite_perfect;
    public GameObject sprite_good;
    private Text text_content;

    
    public float LerpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = new Vector2(-.92f, 4.76f);
        RemovePos = new Vector2(-.92f, -5.7f);
            
        beatOfThisNote = SongManager.songPosInBeats;

        
        // Pick a random, saturated and not-too-dark color
        //GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        

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
        //i picked this speed . at this rate it takes 6 beats before the note reaches the button
        

        //activator
        if(activatorCountCollisions >=2)
        {
            canBePressed = true;
            //Debug.Log("yo");
        }
        if (activatorCountCollisions >= 2 && songInput.pressed)
        {
            text_content.text = "good";
        }
        if (activatorCountCollisions >= 2 && songInput.pressed_r)
        {
            text_content.text = "good";
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
            text = GameObject.Find("Early_Text");
            box.GetComponent<Renderer>().material.color = Color.green;
            text_content = text.GetComponent<Text>();
            text_content.text = "Early!";
        }
        else
        {
            //box.GetComponent<Renderer>().material.color = Color.white;
            
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
            
            note_Early = true;
            

        }

        
        if (other.tag == "EndPosition")
        {
            this.gameObject.SetActive(false);
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
        
        

        if (other.tag == "Activator_Early")
        {
            note_Early = false;

        }




    }
    public virtual void Pressed()
    {


        if (songInput.pressed && note_Early && canBePressed)
        {

            //print("pressed");
            SongManager.Utilities.scoreAdd();
            this.gameObject.SetActive(false);

            Instantiate(sprite_good, new Vector3(-0.786f, -2.5f, 0), Quaternion.identity);

        }

        if (songInput.pressed && canBePressed)
        {

            //print("pressed");
            SongManager.Utilities.scoreAdd();
            this.gameObject.SetActive(false);
            Instantiate(sprite_perfect, new Vector3(-0.786f, -2.5f, 0), Quaternion.identity);

        }
        
    }
    
}






