using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemplates templates;
    private GameObject ClosedRoom;
    private int random;
    [SerializeField]private bool spawned= false;

    void Start() 
    {
        ClosedRoom = Resources.Load("ClosedRoom") as GameObject;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn() 
    {
        if(spawned == false)
        {
            if(openingDirection==1)
            {
                random = Random.Range(0 , templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[random],transform.position , templates.bottomRooms[random].transform.rotation);
            }
            if(openingDirection==2)
            {
                random = Random.Range(0 , templates.topRooms.Length);
                Instantiate(templates.topRooms[random],transform.position , templates.topRooms[random].transform.rotation);
            }
            if(openingDirection==3)
            {
                random = Random.Range(0 , templates.leftRooms.Length);
                Instantiate(templates.leftRooms[random],transform.position , templates.leftRooms[random].transform.rotation);
            }
            if(openingDirection==4)
            {
                random = Random.Range(0 , templates.rightRooms.Length);
                Instantiate(templates.rightRooms[random],transform.position , templates.rightRooms[random].transform.rotation);
            }
            spawned=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned==false)
            {
                Instantiate(ClosedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned=true;
        }
    }
}

