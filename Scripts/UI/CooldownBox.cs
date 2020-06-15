using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBox : MonoBehaviour{
    public Image cdBox;
    public float totalCd;
    public float cd;
    // Update is called once per frame
    void Update(){
        if(cd > 0){
            cd -= Time.deltaTime;
            cdBox.fillAmount = ((cd * 100 / totalCd) / 100);
        }
    }
}
