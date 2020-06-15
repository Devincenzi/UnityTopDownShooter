using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyWalk : MainIA{
    protected override void Start(){
        stats = GetComponent<Status>();    
    }

    // Update is called once per frame
    protected override void Update(){
        switch (behaviour){
            //define próximo ponto da lista
            case DoWhat.SetNextPoint :
                for (int i = 0; i < pointsToWalk.Count; i++){
                    if(pointsToWalk[i] == next)
                        index = i;
                }

                next = SetPoint(pointsToWalk, index);
                lastBehaviour = DoWhat.SetNextPoint;
                behaviour = DoWhat.SetRotate;
            break;

            case DoWhat.SetRotate :
                //define o quanto tem que girar pra ficar de cara pro próximo ponto
                angleRotation = RotateRobot(next);
                lastBehaviour = DoWhat.SetRotate;
                behaviour = DoWhat.Wait;
            break;

            case DoWhat.Rotate :
                //gira até o próximo ponto
                lastBehaviour = DoWhat.Rotate;
                transform.rotation = 
                    Quaternion.Slerp(transform.rotation, angleRotation, stats.stats[3].value);
            break;

            case DoWhat.Walk :
                //caminha até o próximo ponto
                lastBehaviour = DoWhat.Walk;
                transform.position = 
                    Vector2.MoveTowards(transform.position, next.position, Time.deltaTime * stats.stats[2].value);
                if(transform.position == next.position)
                    behaviour = DoWhat.SetNextPoint;
            break;

            case DoWhat.Wait :
                //transição de estados
                if(lastBehaviour == DoWhat.SetRotate){
                    StartCoroutine(WaitChange(DoWhat.Rotate, 0.2f, DoWhat.Walk));
                }
                lastBehaviour = DoWhat.Wait;
            break;

            default:

            break;
        }
    }
}
