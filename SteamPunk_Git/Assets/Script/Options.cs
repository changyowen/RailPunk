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
    Animator panelHolder;


    // Start is called before the first frame update
    void Start()
    {
        panelHolder = GetComponent<Animator>();
        optionpanel.SetActive(true);
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
                panelHolder.SetBool("OpenOption", true);
                StartCoroutine(Pause());
            }
        }
    }
    IEnumerator Pause()
    {
        SoundManager.playPauseSound();
        yield return new WaitForSeconds(.25f);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Paused");
        Time.timeScale = 0f;
        
        GamePaused = true;
    }

    public void Unpause()
    {
        SoundManager.playPauseSound();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GamePaused = false;
        panelHolder.SetBool("OpenOption", false);
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
