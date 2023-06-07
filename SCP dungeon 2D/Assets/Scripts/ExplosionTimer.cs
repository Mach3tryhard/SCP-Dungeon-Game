using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    
    void Start()
    {
        Invoke("Destroy",1.0f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

}
