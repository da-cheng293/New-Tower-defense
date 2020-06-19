using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paused : MonoBehaviour
{
    public GameObject pauseButton, pausePanel;
    // Start is called before the first frame update
    public void Start()
    {
        onUnpause();
    }
    public void onPause()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void onUnpause()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    // Update is called once per frame
}
