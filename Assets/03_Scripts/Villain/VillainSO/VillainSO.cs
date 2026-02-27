using UnityEngine;

[CreateAssetMenu(fileName = "VillainSO", menuName = "Scriptable Objects/VillainSO")]
public class VillainSO : ScriptableObject
{
    #region 변수
    public string id;               // 식별자

    public string vName;            // 이름
    public Sprite icon;             // 이미지

    public CombatType combatType;   // 전투 타입
    public Goal goal;               // 목표
    public weakness weakness;       // 약점

    public float readyTime;         // 준비 시간
    public float attackRange;       // 공격 범위

    public int hp;                  // 체력
    public int str;                 // 공격력
    public int def;                 // 방어력

    public int mov;                 // 이동 속도
    public int speed;               // 공격 속도

    public int itg;                 // 지능
    public int sight;               // 시야 범위

    public int destructionPower;    // 최종 파괴력
    public int aggroPriority;       // 어그로 우선순위
    
    #endregion
}

public enum CombatType  // 공격 타입
{
    Punch,
    Kick,
    Weapon,
}

public enum Goal        // 목표
{
    Person,
    Hero,
    Villain,
    Building,
    Money,
}

public enum weakness    // 약점
{
    Police,
    Money,
    Love,
    Bear,
}