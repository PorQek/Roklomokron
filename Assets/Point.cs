using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject effect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Lecimy kurwa tutaj");
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
