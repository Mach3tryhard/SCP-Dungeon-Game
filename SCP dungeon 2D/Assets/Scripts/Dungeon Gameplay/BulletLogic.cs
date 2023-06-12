using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public int damage=1;
    public GameObject ExplosionPrefab;
    public Player playerScript;
    private GameObject explosion;

    void Start() 
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        lock(this) {
            if(other.gameObject.tag!="Player" && other.gameObject.tag!="Enemy")
            {
                explosion = Instantiate(ExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
            }
            else
            if(other.gameObject.tag=="Player")
            {
                Debug.Log(playerScript);
                playerScript.TakeDamage(damage);
            }
            else
            if(other.gameObject.tag=="Enemy")
            {
                other.gameObject.transform.Find("Head").GetComponent<EnemyScript>().TakeDamage(damage);
                //playerScript.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
   
}
