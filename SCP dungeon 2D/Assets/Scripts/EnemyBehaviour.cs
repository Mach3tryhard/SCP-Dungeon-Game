using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public void  Kill()
    {
        Destroy(gameObject);
    }
}
