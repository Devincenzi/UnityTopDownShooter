using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitDamage : Modifier{
    void Start(){
        ApplyModifier();
    }

    void ApplyModifier(){
        unitHost.SetStat(typeStat, value);
        Destroy(gameObject);
    }
}