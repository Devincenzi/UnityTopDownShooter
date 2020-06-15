using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour{
    public Status status;
    public Image healthBar;

    void Awake(){
        status = GetComponentInChildren<Status>();
    }

    public float GetStat(StatusEnum stat){
        return status.stats[(int)stat].value;
    }

    public void SetStat(StatusEnum stat, float value){
        if (stat == StatusEnum.hp){
            status[stat].value = ClampStat(StatusEnum.maxHp, status[stat].value + value);
            SetHealthBar();
            if(GetStat(StatusEnum.hp) <= 0)
                Destroy(gameObject);
        }else{
            status[stat].value = ClampStat(stat, status[stat].value + value);
        }
    }

    float ClampStat(StatusEnum type, float value){
        return Mathf.Clamp(value, 0, status[type].baseValue);
    }

    void SetHealthBar(){
    float maxHp = GetStat(StatusEnum.maxHp);
        float fillValue = (status[StatusEnum.hp].value * 100 / maxHp) / 100;
        //Debug.Log(fillValue);
        healthBar.fillAmount = fillValue;
        if(transform.name != "Hero"){
            if(fillValue>=0.7f)
                healthBar.color = Color.green;
            else if(fillValue>=0.3f)
                healthBar.color = Color.yellow;
            else
                healthBar.color = Color.red;
        }
    }
}