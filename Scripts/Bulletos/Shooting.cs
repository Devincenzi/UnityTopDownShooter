using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour{
    public List<Transform> firePointList;
    public List<GameObject> bulletPrefabList;
    //public List<float> cooldown;
    public List<bool> localCooldown;
    public int index = 0;
    //float bulletForce = 10f;
 
    #region Singleton
    public static Shooting instance;
    void Awake(){
        instance = this;
    }
    #endregion

    // Update is called once per frame
    protected virtual void Update(){
        if(Input.GetButtonDown("Fire1")){
            if(localCooldown[index])
                Shoot();
            else
                Debug.Log("Você ainda não pode usar isto");
        }

        if(Input.GetButtonDown("MenuLeft")){
            if(index == 0){
                index = bulletPrefabList.Count-1;
            }else{
                index--;
            }
        }
        if(Input.GetButtonDown("MenuRight")){
            if(index == bulletPrefabList.Count - 1){
                index = 0;
            }else{
                index++;
            }    
        }
    }

    protected virtual void Shoot(){
        foreach (Transform firePoint in firePointList){
            //StartCoroutine(WaitShoot(index, cooldown[index]));
            List<CooldownBox> cdBox = new List<CooldownBox>(BulletBoxSelector.instance.GetComponentsInChildren<CooldownBox>());
            
            GameObject bullet = Instantiate(bulletPrefabList[index], firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            
            StartCoroutine(WaitShoot(index, bulletScript.cooldown));
            cdBox[index].cd = bulletScript.cooldown;
            
            rb.AddForce(firePoint.up * bulletScript.bulletForce, ForceMode2D.Impulse);
            
        }
    }

    IEnumerator WaitShoot(int index, float cooldown){
        localCooldown[index] = false;
        yield return new WaitForSeconds(cooldown);
        localCooldown[index] = true;
    }
}