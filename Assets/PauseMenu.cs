using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;

    public GameObject player;
    
    public GameObject pauseMenuUI;
    public GameObject shopMenu;

    public GameObject Score;
    public GameObject SizeBar;
    public GameObject MouseIcons;

    public SpriteRenderer playerSR;

    private void Start()
    {
        
        Pause();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Score.SetActive(true);
        playerSR.enabled = true;
        MouseIcons.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        player.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerSR.enabled = false;
        MouseIcons.SetActive(false);
    }

    public void Shop()
    {
        pauseMenuUI.SetActive(false);
        shopMenu.SetActive(true);
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
