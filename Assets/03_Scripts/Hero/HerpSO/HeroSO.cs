using UnityEngine;

public enum HeroType
{
    Power,      // 00 Superman
    Tactical,   // 01 Batman
    Control,    // 10 Ironman
    Mobility,   // 11 Spiderman
}

[CreateAssetMenu(fileName = "HeroSO", menuName = "Scriptable Objects/HeroSO")]
public class HeroSO : ScriptableObject
{
    #region 변수
    public string id;               // 식별자

    public string VillainName;      // 이름
    public Sprite icon;             // 이미지

    public int hp;                  // 체력
    public int str;                 // 공격력
    public int def;                 // 방어력

    public int mov;                 // 이동 속도
    public int speed;               // 공격 속도

    public int itg;                 // 지능

    public AttackType attackType;   // 무기

    public int destructionPower;    // 최종 파괴력

    public HeroType heroType;       // 히어로 타입
    #endregion
}
