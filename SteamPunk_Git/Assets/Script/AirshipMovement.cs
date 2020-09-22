using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipMovement : MonoBehaviour
{
    public bool moving = true;
    private float minionSpeed = 50f;
    Rigidbody rb;

    public GameObject Icon;
    Quaternion IconRotation;

    void Awake()
    {
        IconRotation = Icon.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == true)
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, -minionSpeed);

        }
    }

    void LateUpdate()
    {
        Icon.transform.rotation = IconRotation;
    }
}
