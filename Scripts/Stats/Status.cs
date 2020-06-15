using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour{
    public List<Stat> stats;

    public Stat this[StatusEnum s]{
        get{return stats[(int)s];}
    }
}
