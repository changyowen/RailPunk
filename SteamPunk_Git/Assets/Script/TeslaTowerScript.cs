using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class TeslaTowerScript : MonoBehaviour
{
    private Transform target;
    private bool EnableElectricSphere = false;

    [Header("Attribute")]
    public float range = 800f;
    public float attack = 5f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject lightningBolt, lightningEnd;
    Transform firePoint;
    public GameObject SwitchPosition;
    TeslaSwitch teslaSwitch;
    public AudioClip ElectricZap;

    [Header("Unity Setup Field")]
    public string enemyTag = "Enemy";

    AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        teslaSwitch = SwitchPosition.GetComponent<TeslaSwitch>();
        audioSrc = GetComponent<AudioSource>();

        firePoint = transform;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        if(teslaSwitch.switchOn == true)
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }
       
        fireCountdown -= Time.deltaTime;
    }

    public void Shoot()
    {
        lightningEnd.transform.position = target.transform.position;
        lightningBolt.GetComponent<LightningBoltScript>().Trigger();
        audioSrc.PlayOneShot(ElectricZap);

        EnemyHealth enemyhealth = target.GetComponent<EnemyHealth>();
        if (enemyhealth != null)
        {
            enemyhealth.EnemyHp -= attack;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
