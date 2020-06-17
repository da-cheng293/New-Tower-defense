using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paused : MonoBehaviour
{
    public GameObject pauseButton, pausePanel;
    
   // private Enemy control;
    // Start is called before the first frame update
    public void Start()
    {
        onUnpause();
    }
    public void onPause()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Enemy.speed = 0;
        Turret.control = false;
    }
    public void onUnpause()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Enemy.speed = 10;
        Turret.control = true;
    }
    // Update is called once per frame
}
