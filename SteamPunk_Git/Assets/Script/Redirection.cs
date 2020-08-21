using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Redirection : MonoBehaviour
{
    public GameObject Controls, Rules, Explanation;
    // Start is called before the first frame update
    void Start()
    {
        Controls.SetActive(true);
        Rules.SetActive(false);
        Explanation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlsPanel()
    {
        Controls.SetActive(true);
        Rules.SetActive(false);
        Explanation.SetActive(false);
    }

    public void RulesPanel()
    {
        Controls.SetActive(false);
        Rules.SetActive(true);
        Explanation.SetActive(false);
    }

    public void ExplanationPanel()
    {
        Controls.SetActive(false);
        Rules.SetActive(false);
        Explanation.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }
}
