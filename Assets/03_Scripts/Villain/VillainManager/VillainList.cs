using System.Collections.Generic;
using UnityEngine;

public class VillainList : MonoBehaviour
{
    public static VillainList Instance { get; private set; }

    [SerializeField]
    private List<VillainSO> villainDataList = new List<VillainSO>();

    public List<VillainSO> VillainDataList => villainDataList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환해도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }
}