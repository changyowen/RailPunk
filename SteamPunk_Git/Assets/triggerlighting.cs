using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class triggerlighting : MonoBehaviour
{
    public GameObject lightning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            lightning.GetComponent<LightningBoltScript>().Trigger();
        }
    }
}
