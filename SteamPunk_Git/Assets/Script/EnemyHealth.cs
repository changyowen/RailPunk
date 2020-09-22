using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float small_robot_hp = 5;
    float robot_bike_hp = 10;
    float airship_hp = 10;
    float zeppelin_boss_hp = 250;
    public float EnemyHp;

    // Start is called before the first frame update
    void Start()
    {
        if(this.name.Contains("Small_Robot"))
        {
            EnemyHp = small_robot_hp;
        }
        else if (this.name.Contains("Robot_Bike"))
        {
            EnemyHp = robot_bike_hp;
        }
        if (this.name.Contains("AirShip"))
        {
            EnemyHp = airship_hp;
        }
        if (this.name.Contains("zeppelin"))
        {
            EnemyHp = zeppelin_boss_hp;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int amount)
    {
        EnemyHp -= amount;
        if (EnemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
