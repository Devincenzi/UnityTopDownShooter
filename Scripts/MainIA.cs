using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoWhat{
    SetNextPoint,
    SetRotate,
    Wait,
    Walk,
    Rotate,
    Pursuit, 
    Attack 
}

public class MainIA : MonoBehaviour{
    public bool rotaCircular;
    public List<Transform> pointsToWalk;

    [HideInInspector]
    public int sentido;
    protected Transform next;
    protected DoWhat behaviour;
    protected DoWhat lastBehaviour;
    protected int index;
    protected Quaternion angleRotation;
    protected Status stats;

    protected virtual void Start(){
        stats = GetComponent<Status>();
    }

    // Update is called once per frame
    protected virtual void Update(){

    }

    protected IEnumerator WaitChange(DoWhat enterFirst, float wait, DoWhat enterEnd){
        behaviour = enterFirst;
        yield return new WaitForSeconds(wait);
        behaviour = enterEnd;
    }

    public Transform SetPoint(List<Transform> currentList, int index){     
        if(rotaCircular && index == currentList.Count -1){
            index = 0;
        }else{
            if(index == 0 && sentido == -1){
                sentido = 1;
                return currentList[index];
            }            
            if(index == currentList.Count - 1)
                sentido = -1;
            if(index == 0)
                sentido = 1;
            index += sentido;        
        }

        return currentList[index];
    }

    public Quaternion RotateRobot(Transform next){
        Vector2 direction = transform.position - next.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;

        return Quaternion.AngleAxis(angle, new Vector3(0,0,1));
    }
}