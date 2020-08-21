using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMaterialScript : MonoBehaviour
{
    Renderer meshRenderer;
    public Material instanceMaterial;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<Renderer>();
        instanceMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        float intensity = 100.0f;
        instanceMaterial.EnableKeyword("_EMISSION");
        instanceMaterial.SetColor("_Color", new Color(1f, 0f, 0f, 1.0f));
        //instanceMaterial.SetColor("_EmissionColor", Color.blue * 1f);



        instanceMaterial.SetColor("_EmissionColor", new Color(1.0f, 0f, 0f, 1.0f) * intensity);
    }
}
