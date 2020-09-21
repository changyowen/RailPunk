using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanic : MonoBehaviour
{
    public EnemyHealth health;
    public GameObject small_robot, robot_bike, airship;
    public float location;
    bool droneSpawn, bikeSpawn, shipSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMinion());
    }

    // Update is called once per frame
    void Update()
    {
        location = this.gameObject.transform.position.z;
        if (health.EnemyHp <= 200)
            droneSpawn = true;
        if (health.EnemyHp <= 125)
            bikeSpawn = true;
        if (health.EnemyHp <= 50)
            shipSpawn = true;
    }
    IEnumerator SpawnMinion()
    {
        while(droneSpawn == true)
        {
            Instantiate(small_robot, new Vector3(1070f, 110f, location), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(small_robot, new Vector3(1010f, 110f, location), Quaternion.Euler(0f, 180f, 0f));
            if(bikeSpawn == true)
            {
                Instantiate(robot_bike, new Vector3(1100f, 110f, location), Quaternion.Euler(0f, 180f, 0f));
                Instantiate(robot_bike, new Vector3(980f, 110f, location), Quaternion.Euler(0f, 180f, 0f));
                if(shipSpawn == true)
                {
                    Instantiate(airship, new Vector3(1040f, 300f, location), Quaternion.Euler(0f, 180f, 0f));
                }
            }
            yield return new WaitForSeconds(5f);
        }

    }

}
