using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Multihit : NoteScipt
{
    public GameObject Animation_fire;
    Vector2 SpawnPos_m = new Vector2(.92f, 3.76f);
    Vector2 RemovePos_m = new Vector2(.92f, -5.7f);


    // Update is called once per frame

    public override void Move()
    {
        transform.position = Vector2.Lerp(SpawnPos_m, RemovePos_m, ((beatOfThisNote - SongManager.songPosInBeats) * -1) / 7);
        overLap = false;
    }
    public override void Pressed()
    {
        if(songInput.pressed_r && canBePressed )//&& (Input.GetTouch(0).phase ==TouchPhase.Stationary)
        {
            print("pressed");
            this.gameObject.SetActive(false);
            Instantiate(Animation_fire);

        }
    }

}
