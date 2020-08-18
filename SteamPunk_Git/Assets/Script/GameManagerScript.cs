using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject small_robot;

    public bool spawnRobot = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRobot());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        } 
    }

    IEnumerator SpawnRobot()
    {
        while(spawnRobot == true)
        {
            Instantiate(small_robot, new Vector3(14f, 53f, 475f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(5f);
        }
    }
}
