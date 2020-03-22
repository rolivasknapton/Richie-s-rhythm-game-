using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Animation_two;
    public GameObject Animation;
    private void Update()
    {
        if (songInput.held)
        {
            Instantiate(Animation);
        }

        if (songInput.held_r)
        {
            Instantiate(Animation_two);
        }
    }
    
    
    
}