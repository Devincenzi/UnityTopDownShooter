using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRobots : MainIA{
    protected AutoShooter shoot;

    #region playerPursuit
    [Header("Player Pursuit")]
    public Transform target;
    public float lookRadius;
    public float stopDistance;
    protected float distance;
    protected Vector2 direction;
    protected RaycastHit2D raycast;
    protected LayerMask mask;
    #endregion

    protected override void Start(){
        shoot = GetComponent<AutoShooter>();
        stats = GetComponent<Status>();
        target = PlayerManager.instance.player.transform;
        mask = LayerMask.GetMask("Collider");
    }

    // Update is called once per frame
    protected override void Update(){
        distance = Vector3.Distance(transform.position, target.position);
        direction = transform.position - target.position;

        if(distance <= lookRadius){
            Debug.DrawRay(transform.position, -direction, Color.green);
            raycast = Physics2D.Raycast(transform.position, -direction, lookRadius, mask.value);

            if(!raycast){
                behaviour = DoWhat.Pursuit;
            }
        }
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

            case DoWhat.Pursuit :
                //persegue o jogador
                lastBehaviour = DoWhat.Pursuit;

                if(distance <= lookRadius && !raycast)
                    shoot.canShoot = true;

                if(distance > stopDistance){
                    transform.position = 
                        Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * stats.stats[2].value);
                }

                //Vector2 direction = transform.position - target.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
                Quaternion newRotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));
                transform.rotation = 
                    Quaternion.Slerp(transform.rotation, newRotation, stats.stats[3].value);

            
                if(distance >= lookRadius || raycast){
                    shoot.canShoot = false;
                    behaviour = DoWhat.SetRotate;
                }
            break;

            case DoWhat.Wait :
                //transição de estados
                if(lastBehaviour == DoWhat.SetRotate){
                    StartCoroutine(WaitChange(DoWhat.Rotate, 1f, DoWhat.Walk));
                }
                lastBehaviour = DoWhat.Wait;
            break;

            default:

            break;
        }
    }
    
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}