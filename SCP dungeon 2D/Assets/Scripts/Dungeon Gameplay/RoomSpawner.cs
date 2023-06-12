using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int RoomRestriction;
    private RoomTemplates templates;
    private GameObject ClosedRoom;
    private int random;
    [SerializeField]private bool spawned= false;

    void Start() 
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        ClosedRoom = templates.closedRoom;
        //Invoke("Spawn", 0.5f);
    }

    void Update ()
    {
        if (templates.DONE==true && spawned==false)
            Invoke("Spawn", 0.5f);
        if (spawned == true)
            Destroy(gameObject);
    }

    void Spawn() 
    {
        if (spawned == true)
            return;
        int cr = RoomRestriction;
        for (int i = 1; i < 81; i*= 3)
            if ((cr / i) % 3 != 0)
                cr -= i;
        if (cr == 0)
            return;
        spawned = true;
        GameObject[] array = templates.complicated[RoomRestriction];
        random = Random.Range(0, Random.Range(1, array.Length + 1));
        //random = Random.Range(0,array.Length);
        GameObject newfab = Instantiate(array[random], transform.position, array[random].transform.rotation);
        newfab.transform.Find("Destroyer").gameObject.GetComponent<Destroyer>().spawnval = RoomRestriction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint"))
        lock(templates){
            if(other.GetComponent<Destroyer>() != null)
            {
                spawned = true;
                //Debug.Log("CACA");
            }    
            if(spawned == false && other.GetComponent<RoomSpawner>().spawned==false)
            {
                //Debug.Log(""+other.GetComponent<RoomSpawner>().RoomRestriction+"+"+RoomRestriction);
                other.GetComponent<RoomSpawner>().RoomRestriction += RoomRestriction;
                spawned = true;
            }
        }
    }
}

