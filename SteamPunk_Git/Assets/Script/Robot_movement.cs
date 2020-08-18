using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_movement : MonoBehaviour
{
    public bool moving = true;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        while(moving == true)
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -100f);
            yield return new WaitForSeconds(.2f);
        }
    }
}
