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

    public AudioSource victoryAudio;
    public AudioSource defeatAudio;
    public AudioSource backgroundAudio;

    private bool isVictory = true;
    private bool isDefeat = true;

    public Button nextButton;
    public Button retryButton;

    public bool isNext;
    
    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
        if (isNext)
        {
            if (nextButton != null) retryButton.gameObject.SetActive(false);
            if (retryButton != null) nextButton.gameObject.SetActive(false);
        }                
    }

    public void Win()
    {
        if (isVictory)
        {
            backgroundAudio.Stop();
            victoryAudio.Play();
            isVictory = false;
        }
        if (isNext)
        {
            nextButton.gameObject.SetActive(true);
        }                
        endUI.SetActive(true);
        endMessage.text = "Victory";
    }
    public void Failed()
    {
        if (isDefeat)
        {
            backgroundAudio.Stop();
            defeatAudio.Play();
            isDefeat = false;
        }
        if (isNext)
        {
            retryButton.gameObject.SetActive(true);
        }        
        enemySpawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "Defeat";
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

    public void onButtonContinue()
    {
        SceneManager.LoadScene(3);
    }

    public void OnButtonMenu()
    {
        Enemy.speed = 9;
        Enemy_1.speed = 6;
        Turret.control = true;
        EnemySpawner.control = true;
        Paused.key = 0;
       // paused.isPause = false;
        SceneManager.LoadScene(0);
    }
}
