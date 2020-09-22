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
        for (int i = 1; i < 5; i++)
        {

            Instantiate(small_robot, new Vector3(1070f, 110f, 4300f), Quaternion.Euler(0f, -90f, 0f));
            Instantiate(small_robot, new Vector3(1010f, 110f, 4300f), Quaternion.Euler(0f, -90f, 0f));
            yield return new WaitForSeconds(6f);
        }

        yield return new WaitForSeconds(10f);
        for (int i = 1; i < 5; i++)
        {
            Instantiate(small_robot, new Vector3(1070f, 110f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(1040f, 110f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(1010f, 110f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(6f);
        }
        yield return new WaitForSeconds(5f);
        for (int i = 1; i < 5; i++)
        {
            Instantiate(robot_bike, new Vector3(1100f, 125f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(1070f, 110f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(1010f, 110f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(robot_bike, new Vector3(980f, 125f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(8f);
        }
        yield return new WaitForSeconds(8f);
        for (int i = 1; i < 5; i++)
        {
            Instantiate(robot_bike, new Vector3(1100f, 125f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(1070f, 110f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(airship, new Vector3(1040f, 300f, 4300f), Quaternion.Euler(0f, -90f, 0f));
            Instantiate(small_robot, new Vector3(1010f, 110f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(robot_bike, new Vector3(980f, 125f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(8f);
        }
        yield return new WaitForSeconds(8f);
        for (int i = 1; i < 5; i++)
        {
            Instantiate(robot_bike, new Vector3(1070f, 125f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(airship, new Vector3(1040f, 300f, 4300f), Quaternion.Euler(0f, -90f, 0f));
            Instantiate(robot_bike, new Vector3(1010f, 125f, 4300f), Quaternion.Euler(0f, 180f, 0f));
            yield return new WaitForSeconds(8f);
        }
        Instantiate(zeppelin, new Vector3(1040f, 400f, 4300f), Quaternion.Euler(0f, -90f, 0f)); ;
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
