using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGround : MonoBehaviour{
    public List<GameObject> modifiersObj;
    float canTriggerAgain;

    void Update(){
        if(canTriggerAgain > 0)
            canTriggerAgain -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider){
        Unit doDamage = collider.transform.GetComponent<Unit>();
        if(doDamage != null){
            foreach(GameObject modObj in modifiersObj){
                if(canTriggerAgain <= 0){
                    GameObject newModifierObj = Instantiate(modObj, collider.gameObject.transform);
                    Modifier newMod = newModifierObj.GetComponent<Modifier>();
                    newMod.unitHost = doDamage;
                    canTriggerAgain = newMod.timeAlive;
                        //canTriggerAgain = true;
                }
                //Debug.Log(collision.transform.name + " sofreu " + bulletEffect.damage + " em " + statsToDamage);
            }
        }
    }
}
