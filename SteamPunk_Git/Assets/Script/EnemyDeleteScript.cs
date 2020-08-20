using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeleteScript : MonoBehaviour
{
    public int hp = 5;

    void Update()
    {
        if(hp < 1)
        {
            Destroy(gameObject);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
