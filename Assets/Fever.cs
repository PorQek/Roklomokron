using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    public GameObject FeverEffect;
    public GameObject SnowEffect;

    public GameObject SizeBar;
    public GameObject FeverSizeBar;

    public static bool EnoughSize = false;

    public SpriteRenderer PlayerSR;
    

    public static event Action<Color> ChangeSpikeColor;
    public static event Action<Color> ChangePointColor;
    public static event Action<Color> ChangeWallColor;

    
    Color ObstacleC = new Color(12 / 255f, 97 / 255f, 117 / 255f);
    Color PointC = new Color(189 / 255f, 0 / 255f, 24 / 255f);
    Color WallC = new Color(17 / 255f, 36 / 255f, 38 / 255f);


    private void Start()
    {

        FeverDeactive();
        //PlayerSR = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();

        
    }
    void Update()
    {
        if(EnoughSize)
        {           
            FeverActive();
            
        }
        else
        {
            FeverDeactive();
        }
    }

    public void FeverActive()
    {
        if (PauseMenu.GameIsPaused == false)
        {
            PlayerSR.color = Color.black;
            ChangeSpikeColor?.Invoke(Color.black);
            ChangePointColor?.Invoke(Color.black);
            ChangeWallColor?.Invoke(Color.black);

            FeverEffect.SetActive(true);
            SnowEffect.SetActive(false);

            FeverSizeBar.SetActive(true);
            SizeBar.SetActive(false);
        }        
        
    }
    public void FeverDeactive()
    {
        if (PauseMenu.GameIsPaused == false)
        {
            ChangeSpikeColor?.Invoke(ObstacleC);
            ChangePointColor?.Invoke(PointC);
            ChangeWallColor?.Invoke(WallC);
            PlayerSR.color = PointC;

            FeverEffect.SetActive(false);
            SnowEffect.SetActive(true);

            FeverSizeBar.SetActive(false);
            SizeBar.SetActive(true);
        }
    }
}
