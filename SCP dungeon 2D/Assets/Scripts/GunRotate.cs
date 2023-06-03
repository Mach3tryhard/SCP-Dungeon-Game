using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public float moveSpeed = 4f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private Vector3 ChangeScaleminus = new Vector3(1.0f, -1.0f, 1.0f);
    private Vector3 ChangeScaleplus = new Vector3(1.0f, 1.0f, 1.0f);

    void Start()  
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {   
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); 

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        if(angle>=90 || angle<-90)
            rb.transform.localScale = ChangeScaleminus;
        else
            rb.transform.localScale = ChangeScaleplus;
        rb.rotation = angle;
    }
}
