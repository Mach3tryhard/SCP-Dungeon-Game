using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 3f;
    public float ShootDelay = 1f;
    private float lastTime, currentTime;

    public Rigidbody2D rb;
    public GameObject player;
    Vector2 mousePos;
    private Vector3 ChangeScaleminus = new Vector3(1.0f, 0.0f, 0.0f);
    private Vector3 ChangeScaleplus = new Vector3(-1.0f, 0.0f, 0.0f);

    public int maxHealth = 10;
    public int currentHealth;

    void Start() 
    {
        currentHealth = maxHealth;
        lastTime = Time.time - ShootDelay;
        currentTime = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        if(currentHealth<=0)
        {
            Die();
        }
        mousePos = player.transform.position;
    }

    void FixedUpdate()
    {
        //Calcule pt a afla distanta
        float a,b,distanta;
        a=System.Math.Abs(player.transform.position.x-gameObject.transform.position.x);
        b=System.Math.Abs(player.transform.position.y-gameObject.transform.position.y);
        distanta=Mathf.Sqrt(a*a+b*b);
        if(distanta<=5)
        {
            AimAndShoot();
        }
    }

    void AimAndShoot()
    {
        currentTime += Time.deltaTime;
        if(/*Input.GetButton("Fire1") &&*/ currentTime > lastTime + ShootDelay)
        {
            lastTime = currentTime;
            Shoot();
        }

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 45f;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void Die()
    {
        gameObject.transform.parent.GetComponent<EnemyBehaviour>().Kill();
    }
}
