using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaSwitch : MonoBehaviour
{
    bool enableSwitch = false;
    public bool switchOn = false;
    public float AutoSwitchOff = 20f;
    private float nextTimeToSwitch = 0f;
    Animator switchAnimator;

    Color RedColor = Color.red;
    Color BlueColor = new Color(0f, 0.188f, 1f, 1f);

    public GameObject TeslaTowerMainBody;
    public GameObject MainSphere, switchSphere;
    public GameObject ElectricSphere;
    public GameObject[] SmallSphere;
    public Light mainLight, switchLight;

    // Start is called before the first frame update
    void Start()
    {
        switchAnimator = GetComponent<Animator>();

        MainSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        switchSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        for(int i = 0; i < 4; i++)
        {
            SmallSphere[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }

        ElectricSphere.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeToSwitch)
        {
            if(switchOn == true)
            {
                TurnSwitchOff();
            }
            
            if(enableSwitch == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    nextTimeToSwitch = Time.time + AutoSwitchOff;
                    switchAnimator.SetBool("SwitchOn", true);
                    StartCoroutine(TurnSwitchOn());
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            enableSwitch = true;
            Debug.Log("Yes");
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enableSwitch = false;
        }
    }

    IEnumerator TurnSwitchOn()
    {
        yield return new WaitForSeconds(.7f);
        switchOn = true;
        ElectricSphere.SetActive(true);

        mainLight.intensity = 7;
        switchLight.intensity = 5;

        if (TeslaTowerMainBody.name.Contains("Tesla_Tower_A"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * 10f);
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * 10f);
            for(int i = 1; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * 10f);
            }
        }
        else if(TeslaTowerMainBody.name.Contains("Tesla_Tower_B"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * 10f);
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * 10f);
            for (int i = 1; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * 10f);
            }
        }
    }

    void TurnSwitchOff()
    {
        switchAnimator.SetBool("SwitchOn", false);
        switchOn = false;
        ElectricSphere.SetActive(false);

        mainLight.intensity = 0;
        switchLight.intensity = 0;

        if (this.gameObject.name.Contains("Tesla_Tower_A"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * .5f);
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * .5f);
            for (int i = 1; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * .5f);
            }
        }
        else if (this.gameObject.name.Contains("Tesla_Tower_B"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * .5f);
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * .5f);
            for (int i = 1; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * .5f);
            }
        }
    }
}
