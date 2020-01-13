﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songInput : MonoBehaviour
{
    public static bool pressed = false;
    
    public static bool pressed_r = false;
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

        //this equates touchposition to thhe camera's position
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        Debug.DrawLine(Vector3.zero, touchPosition, Color.red);

        //touch and creates lines
        /*
        for(int i = 0;i < Input.touchCount; i ++)
         {
             //this is a way to draw lines
             Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
             Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
         }
        /*
         /*
         for (int i = 0; i < Input.touchCount; ++i)
         {
             if (Input.GetTouch(i).phase == TouchPhase.Began)
             {
                 this.GetComponent<Renderer>().material.color = Color.blue;
                 Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);


                 RaycastHit raycastHit;
                 // Create a particle if hit
                 if (Physics.Raycast(ray, out raycastHit))
                 {
                     if (raycastHit.collider.CompareTag("Activator"))
                     {

                        // Destroy(gameObject);
                     }
                 }
             }
             if (Input.GetTouch(i).phase == TouchPhase.Ended)
             {
                 this.GetComponent<Renderer>().material.color = Color.white;
             }
             // Construct a ray from the current touch coordinates


         }
         */
    }
    public virtual void Find_First()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("MusicNote");
        //print(gameObjects.Length);
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
    public virtual void OnMouseDown()
    {
        
            
      //this needs dual functionality
            pressed = true;
        print("Left Press");
        
        
        
    }
    private void OnMouseUp()
    {
        pressed = false;
        pressed_r = false;
    }
    
    public virtual void MakeTopNoteSelectable(GameObject first)
    {
        first.GetComponent<Renderer>().material.color = Color.red;
        NoteScipt nScript = first.GetComponent<NoteScipt>();

        nScript.overLap = false;
    }
}
