using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public AudioSource audioSourceClick;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSourceClick.Play();
            Return();
        }
    }

     public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
