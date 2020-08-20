using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public Animator weaponHolderAnimator;
    public GameObject scopeOverlay;
    public Camera mainCamera;
    public GameObject weaponCamera;

    public float scopedFOV = 15f;
    private float normalFOV;
    private bool isScoped = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            weaponHolderAnimator.SetBool("Scoped", isScoped);

            if(isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnscoped();
            }
        }
    }

    void OnUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    void Shoot()
    {
        muzzleFlash.Play();
    }
}
