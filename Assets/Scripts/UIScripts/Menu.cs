using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    private IEnumerator coroutine;
    public void ButtonClick()
    {
        //coroutine = ButtonPressedAnim(1); SceneManager.LoadScene(1);
        StartCoroutine(ButtonPressedAnim(1));
    }
    public void ButtonClicktwo()
    {
        StartCoroutine(ButtonPressedAnim(2));
    }
    public void ButtonClickBACK()
    {
        StartCoroutine(ButtonPressedAnim(0));
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //coroutine = ButtonPressedAnim(1);
        //SceneManager.LoadScene(1);   
    }
    /*public void LoadA(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ButtonPressedAnim(int scene)
    {
        
        for (float ft = 0.2f; ft >= 0; ft -= 0.1f)

        {

            yield return new WaitForSeconds(0.08f);

        }
        SceneManager.LoadScene(scene);
    }
}
