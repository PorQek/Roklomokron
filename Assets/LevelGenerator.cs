using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float Player_Distance_Spawn = 500f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;
    private Vector3 playerPosition;

    void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        playerPosition = player.Find("Character").position;


        int startingSpawnLevelParts = 6;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    void Update()
    {
        if (Vector3.Distance(playerPosition, lastEndPosition) < Player_Distance_Spawn)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform choosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(choosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
