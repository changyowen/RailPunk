using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public AudioSource SniperAudioSource;
    public Animator weaponHolderAnimator;
    public GameObject scopeOverlay;
    public Camera mainCamera;
    public GameObject weaponCamera;

    public int sniperDamage = 10;
    public float fireRate = 1f;
    public float scopedFOV = 15f;
    private float normalFOV;
    private bool isScoped = false;
    private bool scopING = false;
    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            
            nextTimeToFire = Time.time + fireRate;
            Shoot();
           
            if (isScoped == true)
            {
                isScoped = false;
                weaponHolderAnimator.SetBool("Scoped", false);
                StartCoroutine(OnUnscoped());
            }
        }

        if (Input.GetButtonDown("Fire2") && Time.time >= nextTimeToFire && scopING == false)
        {
            isScoped = !isScoped;
            weaponHolderAnimator.SetBool("Scoped", isScoped);

            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                StartCoroutine(OnUnscoped());
            }
        }
    }

    IEnumerator OnUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        mainCamera.fieldOfView = normalFOV;

        scopING = true;
        yield return new WaitForSeconds(.15f);
        scopING = false;

    }

    IEnumerator OnScoped()
    {
        scopING = true;
        yield return new WaitForSeconds(.15f);
        scopING = false;
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    void Shoot()
    {
        SniperAudioSource.Play();
        muzzleFlash.Play();
        RaycastHit hit; 
        if(Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward,out hit))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target != null)
            {
                if (target.tag == "Enemy")
                {
                    Debug.Log("hit");
                    target.takeDamage(sniperDamage);
                }
                else
                {
                    Debug.Log("miss");
                }
            }
        }

    }
}
