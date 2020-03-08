using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float x = 0.1f;
    public float y = 0.1f;
    public float z = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fire_Fade");

        transform.localScale = new Vector3(x, y, z);
    }
    private void Update()
    {
        
        
    }

    IEnumerator Fire_Fade()
    {

        yield return new WaitForSeconds(0.2f);
      


        this.gameObject.SetActive(false);
        yield return null;
    }
}
