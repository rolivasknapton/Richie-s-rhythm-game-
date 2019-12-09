using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Button_Properties : songInput
{
    private bool notes_onscreen;
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    
    public override void Find_First()
    {
       

        GameObject[] gameObjects_R;
        gameObjects_R = GameObject.FindGameObjectsWithTag("MusicNote_R");
        //print(gameObjects_R.Length);
        if (gameObjects_R.Length >= 1)
        {
            notes_onscreen = true;
        }
        else
        {
            notes_onscreen = false;
        }
        if (notes_onscreen)
        {
            ///this conflicts with the other scripte 
            MakeTopNoteSelectable(gameObjects_R[0]);
        }
    }
    public override void MakeTopNoteSelectable(GameObject first_R)
    {
        first_R.GetComponent<Renderer>().material.color = Color.red;
        NoteScipt nrScript = first_R.GetComponent<NoteScipt>();

        nrScript.overLap = false;
    }
    public override void OnMouseDown()
    {


       
        pressed_r = true;
        


    }
}
