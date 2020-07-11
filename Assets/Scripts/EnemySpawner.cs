using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Wave_1[] waves1;
    public Transform START1, START2;
    public float waveRate = 0.2f;
    private Coroutine coroutine;
    public static bool control = true;
    void Start()
    {
        coroutine = StartCoroutine(SpawnEnemy());
        //GameManager.Instance.Win();
        //GameManager.Instance.Failed();
    }
    public void Stop()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator SpawnEnemy()
    {
        for (int j = 0; j < waves.Length; j++)
        {
            for (int i = 0; i < waves[j].count; i++)
            {
                GameObject.Instantiate(waves[j].enemyPrefab, START1.position, Quaternion.identity);
                CountEnemyAlive++;
                if (START2 != null)
                {
                    GameObject.Instantiate(waves1[j].enemyPrefab, START2.position, Quaternion.identity);
                    //enemy.firstPath = false;
                    //Debug.Log("firstPath:" + enemy.firstPath);
                    CountEnemyAlive++;
                }
                if (i != waves[j].count - 1)
                    yield return new WaitForSeconds(waves[j].rate);
                while (control == false)
                {
                    yield return new WaitForSeconds(waves[j].rate);
                }
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
        while (CountEnemyAlive > 0)
        {
            yield return 0;
        }
        GameManager.Instance.Win();
    }

}
