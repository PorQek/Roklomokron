using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Transform left, right;
    [SerializeField] private float speed = 0.05f;    

    private bool isAnimating = false;
    private bool isLeft = true;

    private Vector3 originalScale;

    public SizeBar sizeBar;
    public float size;

    private bool gameStarted = false;

    

    private void Start()
    {
        originalScale = transform.localScale;
        Fill();
    }

    public void Eat()
    {
        if (transform.localScale.x < 2)
        {
            DOTween.KillAll(false, new object[] { "MoveLeft", "MoveRight", "World" });
            transform.DOScale(transform.localScale * 1.1f, 0.2f).OnComplete(Fill);            
        }
    }

    private void Fill()
    {
        if (gameStarted == true)
        transform.DOScale(0, transform.localScale.magnitude * 8f / originalScale.magnitude).OnComplete(KulkaDed);
    }

    private void KulkaDed()
    {
        DeathMenu.PlayerisDead = true;
        gameStarted = false;

    }
    void Update()
    {
        size = transform.localScale.x;
        sizeBar.SetHealth(size);

        Movement();
        GetScore();
        
        if (size >= 1.5f)
        {
            Fever.EnoughSize = true;            
        }else
        {
            Fever.EnoughSize = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Point")
        {            
            Eat();            
        }

        if (other.tag == "Obstacle")
        {
            KulkaDed();            
        }
    }
    
    void GetScore()
    {
        if (DeathMenu.PlayerisDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ScoreScript.scoreValue += 1;
            }
            if (Input.GetMouseButtonDown(1))
            {
                ScoreScript.scoreValue += 1;
            }
        }
    }

    void Movement()
    {
        if (PauseMenu.GameIsPaused == true)
            return;


        if (Input.GetMouseButtonDown(0) && !isLeft)
        {
            transform.DOMoveX(left.position.x, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = true; }).SetId("MoveLeft");
            gameStarted = true;
        }

        if (Input.GetMouseButtonDown(1) && isLeft)
        {
            transform.DOMoveX(right.position.x, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = false; }).SetId("MoveRight");
            gameStarted = true;
        }
    }

}
