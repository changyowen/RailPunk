﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_movement : MonoBehaviour
{
    public Transform partToRotate;
    public bool moving = true;
    private float minionSpeed = 18f;
    private float rotation = 0;
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
        if(moving == true)
        {
            rotation += 2f;
            partToRotate.transform.localRotation = Quaternion.Euler(rotation, 0, 0);
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, -minionSpeed);
        }
    }

    void LateUpdate()
    {
        Icon.transform.rotation = IconRotation;
    }
}
