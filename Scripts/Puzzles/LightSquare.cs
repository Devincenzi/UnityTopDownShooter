using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSquare : MonoBehaviour{
    public Animator animator;
    public List<GameObject> nearbySquares;
    public GameObject puzzleReference;
    protected Puzzle puzzle;

    [Header("1 = Ligado, -1 = Desligado")]
    public int ligado;

    void Start(){
        puzzle = puzzleReference.GetComponent<Puzzle>();
        if(ligado == -1){
            animator.SetBool("Ligado", false);
        }else if(ligado == 1){
            puzzle.soma += ligado;
            animator.SetBool("Ligado", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.layer == 0){
            ChangeTrueFalse(nearbySquares);
            ChangeTrueFalse(transform.gameObject);
            puzzle.CheckCondition();
            //puzzle.condition = true;
        }
    }
    void ChangeTrueFalse(GameObject toChange){
        LightSquare square = toChange.GetComponent<LightSquare>();
        if(square.ligado == 1){
            square.animator.SetBool("Ligado", false);     
            square.ligado = -1;
        }else if (square.ligado == -1){
            square.animator.SetBool("Ligado", true);
            square.ligado = 1;
        }
        puzzle.soma += square.ligado;
    }

    void ChangeTrueFalse(List<GameObject> toChangeList){
        foreach(GameObject toChange in toChangeList){
            LightSquare square = toChange.GetComponent<LightSquare>();
            if(square.ligado == 1){
                square.animator.SetBool("Ligado", false);
                square.ligado = -1;
            }else if(square.ligado == -1){
                square.animator.SetBool("Ligado", true);
                square.ligado = 1;
            }
            puzzle.soma += square.ligado;
        }
    }
}
