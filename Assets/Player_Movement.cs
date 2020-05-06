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

    

    private void Start()
    {
        originalScale = transform.localScale;
        Fill();
    }

    public void Eat()
    {
        DOTween.KillAll(false, new object[] { "MoveLeft", "MoveRight", "World"});
        if (transform.localScale.x <= 2)
            transform.DOScale(transform.localScale * 1.1f, 0.2f).OnComplete(Fill);
    }

    private void Fill()
    {
        transform.DOScale(0, transform.localScale.magnitude * 8f / originalScale.magnitude).OnComplete(KulkaDed);
    }

    private void KulkaDed()
    {
        DeathMenu.PlayerisDead = true;
        ScoreScript.scoreValue = 0;
    }
    void Update()
    {
        size = transform.localScale.x;
        sizeBar.SetHealth(size);

        if (Input.GetMouseButtonDown(0) && !isLeft)
        {
            transform.DOMoveX(left.position.x, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = true; }).SetId("MoveLeft");
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            ScoreScript.scoreValue += 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            ScoreScript.scoreValue += 1;
        }

        if (Input.GetMouseButtonDown(1) && isLeft)
        {
            
            transform.DOMoveX(right.position.x, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = false; }).SetId("MoveRight");
            
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Point")
        {            
            Eat();
            Debug.Log("Zjedzone w chuj");
        }

        if (other.tag == "Obstacle")
        {
            KulkaDed();
            Debug.Log("Zgooon");
        }
    }

}
