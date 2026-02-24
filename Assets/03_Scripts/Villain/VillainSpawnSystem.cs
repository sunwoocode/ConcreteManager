using UnityEngine;

public class VillainSpawnSystem : MonoBehaviour
{
    public static VillainSpawnSystem Instance { get; private set; }

    [SerializeField] private GameObject villainPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void VillainSpawnStart()
    {
        int index = Random.Range(0, VillainSpawnData.Instance.spawnPositions.Count);

        Vector3 spawnPos = VillainSpawnData.Instance.spawnPositions[index];

        Debug.Log("빌런 등장 위치: " + (spawnPos.x + 5.5) + ", " + (spawnPos.z + 5.5));
        
        Instantiate(villainPrefab, spawnPos, Quaternion.identity);
    }
}