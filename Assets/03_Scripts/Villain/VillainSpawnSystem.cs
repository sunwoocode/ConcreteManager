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
        Vector3 spawnPos = VillainSpawnData.Instance.spawnPositions[index-4];

        Debug.Log(spawnPos.x + ", " + spawnPos.y + ", " + spawnPos.z);

        Instantiate(villainPrefab, spawnPos, Quaternion.identity);
    }
}