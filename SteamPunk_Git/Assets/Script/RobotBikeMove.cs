using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotBikeMove : MonoBehaviour
{
    public Transform partToRotate;
    public bool moving = true;
    private float minionSpeed = 50f;
    private float rotation = 0;
    Rigidbody rb;

    public GameObject Icon;
    Quaternion IconRotation;

    private int checkScene = 0;

    void Awake()
    {
        IconRotation = Icon.transform.rotation;
        checkScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkScene == 5)
        {
            minionSpeed = 80f;
        }

        if (moving == true)
        {
            rotation += 4f;
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
