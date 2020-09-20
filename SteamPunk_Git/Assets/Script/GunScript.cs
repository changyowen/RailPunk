using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("Access GameObject")]
    public ParticleSystem[] GunTypeMuzzleFlash;
    public AudioSource[] GunTypeShootingSound;
    public Animator weaponHolderAnimator;
    public GameObject scopeOverlay;
    public Camera mainCamera;
    public GameObject weaponCamera;
    public GameObject weaponSwitching_Obj;
    public GameObject impactEffect;

    [Header("Weapon Data")]
    public int sniperDamage = 10;
    public float fireRate = 1f;
    public float scopedFOV = 15f;
    float[,] WeaponData = { { 2f, 10f }, { .1f, 1f }, { 15f, 15f } };

    [Header("Internal Script Data")]
    private float normalFOV;
    private bool isScoped = false;
    private bool scopING = false;
    private float nextTimeToFire = 0f;
    public int selectedWeapon = 0;
    AudioSource GunAudioSource;
    ParticleSystem muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        //Switch Weapon Use
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && isScoped == false)
        {
            if (selectedWeapon >= weaponSwitching_Obj.transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && isScoped == false)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = weaponSwitching_Obj.transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

        //Shooting Use
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
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

        if (Input.GetButtonDown("Fire2") && Time.time >= nextTimeToFire && scopING == false && selectedWeapon != 0)
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
        GunAudioSource.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
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

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in weaponSwitching_Obj.transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }

        sniperDamage = (int)WeaponData[0, selectedWeapon];
        fireRate = WeaponData[1, selectedWeapon];
        scopedFOV = WeaponData[2, selectedWeapon];
        GunAudioSource = GunTypeShootingSound[selectedWeapon];
        muzzleFlash = GunTypeMuzzleFlash[selectedWeapon];
    }
}
