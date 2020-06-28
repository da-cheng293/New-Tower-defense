using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform START1, START2;
    public float waveRate = 0.2f;
    private Coroutine coroutine;
    public static bool control = true;
    void Start()
    {
        coroutine = StartCoroutine(SpawnEnemy());
    }
    public void Stop()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, START1.position, Quaternion.identity);                                
                CountEnemyAlive++;
                if(START2!=null) {
                    Enemy enemy = GameObject.Instantiate(wave.enemyPrefab, START2.position, Quaternion.identity);
                    enemy.firstPath = false;
                    Debug.Log("firstPath:" + enemy.firstPath);
                    CountEnemyAlive++;
                }                
                if(i!=wave.count-1)
                    yield return new WaitForSeconds(wave.rate);
                while (control ==false)
                {
                    yield return new WaitForSeconds(wave.rate);
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
