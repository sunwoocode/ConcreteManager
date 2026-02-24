using System.Collections.Generic;
using UnityEngine;

public class VillainSpawnData : MonoBehaviour
{
    public static VillainSpawnData Instance { get; private set; }

    public List<Vector3> spawnPositions = new List<Vector3>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        for (float x = -4.5f; x < 4.5; x++)
        {
            for (float y = -4.5f; y < 4.5; y++)
            {
                spawnPositions.Add(new Vector3(x, 0, y));
            }
        }
    }
}