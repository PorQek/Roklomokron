using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    public static bool EnoughSize = false;
    void Update()
    {
        if(EnoughSize)
        {
            FeverActive();
        }
        else
        {
            FeverDeactive();
        }
    }

    public void FeverActive()
    {
        
    }
    public void FeverDeactive()
    {

    }
}
