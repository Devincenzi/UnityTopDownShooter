using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public GameObject hitEffect;
    public List<GameObject> modifiersObj;
    public float bulletForce;
    public float cooldown;
    public float timeAlive = 4f;

    protected virtual void Update(){
        timeAlive -= Time.deltaTime;
        if(timeAlive <= 0){
            Destroy(gameObject);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.transform.name);
        Unit doDamage = collision.transform.GetComponent<Unit>();
        if(doDamage != null){
            foreach(GameObject modObj in modifiersObj){
                GameObject newModifierObj = Instantiate(modObj, collision.gameObject.transform);
                Modifier newMod = newModifierObj.GetComponent<Modifier>();
                newMod.unitHost = doDamage;
                //Debug.Log(collision.transform.name + " sofreu " + bulletEffect.damage + " em " + statsToDamage);
            }
        }

        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }
}