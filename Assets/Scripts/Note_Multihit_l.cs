using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Multihit_l : NoteScipt
{
    public GameObject Animation_fire;
    Vector2 SpawnPos_ml = new Vector2(-.92f, 4.76f);
    Vector2 RemovePos_ml = new Vector2(-.92f, -5.7f);
    // Start is called before the first frame update
    public override void Move()
    {
        transform.position = Vector2.Lerp(SpawnPos_ml, RemovePos_ml, ((beatOfThisNote - SongManager.songPosInBeats) * -1) / 7);
        overLap = false;
    }
    public override void Pressed()
    {
        if (songInput.pressed && canBePressed)
        {
            print("pressed");
            this.gameObject.SetActive(false);
            Instantiate(Animation_fire);

        }
    }

}
