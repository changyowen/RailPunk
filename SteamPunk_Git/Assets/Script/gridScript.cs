using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridScript : MonoBehaviour
{
    public float x_Start, y_Start, z_Start;
    public int x_Length, z_Length;
    public float x_Space, z_Space;
    public GameObject Bridge;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < x_Length * z_Length; i++)
        {
            Instantiate(Bridge, new Vector3(x_Start + (x_Space * (i % x_Length)), y_Start, z_Start + (z_Space * (i / x_Length))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
