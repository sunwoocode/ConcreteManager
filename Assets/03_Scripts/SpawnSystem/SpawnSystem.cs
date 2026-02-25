using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static SpawnSystem Instance { get; private set; }

    public GameObject villainPrefab;
    public GameObject heroPrefab;

    [SerializeField] private bool isHeroTime;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnStart()
    {
        if (!isHeroTime)
        {
            SpawnData.Instance.CreateSpawnPosition();

            Debug.Log("빌런 등장!");
            int index = Random.Range(0, SpawnData.Instance.villainSpawnPositions.Count);

            Vector3 spawnPos = SpawnData.Instance.villainSpawnPositions[index];
            Debug.Log("빌런 등장 위치: " + (spawnPos.x + 5.5) + ", " + (spawnPos.z + 5.5));
            
            Instantiate(villainPrefab, spawnPos, Quaternion.identity);

            isHeroTime = true;
        }
        else
        {
            Debug.Log("히어로 등장!");
            int index = Random.Range(0, SpawnData.Instance.heroSpawnPositions.Count);

            Vector3 spawnPos = SpawnData.Instance.heroSpawnPositions[index];
            Debug.Log("히어로 등장 위치: " + (spawnPos.x + 5.5) + ", " + (spawnPos.z + 5.5));

            Instantiate(heroPrefab, spawnPos, Quaternion.identity);

            isHeroTime = false;
        }
    }
}