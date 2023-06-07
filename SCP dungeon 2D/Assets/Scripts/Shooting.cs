using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 3f;

    void FixedUpdate()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
            StartCoroutine(waiter());
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
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(1);
    }

}
