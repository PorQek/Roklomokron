using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject effect;
    public GameObject feverEffect;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        Fever.ChangePointColor += Fever_ChangePointColor;
    }

    private void Fever_ChangePointColor(Color obj)
    {
        _spriteRenderer.color = obj;
    }

    private void OnDisable()
    {
        Fever.ChangePointColor -= Fever_ChangePointColor;

    }

    private void OnDestroy()
    {
        Fever.ChangePointColor -= Fever_ChangePointColor;

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (Fever.EnoughSize)
            {
                Instantiate(feverEffect, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(effect, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);            
        }
    }
}
