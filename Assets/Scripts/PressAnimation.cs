using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Animation_two;
    public GameObject Animation;

    public bool left_flame_active = false;
    public bool right_flame_active = false;
    private void Update()
    {
        //need to add functionality to only spawn one
        if (songInput.held&& left_flame_active == false)
        {
           
                Instantiate(Animation);
            left_flame_active = true;
            

            
        }
        else if(songInput.held==false)
        {
            left_flame_active = false;
        }
        

        if (songInput.held_r && right_flame_active == false)
        {
            
            
                Instantiate(Animation_two);
            right_flame_active = true;

        }
        else if(songInput.held_r == false)
        {
            right_flame_active = false;
        }
        
        
    }
   


}