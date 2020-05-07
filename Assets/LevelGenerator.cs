using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float Player_Distance_Spawn = 100;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform player;

    private Transform newLevelPart;
    private Transform lastLevelPartTransform;
    
    private  Vector3 _lastEndPosition;
    private Vector3 _playerPosition;

    [HideInInspector] public bool tryToSpawn;
    void Awake()
    {
        lastLevelPartTransform = levelPart_Start.transform; 
        _lastEndPosition = levelPart_Start.Find("EndPosition").position;
        _playerPosition = player.Find("Character").position;


        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    void Update()
    {
        if (Vector3.Distance(_playerPosition, _lastEndPosition) < Player_Distance_Spawn)
        {
            //SpawnLevelPart();
        }

        if (tryToSpawn && !lastLevelPartTransform.GetComponent<World_Movement>().isAnimating)
        {
            SpawnLevelPart();
            tryToSpawn = false;
        }
    }

    public void SpawnLevelPart()
    {
        
        newLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        _lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        lastLevelPartTransform = Instantiate(newLevelPart, _lastEndPosition, Quaternion.identity);
//        _lastEndPosition.y -= 6;
    }
}