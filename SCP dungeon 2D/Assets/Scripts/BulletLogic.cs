using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    private GameObject explosion;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag!="Player")
        {
            explosion = Instantiate(ExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
   
}
