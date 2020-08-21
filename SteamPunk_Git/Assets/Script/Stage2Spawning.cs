using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Spawning : MonoBehaviour
{
    public GameObject small_robot;
    public GameObject robot_bike;

    public bool endwave = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRobot());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRobot()
    {
        for (int i = 1; i < 15; i++)
        {
            Instantiate(small_robot, new Vector3(4f, 53f, 475f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(24f, 53f, 475f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(4f);
        }

        yield return new WaitForSeconds(10f);

        for (int i = 1; i < 10; i++)
        {
            Instantiate(robot_bike, new Vector3(14f, 67.8f, 475f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(5f);
        }

        yield return new WaitForSeconds(10f);

        for (int i = 1; i < 15; i++)
        {
            Instantiate(small_robot, new Vector3(0f, 53f, 475f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(robot_bike, new Vector3(27f, 53f, 475f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(4f);
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            endwave = true;
        }
    }
}
