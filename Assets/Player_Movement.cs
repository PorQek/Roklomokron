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

    private void Start()
    {
        originalScale = transform.localScale;
        Fill();
    }

    public void Eat()
    {
        transform.DOKill(false);
        transform.DOScale(transform.localScale * 1.2f, 0.2f).OnComplete(Fill);
    }

    private void Fill()
    {
        transform.DOScale(0, transform.localScale.magnitude * 15f / originalScale.magnitude).OnComplete(KulkaDed);
    }

    private void KulkaDed()
    {

    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !isLeft)
        {
            transform.DOMoveX(left.position.x, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = true; });
        }

        if (Input.GetMouseButtonDown(1) && isLeft)
        {
            transform.DOMoveX(right.position.x, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = false; });
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Point")
        {
            Debug.Log("Zjedzone w chuj");
            Eat();
        }
    }
}
