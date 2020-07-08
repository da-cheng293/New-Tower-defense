using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject endUI;
    public Text endMessage;
    //public bool isTwoPath;
    public static GameManager Instance;
    private EnemySpawner enemySpawner;
    
    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "Victory";
    }
    public void Failed()
    {
        enemySpawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "Defeat";
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
    public void OnButtonMenu()
    {
        Enemy.speed = 10;
        Enemy_1.speed = 15;
        Turret.control = true;
        EnemySpawner.control = true;
        paused.key = 0;
       // paused.isPause = false;
        SceneManager.LoadScene(0);
    }
}
