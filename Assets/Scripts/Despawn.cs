using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float x = 0.1f;
    public float y = 0.1f;
    public float z = 0.1f;
    public bool held_check = false;
    public bool held_right_check = false;
    // Start is called before the first frame update
    void Start()
    {
        //these check if the finger is held down
        if (songInput.held)
        {
            held_check = true;
        }
        if (songInput.held_r)
        {
            held_right_check = true;
        }
        
        

        transform.localScale = new Vector3(x, y, z);
    }
    public virtual void Update()
    {
        
        if (held_check  && songInput.held == false)
        {
            StartCoroutine("Fire_Fade");
        }

    }

    IEnumerator Fire_Fade()
    {

        yield return new WaitForSeconds(0.2f);
      


        this.gameObject.SetActive(false);
        yield return null;
    }
}
