﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool PlayerisDead = false;

    public GameObject deathMenuUI;
    public GameObject Score;

    private void Start()
    {
        
    }
    void Update()
    {
       if (PlayerisDead == true)
        {
            DeathScreen();
        }
       
    }

    public void Restart()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PlayerisDead = false;
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    void DeathScreen()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PlayerisDead = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
    }
}
