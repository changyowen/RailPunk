using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaMaterialScript : MonoBehaviour
{
    Color RedColor = Color.red;
    Color BlueColor = new Color(0f, 0.188f, 1f, 1f);
    Color DullRed = new Color(.5f, 0f, 0f, 1f);
    Color DullBlue = new Color(0f, .5f, 1f, 1f);

    public GameObject MainSphere, switchSphere, switchBody;
    public GameObject[] SmallSphere;
    public GameObject electricSphere, lightningBolt;
    public Light mainLight, switchLight;
    public GameObject mainTowerIcon, switchIcon;

    // Start is called before the first frame update
    void Start()
    {
        mainLight.intensity = 0;
        switchLight.intensity = 0;

        if(this.gameObject.name.Contains("Tesla_Tower_A"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_Color", RedColor);
            MainSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * 0.5f);

            for(int i = 0; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_Color", RedColor);
                SmallSphere[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * .5f);
            }

            switchSphere.GetComponent<Renderer>().material.SetColor("_Color", RedColor);
            switchSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * .5f);

            switchBody.GetComponent<Renderer>().material.SetColor("_Color", RedColor);
            switchBody.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchBody.GetComponent<Renderer>().material.SetColor("_EmissionColor", RedColor * 1f);

            electricSphere.GetComponent<ParticleSystem>().startColor = RedColor;

            lightningBolt.GetComponent<LineRenderer>().SetColors(RedColor, RedColor);

            mainLight.color = RedColor;
            switchLight.color = RedColor;

            mainTowerIcon.GetComponent<SpriteRenderer>().color = DullRed;
            switchIcon.GetComponent<SpriteRenderer>().color = DullRed;

        }
        else if(this.gameObject.name.Contains("Tesla_Tower_B"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_Color", BlueColor);
            MainSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * 3f);

            for (int i = 0; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_Color", BlueColor);
                SmallSphere[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * 3f);
            }

            switchSphere.GetComponent<Renderer>().material.SetColor("_Color", BlueColor);
            switchSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", BlueColor * 3f);

            switchBody.GetComponent<Renderer>().material.SetColor("_Color", new Color(0f, 0.922f, 1f, 1f));
            switchBody.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchBody.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0.345f, 0.749f, 1f) * 2f);

            electricSphere.GetComponent<ParticleSystem>().startColor = BlueColor;

            lightningBolt.GetComponent<LineRenderer>().SetColors(BlueColor, BlueColor);

            mainLight.color = new Color(0f, 0.639f, 1f, 1f);
            switchLight.color = new Color(0f, 0.639f, 1f, 1f);

            mainTowerIcon.GetComponent<SpriteRenderer>().color = DullBlue;
            switchIcon.GetComponent<SpriteRenderer>().color = DullBlue;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
