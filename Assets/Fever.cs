using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    public GameObject FeverEffect;

    public GameObject SizeBar;
    public GameObject FeverSizeBar;

    public static bool EnoughSize = false;

    public SpriteRenderer PlayerSR;
    public SpriteRenderer BackgroundSR;    

    public static event Action<Color> ChangeSpikeColor;
    public static event Action<Color> ChangePointColor;
    public static event Action<Color> ChangeWallColor;

    Color BackgroundC = new Color(71 / 255f, 115 / 255f, 102 / 255f);
    Color ObstacleC = new Color(157 / 255f, 54 / 255f, 45 / 255f);
    Color PointC = new Color(250 / 255f, 226 / 255f, 164 / 255f);
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
        PlayerSR.color = Color.black;
        BackgroundSR.color = Color.white;
        ChangeSpikeColor?.Invoke(Color.black);
        ChangePointColor?.Invoke(Color.black);
        ChangeWallColor?.Invoke(Color.black);

        FeverEffect.SetActive(true);

        FeverSizeBar.SetActive(true);
        SizeBar.SetActive(false);
    }
    public void FeverDeactive()
    {
        BackgroundSR.color = BackgroundC;
        ChangeSpikeColor?.Invoke(ObstacleC);
        ChangePointColor?.Invoke(PointC);
        ChangeWallColor?.Invoke(WallC);

        FeverEffect.SetActive(false);

        FeverSizeBar.SetActive(false);
        SizeBar.SetActive(true);
    }
}
