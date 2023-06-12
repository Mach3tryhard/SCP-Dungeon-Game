using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 3f;
    public float ShootDelay = 0.05f;

    private float lastTime, currentTime;

    void Start() 
    {
        lastTime = Time.time - ShootDelay;
        currentTime = Time.time;
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if(Input.GetButton("Fire1") && currentTime > lastTime + ShootDelay)
        {
            lastTime = currentTime;
            Shoot();
        }
    }

    void Shoot()
    {
        float caca=Random.Range(-5.0f, 5.0f);
        firePoint.eulerAngles += new Vector3(0f,0f,caca);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        firePoint.eulerAngles -= new Vector3(0f,0f,caca);
    }
}
