using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaMaterialScript : MonoBehaviour
{
    Color RedColor = Color.red;
    Color BlueColor = new Color(0f, 0.188f, 1f, 1f);
    Color YellowColor = new Color(1f, 1f, 0f, 1f);
    Color GreenColor = new Color(0f, 1f, 0f, 1f);
    Color OrangeColor = new Color(1f, .55f, 0f, 1f);
    Color PurpleColor = new Color(1f, 0f, 1f, 1f);
    Color DullRed = new Color(.5f, 0f, 0f, 1f);
    Color DullBlue = new Color(0f, .5f, 1f, 1f);
    Color DullYellow = new Color(.68f, .68f, 0f, 1f);
    Color DullGreen = new Color(0f, .5f, 0f, 1f);
    Color DullOrange = new Color(.8f, .4f, 0f, 1f);
    Color DullPurple = new Color(.54f, 0f, .54f, 1f);

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
        else if (this.gameObject.name.Contains("Tesla_Tower_C"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_Color", YellowColor);
            MainSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", YellowColor * 0.5f);

            for (int i = 0; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_Color", YellowColor);
                SmallSphere[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", YellowColor * .5f);
            }

            switchSphere.GetComponent<Renderer>().material.SetColor("_Color", YellowColor);
            switchSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", YellowColor * .5f);

            switchBody.GetComponent<Renderer>().material.SetColor("_Color", YellowColor);
            switchBody.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchBody.GetComponent<Renderer>().material.SetColor("_EmissionColor", YellowColor * 1f);

            electricSphere.GetComponent<ParticleSystem>().startColor = YellowColor;

            lightningBolt.GetComponent<LineRenderer>().SetColors(YellowColor, YellowColor);

            mainLight.color = YellowColor;
            switchLight.color = YellowColor;

            mainTowerIcon.GetComponent<SpriteRenderer>().color = DullYellow;
            switchIcon.GetComponent<SpriteRenderer>().color = DullYellow;
        }
        else if (this.gameObject.name.Contains("Tesla_Tower_D"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_Color", GreenColor);
            MainSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", GreenColor * 0.5f);

            for (int i = 0; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_Color", GreenColor);
                SmallSphere[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", GreenColor * .5f);
            }

            switchSphere.GetComponent<Renderer>().material.SetColor("_Color", GreenColor);
            switchSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", GreenColor * .5f);

            switchBody.GetComponent<Renderer>().material.SetColor("_Color", GreenColor);
            switchBody.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchBody.GetComponent<Renderer>().material.SetColor("_EmissionColor", GreenColor * 1f);

            electricSphere.GetComponent<ParticleSystem>().startColor = GreenColor;

            lightningBolt.GetComponent<LineRenderer>().SetColors(GreenColor, GreenColor);

            mainLight.color = GreenColor;
            switchLight.color = GreenColor;

            mainTowerIcon.GetComponent<SpriteRenderer>().color = DullGreen;
            switchIcon.GetComponent<SpriteRenderer>().color = DullGreen;
        }
        else if (this.gameObject.name.Contains("Tesla_Tower_E"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_Color", OrangeColor);
            MainSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", OrangeColor * 0.5f);

            for (int i = 0; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_Color", OrangeColor);
                SmallSphere[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", OrangeColor * .5f);
            }

            switchSphere.GetComponent<Renderer>().material.SetColor("_Color", OrangeColor);
            switchSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", OrangeColor * .5f);

            switchBody.GetComponent<Renderer>().material.SetColor("_Color", OrangeColor);
            switchBody.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchBody.GetComponent<Renderer>().material.SetColor("_EmissionColor", OrangeColor * 1f);

            electricSphere.GetComponent<ParticleSystem>().startColor = OrangeColor;

            lightningBolt.GetComponent<LineRenderer>().SetColors(OrangeColor, OrangeColor);

            mainLight.color = OrangeColor;
            switchLight.color = OrangeColor;

            mainTowerIcon.GetComponent<SpriteRenderer>().color = DullOrange;
            switchIcon.GetComponent<SpriteRenderer>().color = DullOrange;
        }
        else if (this.gameObject.name.Contains("Tesla_Tower_F"))
        {
            MainSphere.GetComponent<Renderer>().material.SetColor("_Color", PurpleColor);
            MainSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            MainSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", PurpleColor * 0.5f);

            for (int i = 0; i < 4; i++)
            {
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_Color", PurpleColor);
                SmallSphere[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                SmallSphere[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", PurpleColor * .5f);
            }

            switchSphere.GetComponent<Renderer>().material.SetColor("_Color", PurpleColor);
            switchSphere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchSphere.GetComponent<Renderer>().material.SetColor("_EmissionColor", PurpleColor * .5f);

            switchBody.GetComponent<Renderer>().material.SetColor("_Color", PurpleColor);
            switchBody.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            switchBody.GetComponent<Renderer>().material.SetColor("_EmissionColor", PurpleColor * 1f);

            electricSphere.GetComponent<ParticleSystem>().startColor = PurpleColor;

            lightningBolt.GetComponent<LineRenderer>().SetColors(PurpleColor, PurpleColor);

            mainLight.color = PurpleColor;
            switchLight.color = PurpleColor;

            mainTowerIcon.GetComponent<SpriteRenderer>().color = DullPurple;
            switchIcon.GetComponent<SpriteRenderer>().color = DullPurple;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
