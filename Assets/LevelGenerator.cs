using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float Player_Distance_Spawn = 1000;

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

    public void SpawnLevelPart()
    {
        Transform choosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = Instantiate(choosenLevelPart, lastEndPosition, Quaternion.identity);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
}
