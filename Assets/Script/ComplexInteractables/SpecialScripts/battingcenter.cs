using UnityEngine;
using System.Collections;
using Valve.VR;
using UnityEngine.UI;

public class battingcenter : MonoBehaviour
{

    [Header("Simple Gun Stuff")]
    public Transform projectileExitPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 600;
    public float multishotDelay = 0.2f;
    private int count;
    public Text point;
    public bool isThrow;

    [Header("Extra Gun Stuff")]
    public AudioSource gunAudioSource;
    public AudioSource startAudioSource;
    public AudioSource endAudioSource;



    public bool autoFire;
    protected float restTimer = 0;

    public void Awake()
    {
        autoFire = false;
        count = 0;
    }

    public void Update()
    {
        if (autoFire)
        {
            if (count >= 8)
            {
                Swicher();
            }

            if (restTimer > multishotDelay)
            {
                restTimer = 0;
                ShootBullet();
                gunAudioSource.Play();
                count += 1;
            }
            else
            {
                restTimer += Time.deltaTime;
            }
        }
    }

    public void Swicher()
    {
        if (isThrow)
        {
            isThrow = false;
            autoFire = false;
            endAudioSource.Play();
        }
        else
        {
            point.text = "0";
            startAudioSource.Play();
            count = 0;
            isThrow = true;
            autoFire = true;
        }
    }


    protected void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = projectileExitPoint.position;
        bullet.transform.rotation = projectileExitPoint.rotation;
        
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.forward * bulletSpeed);
    }
    
}
