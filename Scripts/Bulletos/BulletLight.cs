using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLight : Bullet{
    public Rigidbody2D rb;
    public float distanceMax;
    public float speed;
    float newDistance;
    Transform initialPos;
    Vector3 mousePos;
    
    void Start(){
        initialPos = PlayerManager.instance.player.transform;
        mousePos = PlayerManager.instance.camera.ScreenToWorldPoint(Input.mousePosition);
        newDistance = Vector2.Distance(initialPos.position, mousePos)/1.1f;

        if(newDistance < distanceMax)
            distanceMax = newDistance;
    }

    // Update is called once per frame
    protected override void Update(){
        
    }

    void FixedUpdate(){
        float distance = Vector2.Distance(initialPos.position, transform.position);

        if(distance >= distanceMax){
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
        }

        timeAlive -= Time.deltaTime;
        if(timeAlive <= 0){
            transform.position = Vector2.MoveTowards(transform.position, 
                PlayerManager.instance.player.transform.position, Time.deltaTime * speed);
            speed += Time.deltaTime/2;
        }
    }
    
    protected override void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            
            Destroy(gameObject);
        }
    }
}