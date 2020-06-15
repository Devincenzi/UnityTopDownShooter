using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTimeDamage : Modifier{
    public float time = 1f;

    // Update is called once per frame
    void Update(){
        timeAlive -= Time.deltaTime;
        time -= Time.deltaTime;
        if(time <= 0){
            unitHost.SetStat(typeStat, value);
            time = 1f;
        }

        if(timeAlive <= 0)
            Destroy(gameObject);
    }
}
