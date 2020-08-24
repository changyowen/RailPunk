using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    AsyncOperation asyncOperation;
    private float waitToEnable= 0;
    private float waitToTrigger= 0;

    public static int SceneNeedToLoad = 0;

    void Start()
    {
        Init();
    }

    void Init()
    {
        Time.timeScale = 1f;
        asyncOperation = SceneManager.LoadSceneAsync(SceneNeedToLoad);
        SceneNeedToLoad = 0;
        asyncOperation.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                waitToEnable += Time.deltaTime;
                if (waitToEnable >= 5f)
                {
                    waitToTrigger += Time.deltaTime;
                    GearWheelRotation.speedMultiplyer = 10;
                    if (waitToTrigger >= 2f)
                    {
                        waitToEnable = 0;
                        waitToTrigger = 0;
                        GearWheelRotation.speedMultiplyer = 1;
                        asyncOperation.allowSceneActivation = true;
                    }
                }
            }
        }
    }
}
