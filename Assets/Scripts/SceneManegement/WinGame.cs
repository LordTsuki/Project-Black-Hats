using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public Transform gameWin;
    public Transform healthBar;
    public AudioSource audioSourceClick;
    public AudioSource audioSourceSelected;
    public AudioSource musicGame;
    public AudioSource musicWin;
    public GameObject[] options;
    public GameObject arrow;

    private int selectedOption = 0;


    void Awake()
    {
        gameWin.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void Start()
    {
        SetOption(selectedOption);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameWin.gameObject.SetActive(true);
            healthBar.gameObject.SetActive(false);
            Time.timeScale = 0;
            musicGame.Stop();
            musicWin.Play();
        }
    }

    void Update()
    {
  
        if (gameWin.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                selectedOption--;
                if (selectedOption < 0)
                {
                    selectedOption = options.Length - 1;
                }
                audioSourceSelected.Play();
                SetOption(selectedOption);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                selectedOption++;
                if (selectedOption >= options.Length)
                {
                    selectedOption = 0;
                }
                audioSourceSelected.Play();
                SetOption(selectedOption);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                audioSourceClick.Play();
                ExecuteOption(selectedOption);
            }
        }
    }

    void SetOption(int optionIndex)
    {
        arrow.transform.position = options[optionIndex].transform.position + new Vector3(-420f, 0f, 0f);
        for (int i = 0; i < options.Length; i++)
        {
            if (i == optionIndex)
            {
                options[i].GetComponent<MenuOption>().SelectOption();
            }
            else
            {
                options[i].GetComponent<MenuOption>().DeselectOption();
            }
        }
    }

    void ExecuteOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0:
                Credits();
                break;
            case 1:
                Return();
                break;
            case 2:
                Exit();
                break;
            default:
                break;
        }
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync(3);
        SceneManager.LoadSceneAsync(2);
    }

    public void Return()
    {
        SceneManager.LoadSceneAsync(3);
        SceneManager.LoadSceneAsync(0);
    }
}

