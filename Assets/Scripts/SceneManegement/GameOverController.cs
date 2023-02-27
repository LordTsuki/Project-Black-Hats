using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
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
        arrow.transform.position = options[optionIndex].transform.position + new Vector3(-2.5f, 0f, 0f);
        for (int i = 0; i < options.Length; i++)
        {
            if (i == optionIndex)
            {
                options[i].GetComponent<GameOverOption>().SelectOption();
            }
            else
            {
                options[i].GetComponent<GameOverOption>().DeselectOption();
            }
        }
    }

    void ExecuteOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0:
                Retry();
                break;
            case 1:
                Return();
                break;
            default:
                break;
        }
    }


    public void Retry()
    {
        SceneManager.LoadSceneAsync(3);
        SceneManager.LoadSceneAsync(1);
    }

    public void Return()
    {
        SceneManager.LoadSceneAsync(3);
        SceneManager.LoadSceneAsync(0);
    }
}
