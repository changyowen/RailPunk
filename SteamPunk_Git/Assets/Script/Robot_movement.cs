using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_movement : MonoBehaviour
{
    public bool moving = true;
    Rigidbody rb;
    // Update is called once per frame
    void Start()
    {
        //StartCoroutine(Moving());
    }

    private void Update()
    {
        while (moving == true)
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 10, 0);
            //yield return new WaitForSeconds(.2f);
        }
    }

    //IEnumerator Moving()
    //{
    //    while(moving == true)
    //    {
    //        rb = GetComponent<Rigidbody>();
    //        rb.velocity = new Vector3(0, 10, 0);
    //        //yield return new WaitForSeconds(.2f);
    //    }
    //}
}
