using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songInput : MonoBehaviour
{
    public static bool pressed = false;
    public NoteScipt noteScript;
    
    
    private List<GameObject> noteList;
    private GameObject first;
    private bool notes_onscreen;
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        //store how many there are 


        Find_First();


        //


        //touch controlls

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit raycastHit;
                // Create a particle if hit
                if (Physics.Raycast(ray, out raycastHit))
                {
                   if (raycastHit.collider.CompareTag("Activator"))
                    {
                        
                        Destroy(gameObject);
                    }
                }
            }
        
        }
    }
    public virtual void Find_First()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("MusicNote");
        print(gameObjects.Length);
        if (gameObjects.Length >= 1)
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
        }
    }
    void OnMouseDown()
    {
        
            
      
            pressed = true;
        
        
        
    }
    private void OnMouseUp()
    {
        pressed = false;
    }
    
    public void MakeTopNoteSelectable(GameObject first)
    {
        first.GetComponent<Renderer>().material.color = Color.red;
        NoteScipt nrScript = first.GetComponent<NoteScipt>();

        nrScript.overLap = false;
    }
}
