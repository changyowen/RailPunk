using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageSpawn : MonoBehaviour
{
    public GameObject small_robot, robot_bike, airship, zeppelin;

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
        for (int i = 1; i < 8; i++)
        {
            Instantiate(small_robot, new Vector3(14f, 53f, 475f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(5f);
        }

        for (int i = 1; i < 8; i++)
        {
            Instantiate(small_robot, new Vector3(4f, 53f, 475f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(24f, 53f, 475f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(7f);
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
