using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn_right_flame : Despawn
{
    

    // Update is called once per frame
    public override void Update()
    {
        if (held_right_check&& songInput.held_r == false)
        {
            StartCoroutine("Fire_Fade");
        }
    }
}
