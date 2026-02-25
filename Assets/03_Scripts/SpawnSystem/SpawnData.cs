using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData : MonoBehaviour
{
    public static SpawnData Instance { get; private set; }
    public List<Vector3> villainSpawnPositions = new List<Vector3>();
    public List<Vector3> heroSpawnPositions = new List<Vector3>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CreateSpawnPosition()
    {
        for (float x = -4.5f; x < 4.5f; x++)
            for (float y = -4.5f; y < 4.5; y++)
                villainSpawnPositions.Add(new Vector3(x, 0, y));

        for (int x = -4; x < 4; x++)
            for (int y = -4; y < 4; y++)
                heroSpawnPositions.Add(new Vector3(x, 0, y));
    }
}