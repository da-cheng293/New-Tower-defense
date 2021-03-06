﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Paused : MonoBehaviour
{
    public GameObject pauseButton, pausePanel, pauseest;
    float timeLeft = 30.0f;
    public static float key = 0;
    public Text timeremain;
    public Text remainfrequency;
    private float timeseconds = 30.0f;
    private int frequcies = 4;
    public bool isPause = false;
    public bool isTwoPath;
    public AudioSource panelAudio;
    // private Enemy control;
    // Start is called before the first frame update

    void changetime(float changetimenumber = 0.0f)
    {
        timeseconds -= changetimenumber;
        //Debug.Log("timeseconds: " + timeseconds);
        if (timeseconds < 0)
        {
            timeseconds = 0;
        }
        timeremain.text = "Time:" + " " + Mathf.FloorToInt(timeseconds % 60f).ToString("00") + "s";
        //Debug.Log("text: " + timeremain.text);
    }

    void changefrequency(int changefreqnumber = 0)
    {
        frequcies += changefreqnumber;
        if (frequcies < 0)
        {
            frequcies = 0;
        }
        remainfrequency.text = "Remain: " + frequcies;


    }
    public void Start()
    {
        panelAudio = GameObject.Find("Pause_audio").GetComponent<AudioSource>();
        //changetime(-1);
        timeseconds = 30.0f;
        frequcies = 4;
        // onUnpause();
    }
    void Update()

    {
        if (key == 1)
        {
            changetime(Time.deltaTime);

            onPause();
        }

    }
    public void onPause()
    {
        timeLeft -= Time.deltaTime;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Enemy.speed = 0;
        if (isTwoPath) Enemy_1.speed = 0;
        Turret.control = false;
        EnemySpawner.control = false;
        key = 1;
        if(!isPause) {
            changefrequency(-1);
        }
        isPause = true;
        if (timeLeft < 0)
        {
            Enemy.speed = 9;
            if(isTwoPath) Enemy_1.speed = 6;
            Turret.control = true;
            EnemySpawner.control = true;
            onUnpause(); 
        }
    }
    public void onUnpause()
    {
        panelAudio.Play();
        // changefrequency(-1);
        timeseconds = 30.0f;
        //frequcies = frequcies-1;
        timeLeft = 30.0f;
        timeremain.text = "Time:" + " " + 30 + "s";
        if (frequcies == 0)
        {
            pausePanel.SetActive(false);
            pauseButton.SetActive(false);
            pauseest.SetActive(true);
            //Debug.Log("reach");
        }
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Enemy.speed = 9;
        if (isTwoPath) Enemy_1.speed = 6;
        Turret.control = true;
        EnemySpawner.control = true;
        key = 0;
        isPause = false;
    }
    // Update is called once per frame
}
