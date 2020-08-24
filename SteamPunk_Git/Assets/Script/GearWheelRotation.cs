using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearWheelRotation : MonoBehaviour
{
    private float gearAspeed;
    private float gearBspeed;
    private float loadingSpinSpeed = 2f;
    public static int speedMultiplyer = 1;

    void Start()
    {
        speedMultiplyer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gearAspeed += 20f * Time.deltaTime * speedMultiplyer;
        gearBspeed += 40f * Time.deltaTime * speedMultiplyer;

        switch(gameObject.name)
        {
            case "gearA_clockwise":
                {
                    transform.localRotation = Quaternion.Euler(0, 0, transform.rotation.z - gearAspeed);
                    break;
                }
            case "gearA_anticlockwise":
                {
                    transform.localRotation = Quaternion.Euler(0, 0, transform.rotation.z + gearAspeed);
                    break;
                }
            case "gearB_clockwise":
                {
                    transform.localRotation = Quaternion.Euler(0, 0, transform.rotation.z - gearBspeed);
                    break;
                }
            case "gearB_anticlockwise":
                {
                    transform.localRotation = Quaternion.Euler(0, 0, transform.rotation.z + gearBspeed);
                    break;
                }
            case "loadingSpin":
                {
                    GetComponent<RectTransform>().Rotate(new Vector3(0, 0, loadingSpinSpeed));
                    break;
                }
        }
        
    }
}
