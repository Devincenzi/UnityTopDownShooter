using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour{
    public Transform from;
    public Transform to;
    public float rotateSpeed;

    void FixedUpdate(){
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, rotateSpeed);
    }
}