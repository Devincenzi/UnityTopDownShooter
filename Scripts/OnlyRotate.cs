using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyRotate : MonoBehaviour{
    public Transform from;
    public Transform to;
    public Status stats;

    void Start(){
        stats = GetComponent<Status>();
    }

    void FixedUpdate(){
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, stats.stats[3].value);
    }
}