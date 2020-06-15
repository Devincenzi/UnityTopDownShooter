using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour{
    public List<GameObject> toActive;
    public List<GameObject> squares;
    public int soma;
    public bool condition;

    void ChangeTrueFalse(List<GameObject> toChangeList){
        foreach(GameObject toChange in toChangeList){
            if(toChange.activeSelf)
                toChange.SetActive(false);
            else
                toChange.SetActive(true);
        }
    }

    public void CheckCondition(){
        if(soma == squares.Count)
            ChangeTrueFalse(toActive);
    }
}
