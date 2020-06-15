using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : Shooting{
    public float shootFrequency = 1.5f;
    public float shootCooldown = 0;
    public bool canShoot;

    // Update is called once per frame
    protected override void Update(){
        if(shootCooldown <= 0f && canShoot){
            Shoot();
            shootCooldown = shootFrequency;
        }

        shootCooldown -= Time.deltaTime;
    }
}
