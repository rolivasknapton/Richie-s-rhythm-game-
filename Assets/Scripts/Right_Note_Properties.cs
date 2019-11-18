using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Note_Properties : NoteScipt
{
    Vector2 SpawnPos_R = new Vector2(.92f, 3.76f);
    Vector2 RemovePos_R = new Vector2(.92f, -5.7f);

    
    // Update is called once per frame
    void Update()
    {

        Move();

    }
    public override void Move()
    {
        transform.position = Vector2.Lerp(SpawnPos_R, RemovePos_R, ((beatOfThisNote - SongManager.songPosInBeats) * -1) / 7);
    }
}
