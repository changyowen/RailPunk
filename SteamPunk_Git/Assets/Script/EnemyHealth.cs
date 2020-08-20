using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float small_robot_hp = 5;
    public float EnemyHp;

    // Start is called before the first frame update
    void Start()
    {
        if(this.name.Contains("Small_Robot"))
        {
            EnemyHp = small_robot_hp;
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
