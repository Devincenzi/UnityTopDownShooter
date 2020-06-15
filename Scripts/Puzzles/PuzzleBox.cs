using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBox : MonoBehaviour{
    public List<GameObject> puzzle;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.layer != 9 && collider.gameObject.layer != 10){
            ChangeTrueFalse(puzzle);
            Debug.Log(collider.name + " entrou");
            //puzzle.condition = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        ChangeTrueFalse(puzzle);
        Debug.Log(collider.name + " saiu");
    }

    void ChangeTrueFalse(GameObject toChange){
        if(toChange.activeSelf)
            toChange.SetActive(false);
        else
            toChange.SetActive(true);
    }
    
    void ChangeTrueFalse(List<GameObject> toChangeList){
        foreach(GameObject toChange in toChangeList){
            if(toChange.activeSelf)
                toChange.SetActive(false);
            else
                toChange.SetActive(true);
        }
    }
}
