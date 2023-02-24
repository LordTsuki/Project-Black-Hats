using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource audioSourceClick;
    public AudioSource audioSourceSelected;
    public GameObject[] options;
    public GameObject arrow;

    private int selectedOption = 0;

    void Start()
    {
        SetOption(selectedOption);
    }

    void Update()
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

    void SetOption(int optionIndex)
    {
        arrow.transform.position = options[optionIndex].transform.position + new Vector3(-1f, 0f, 0f);
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
                Play();
                break;
            case 1:
                Credits();
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
        SceneManager.LoadScene(2);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}