using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        //{
        //    SceneManager.LoadScene("GamePlay");
        //}

    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay");

    }
}
