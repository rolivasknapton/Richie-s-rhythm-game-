using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Button_Properties : songInput
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Find_First();
    }
    public override void Find_First()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("MusicNote");
        print(gameObjects.Length);
        /*if (gameObjects.Length >= 1)
        {
            notes_onscreen = true;
        }
        else
        {
            notes_onscreen = false;
        }
        if (notes_onscreen)
        {
            MakeTopNoteSelectable(gameObjects[0]);
        }*/
    }

}
