using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        Fever.ChangeWallColor += Fever_ChangeWallColor;
    }

    private void Fever_ChangeWallColor(Color obj)
    {
        _spriteRenderer.color = obj;
    }

    private void OnDisable()
    {
        Fever.ChangeWallColor -= Fever_ChangeWallColor;

    }

    private void OnDestroy()
    {
        Fever.ChangeSpikeColor -= Fever_ChangeWallColor;

    }
}
