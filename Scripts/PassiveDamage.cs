using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDamage : MonoBehaviour{
    public List<GameObject> modifiersObj;
    float canTriggerAgain;

    void OnTriggerEnter2D(Collider2D collider){
        Unit doDamage = collider.transform.GetComponent<Unit>();
        if(doDamage != null){
            foreach(GameObject modObj in modifiersObj){
                GameObject newModifierObj = Instantiate(modObj, collider.gameObject.transform);
                Modifier newMod = newModifierObj.GetComponent<Modifier>();
                newMod.unitHost = doDamage;
                 //Debug.Log(collision.transform.name + " sofreu " + bulletEffect.damage + " em " + statsToDamage);
            }
        }
    }
}