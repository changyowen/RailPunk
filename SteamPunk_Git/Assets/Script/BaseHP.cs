using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseHP : MonoBehaviour
{
    int basehitpoint = 10;
    public Text hptext;
    public GameManagerScript condition;
    public bool victory;
    public GameObject victorypanel, win, lose;
    public Collider basecollider;

    // Start is called before the first frame update
    void Start()
    {
        victory = condition.endwave;
        victorypanel.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        victory = condition.endwave;
        if (basehitpoint == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            victorypanel.SetActive(true);
            lose.SetActive(true);
        }

        if(victory == true && basehitpoint > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            victorypanel.SetActive(true);
            win.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            basehitpoint--;
            hptext.text = basehitpoint.ToString();
            Destroy(other.gameObject); 
        }
    }

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        victorypanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Cursor.lockState = CursorLockMode.None;
        victorypanel.SetActive(false);
        Time.timeScale = 1f;
        Application.Quit();
    }
}
