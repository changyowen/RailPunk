﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Redirection : MonoBehaviour
{
    public GameObject Controls, Rules, Explanation, Guns;
    // Start is called before the first frame update
    void Start()
    {
        Controls.SetActive(true);
        Guns.SetActive(false);
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
        Guns.SetActive(false);
        Rules.SetActive(false);
        Explanation.SetActive(false);
    }

    public void GunsPanel()
    {
        Controls.SetActive(false);
        Guns.SetActive(true);
        Rules.SetActive(false);
        Explanation.SetActive(false);
    }

    public void RulesPanel()
    {
        Controls.SetActive(false);
        Guns.SetActive(false);
        Rules.SetActive(true);
        Explanation.SetActive(false);
    }

    public void ExplanationPanel()
    {
        Controls.SetActive(false);
        Guns.SetActive(false);
        Rules.SetActive(false);
        Explanation.SetActive(true);
    }

    public void StartGame()
    {
        LoadingScript.SceneNeedToLoad = 3;
        SceneManager.LoadScene("LoadingScreen");
    }
}
