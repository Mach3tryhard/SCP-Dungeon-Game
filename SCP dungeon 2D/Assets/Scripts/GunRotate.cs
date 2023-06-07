using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public float moveSpeed = 4f;

    public Rigidbody2D rb;
    public Camera cam;
    public GameObject player;

    Vector2 movement;
    Vector2 mousePos;

    private Vector3 ChangeScaleminus = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 ChangeScaleplus = new Vector3(-1.0f, -1.0f, 1.0f);

    private Vector3 ChangeScaleplusFORx = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 ChangeScaleminusFORx = new Vector3(-1.0f, 1.0f, 1.0f);

    void Start()  
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {   
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        if(angle>=90 || angle<-90)
        {
            player.transform.localScale = ChangeScaleminusFORx;
            rb.transform.localScale = ChangeScaleplus;
        }
        else
        {
            player.transform.localScale = ChangeScaleplusFORx;
            rb.transform.localScale = ChangeScaleminus;
        }
        rb.rotation = angle;
    }
}
