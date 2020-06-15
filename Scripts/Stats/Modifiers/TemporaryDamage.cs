using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryDamage : Modifier{
    void Start(){
        ApplyModifier();
    }

    void FixedUpdate(){
        timeAlive -= Time.deltaTime;
        if(timeAlive <= 0){
            unitHost.SetStat(typeStat, -value);
            Destroy(gameObject);
        }
    }

    void ApplyModifier(){
        unitHost.SetStat(typeStat, value);
    }
}