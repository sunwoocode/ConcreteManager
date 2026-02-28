using UnityEngine;

[CreateAssetMenu(fileName = "VillainSO", menuName = "Scriptable Objects/VillainSO")]
public class VillainSO : ScriptableObject
{
    public string id;               // 식별자

    public string vName;            // 이름
    public Sprite icon;             // 이미지

    public Goal goal;               // 목표
    public Combat combat;           // 전투
    public Weakness weakness;       // 약점

    public float readyTime;         // 준비 시간
    public float attackRange;       // 공격 범위
    /// <summary>
    /// -----------------------------------------
    /// </summary>

    public int hp;                  // 체력
    public int str;                 // 공격력
    public int def;                 // 방어력

    public int mov;                 // 이동 속도
    public int speed;               // 공격 속도

    public int itg;                 // 지능
    public int sight;               // 시야 범위

    public int destructionPower;    // 최종 파괴력
    public int aggroPriority;       // 어그로 우선순위
}

public enum Goal        // 목표
{
    Person,
    Hero,
    Villain,
    Building,
    Money,
}

public enum Combat  // 공격 타입
{
    Punch,
    Kick,
    Weapon,
}

public enum Weakness    // 약점
{
    Bear,
    Police,
    Money,
    Love,
}