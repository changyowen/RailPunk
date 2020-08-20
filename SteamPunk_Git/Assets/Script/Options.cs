using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject optionpanel;
    public GameObject audioSource;
    public static bool GamePaused = false;
    public Toggle musicToggle;
    public AudioSource musicSource;


    // Start is called before the first frame update
    void Start()
    {
        optionpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(GamePaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Paused");
        Time.timeScale = 0f;
        optionpanel.SetActive(true);
        GamePaused = true;
    }

    public void Unpause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        optionpanel.SetActive(false);
        GamePaused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void ToggleMusic()
    {
        if(musicSource==false)
        {
            musicSource.UnPause();
        }
        else if (musicSource == true)
        {
            musicSource.Pause();
        }
    }
}
