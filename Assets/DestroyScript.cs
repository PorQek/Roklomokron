using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public LevelGenerator levelGenerator;    


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "LevelSegment")
        {
            //levelGenerator.SpawnLevelPart();            
        }
    }
}
