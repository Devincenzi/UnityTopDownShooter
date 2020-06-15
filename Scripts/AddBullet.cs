using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullet : MonoBehaviour{
    public GameObject bulletPrefab;
    public Shooting shooting;
    public BulletBoxSelector bulletBoxSelector;

    void Start(){
        shooting = Shooting.instance;
        bulletBoxSelector = BulletBoxSelector.instance;
    }

    void OnCollisionEnter2D(Collision2D collision){
        shooting.bulletPrefabList.Add(bulletPrefab);
        bulletBoxSelector.AddBullet(bulletPrefab);

        //shooting.cooldown.Add(bulletPrefab.GetComponent<Bullet>().cooldown);
        shooting.localCooldown.Add(true);

        List<CooldownBox> cdBox = 
            new List<CooldownBox>(BulletBoxSelector.instance.GetComponentsInChildren<CooldownBox>());
        cdBox[cdBox.Count-1].totalCd = bulletPrefab.GetComponent<Bullet>().cooldown;

        Destroy(gameObject);
    }
}