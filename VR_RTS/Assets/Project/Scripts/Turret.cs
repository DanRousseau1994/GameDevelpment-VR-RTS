using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    private Transform _target;

    [Header("Attributes")] public float Range = 15f;
    public float FireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("Unity Setup Fields")] public string EnemyTag = "Enemy";

    public Transform PartToRotate;
    public float TurnSpeed = 10f;

    public GameObject BulletPrefab;
    public Transform FirePoint;

    public AudioSource audio;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
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

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    void Update()
    {
        if (_target == null)
            return;

        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / FireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        audio.Play();
        GameObject bulletGo = (GameObject) Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(_target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}