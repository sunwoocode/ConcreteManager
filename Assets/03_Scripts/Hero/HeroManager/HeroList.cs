
using System.Collections.Generic;
using UnityEngine;

public class HeroList : MonoBehaviour
{
    public static HeroList Instance { get; private set; }

    [SerializeField]
    private List<HeroSO> villainDataList = new List<HeroSO>();

    public List<HeroSO> HeroDataList => HeroDataList;

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

/*

2~3초 후 랜덤한 위치에 히어로 프리팹 생성
그리고 즉시 빌런 위치로 이동


*/