using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class World_Movement : MonoBehaviour
{    
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 0.05f;
    
    private bool isAnimating = false;
    private bool isLeft = true;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.DOMoveY(target.position.y, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = true; });
        }

        if (Input.GetMouseButtonDown(1))
        {
            transform.DOMoveY(target.position.y, speed).SetEase(Ease.InSine).OnStart(() => { isAnimating = true; }).OnComplete(() => { isAnimating = false; isLeft = true; });
        }
    }
}
