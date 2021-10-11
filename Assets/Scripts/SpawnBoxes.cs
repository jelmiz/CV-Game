using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{   
    public float spawnTimeMin;
    public float spawnTimeMax;
    public GameObject[] boxes;
    public Transform[] teleport;
    private float time;
    private float timeToSpawn;
    void Start()
    {
    spawnTimeMin = 1f;
    spawnTimeMax = 5f;
    SpawnTime();
    time = spawnTimeMin;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
         //Check if its the right time to spawn the object
        if(time >= timeToSpawn){
            Spawn();
            SpawnTime();
        }
        
    
    }
    private void SpawnTime() {
        
        timeToSpawn = Random.Range(spawnTimeMin,spawnTimeMax);
        
    }
    private void Spawn() {
        time = 0;
    int tele_num = Random.Range(0,1);
    int box_num = Random.Range(0,3);
        Instantiate(boxes[box_num],teleport[tele_num].position, teleport[tele_num].rotation);
    }
}
