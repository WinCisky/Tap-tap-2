using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnManager : MonoBehaviour
{
    //time between spawns
    private float spawn_rate;
    //last spawn time
    private float last_spawn;
    //start point of function
    private float funtion_offset = 10000;

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
            //change spawn time
            if(GameManager.GM.ActiveButtons() < 5)
            {
                //decrease spawn time
                spawn_rate -= 1 / Mathf.Log(funtion_offset);
                funtion_offset *= 20;
            }
            else
            {
                //increase spawn time
                spawn_rate += 1 / Mathf.Log(Mathf.Pow(funtion_offset, 2));
                if (funtion_offset > 10000)
                    funtion_offset /= 2;
                //point penality
                ScoreManager.SM.RemovePoint(5);
            }
            Debug.Log(spawn_rate);
        }


    }
}
