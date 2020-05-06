using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    public static bool EnoughSize = false;

    public SpriteRenderer PlayerSR;
    public SpriteRenderer BackgroundSR;
    SpriteRenderer ObstacleSR;
    SpriteRenderer WallSR;
    SpriteRenderer PointSR;

    Color BGC = new Color(71/ 255f, 115/255f, 102/255f);


    private void Start()
    {
        FeverDeactive();
        //PlayerSR = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(EnoughSize)
        {
            Debug.Log("NAPIERDALANKO");
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

    }
    public void FeverDeactive()
    {
        BackgroundSR.color = BGC;
    }
}
