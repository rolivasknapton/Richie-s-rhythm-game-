using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class score : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent <Text> ();

        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + SongManager.score;
    }
}
