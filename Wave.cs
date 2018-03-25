using UnityEngine;
using System.Collections;
//no mono behaviour needed because we only store information-variables
[System.Serializable]
public class Wave {
    //giving the enemy prefab array stats .
    public GameObject enemy;
    public int count;
    public float rate;
}
