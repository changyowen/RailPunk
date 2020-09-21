using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Spawning : MonoBehaviour
{
    public GameObject small_robot;
    public GameObject robot_bike;

    public bool endwave = false;
    public bool SpawnEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRobot());
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnEnd == true)
        {
            CheckEnemy();
        }

    }

    IEnumerator SpawnRobot()
    {
        for (int i = 1; i < 7; i++)
        {
            Instantiate(small_robot, new Vector3(515f, 60f, 1310f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(555f, 60f, 1310f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(8f);
        }

        yield return new WaitForSeconds(10f);

        for (int i = 1; i < 7; i++)
        {
            Instantiate(robot_bike, new Vector3(535f, 74.8f, 1310f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(8f);
        }

        yield return new WaitForSeconds(10f);

        for (int i = 1; i < 7; i++)
        {
            Instantiate(small_robot, new Vector3(520f, 60f, 1310f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(robot_bike, new Vector3(545f, 74.8f, 1310f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(6f);
        }

        SpawnEnd = true;
    }
    void CheckEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            endwave = true;
        }
    }
}
