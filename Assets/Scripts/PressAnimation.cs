using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Animation;
    
    private void OnMouseDown()
    {
        //
        //
        Instantiate(Animation);
        
    }
    
    
}