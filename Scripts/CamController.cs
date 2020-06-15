using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour{
    
    GameObject player;

    void Start(){
        player = PlayerManager.instance.player;
    }

    void Update(){
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
