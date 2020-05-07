using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        Fever.ChangeSpikeColor += Fever_ChangeSpikeColor;
    }

    private void Fever_ChangeSpikeColor(Color obj)
    {
        _spriteRenderer.color = obj;
    }

    private void OnDisable()
    {
        Fever.ChangeSpikeColor -= Fever_ChangeSpikeColor;

    }

    private void OnDestroy()
    {
        Fever.ChangeSpikeColor -= Fever_ChangeSpikeColor;

    }
}
