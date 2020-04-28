using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Note_Properties : NoteScipt
{
    Vector2 SpawnPos_R = new Vector2(.92f, 4.76f);
    Vector2 RemovePos_R = new Vector2(.92f, -5.7f);


    // Update is called once per frame
    private bool note_Early_r;
    public override void Move()
    {
        transform.position = Vector2.Lerp(SpawnPos_R, RemovePos_R, ((beatOfThisNote - SongManager.songPosInBeats) * -1) / 7);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            activatorCountCollisions++;
        }
        if (other.tag == "Activator_Early")
        {

            note_Early_r = true;
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
            note_Early_r = false;

        }
    }

    public override void Pressed()
    {
        if (Right_Button_Properties.pressed_r && note_Early_r && canBePressed)
        {

            //print("pressed");
            this.gameObject.SetActive(false);
            Instantiate(sprite_good, new Vector3(0.786f, -2.5f, 0), Quaternion.identity);

        }
        if (Right_Button_Properties.pressed_r && canBePressed)
        {
            //print("pressed");
            this.gameObject.SetActive(false);
            Instantiate(sprite_perfect, new Vector3(0.786f, -2.5f, 0), Quaternion.identity);
        }
        
        
    }
}
