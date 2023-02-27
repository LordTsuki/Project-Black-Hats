using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenusController : MonoBehaviour
{
    public GameObject panelGameOver;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }
}
