using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private RoomTemplates templates;
    public int spawnval = -1;

    private void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="SpawnPoint")
        {
            lock(templates) {
                Destroy(other);
            }
        }
    }
}
