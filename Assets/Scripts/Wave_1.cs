using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//保存每一波敌人生成所需要的属性
[System.Serializable]
public class Wave_1  {
    public Enemy_1 enemyPrefab;
    public int count;
    public float rate;
}
