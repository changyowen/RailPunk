using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseHP : MonoBehaviour
{
    int maxhitpoint = 10;
    int basehitpoint = 10;
    public Text hptext;
    public GameManagerScript condition;
    public Stage2Spawning condition2;
    public bool victory;
    public GameObject victorypanel, win, lose, Hpbar;
    public Image HpImage;
    public Collider basecollider;
    public int index;

    Color greenColor = new Color(0f, 0.451f, 0f, 1f);
    Color yellowColor = new Color(0.824f, 0.82f, 0f, 1f);
    Color redColor = new Color(0.663f, 0f, 0f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        if(index == 2)
        {
            victory = condition.endwave;
        }
        else if(index == 3)
        {
            victory = condition2.endwave;
        }
        victorypanel.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(basehitpoint >= 0)
        {
            Hpbar.transform.localScale = new Vector3((float)basehitpoint / (float)maxhitpoint, 1f, 1f);
        }
        
        if(basehitpoint > 5)
        {
            HpImage.color = greenColor;
        }
        else if(basehitpoint > 3 && basehitpoint <= 5)
        {
            HpImage.color = yellowColor;
        }
        else
        {
            HpImage.color = redColor;
        }

        if (index == 2)
        {
            victory = condition.endwave;
        }
        else if (index == 3)
        {
            victory = condition2.endwave;
        }
        if (basehitpoint == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            victorypanel.SetActive(true);
            lose.SetActive(true);
        }
        if(victory == true && basehitpoint > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
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
    public void NextStage()
    {
        {
            int x = SceneManager.GetActiveScene().buildIndex;
            Cursor.lockState = CursorLockMode.None;
            victorypanel.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(x+1);
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
