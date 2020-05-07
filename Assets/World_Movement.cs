﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class World_Movement : MonoBehaviour
{    
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 0.05f;
    
    private bool isAnimating = false;
    private bool isLeft = true;

    public GameObject BackGround;
    public GameObject FeverBackGround;

    
    public GameObject FeverWalls;



    void Update()
    {
        WorldMovement();
        BackgroundSwap();

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

    public void WorldMovement()
    {
        if (PauseMenu.GameIsPaused)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            transform.DOMoveY(target.position.y, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = true; }).SetId("World");
        }

        if (Input.GetMouseButtonDown(1))
        {
            transform.DOMoveY(target.position.y, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = true; }).SetId("World");
        }
    }

    void BackgroundSwap()
    {
        if (Fever.EnoughSize == true)
        {
            BackGround.SetActive(false);
            FeverBackGround.SetActive(true);

            FeverWalls.SetActive(true);
        }
        else
        {
            BackGround.SetActive(true);
            FeverBackGround.SetActive(false);

            FeverWalls.SetActive(false);
        }

    }
}
