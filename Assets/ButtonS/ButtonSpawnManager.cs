using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnManager : MonoBehaviour
{
    //time between spawns
    private float spawn_rate;
    //last spawn time
    private float last_spawn;

    private void Start()
    {
        spawn_rate = 1;
        //wait 3s before first spawn
        last_spawn = Time.time + spawn_rate;
    }


    //keeps checking if a button can be created
    private void FixedUpdate()
    {
        if(Time.time > (last_spawn + spawn_rate))
        {
            //spawn
            GameManager.GM.SpawnRandom();
            //reset time
            last_spawn = Time.time;
        }
    }
}
