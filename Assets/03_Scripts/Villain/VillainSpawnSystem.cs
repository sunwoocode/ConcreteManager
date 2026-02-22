using UnityEngine;

public class VillainSpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject villainPrefab;

    void Start()
    {
        int index = Random.Range(0, VillainSpawnData.Instance.spawnPositions.Count);
        Vector3 spawnPos = VillainSpawnData.Instance.spawnPositions[index-4];

        Debug.Log(spawnPos.x + ", " + spawnPos.y + ", " + spawnPos.z);

        Instantiate(villainPrefab, spawnPos, Quaternion.identity);
    }
}