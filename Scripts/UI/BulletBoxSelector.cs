using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBoxSelector : MonoBehaviour{
    public List<GameObject> bulletList;
    public GameObject box;
    public Transform selector;
    public Shooting shooting;

    #region Singleton
    
    public static BulletBoxSelector instance;
    void Awake(){
        instance = this;
    }
    
    #endregion

    void Start(){
        shooting = Shooting.instance;
        if(shooting.bulletPrefabList.Count > 0){
            selector.gameObject.SetActive(true);
            foreach(GameObject bulletToAdd in shooting.bulletPrefabList){
                AddBullet(bulletToAdd);
            }
        }
    }

    void Update(){
        if(shooting.bulletPrefabList.Count > 0)
            selector.position = bulletList[shooting.index].transform.position;
    }

    public void AddBullet(GameObject bulletToAdd){
        selector.gameObject.SetActive(true);
        GameObject newBox = Instantiate(box, 
            new Vector3(-66 + 30 * bulletList.Count-1, -5, 0), 
            Quaternion.identity);
        newBox.transform.SetParent(transform, false);

        List<Image> newBoxInside = new List<Image>(newBox.GetComponentsInChildren<Image>());
        newBoxInside[1].sprite = bulletToAdd.GetComponent<SpriteRenderer>().sprite;

        bulletList.Add(newBox);
    }
}