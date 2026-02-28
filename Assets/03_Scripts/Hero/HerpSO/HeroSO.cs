using UnityEngine;

[CreateAssetMenu(fileName = "HeroSO", menuName = "Scriptable Objects/HeroSO")]
public class HeroSO : ScriptableObject
{
    public string id;               // 식별자

    public string hName;            // 이름
    public Sprite icon;             // 이미지

    public Movement movement;       // 이동
    public Power power;             // 능력
    public Personality personality; // 성향

    /// <summary>
    /// -----------------------------------------
    /// </summary>

    public int hp;                  // 체력
    public int str;                 // 공격력
    public int def;                 // 방어력

    public int mov;                 // 이동 속도
    public int speed;               // 공격 속도

    public int itg;                 // 지능

    public int destructionPower;    // 최종 파괴력
}

public enum Movement
{
    Walk,
    Jump,
    Fly,
}

public enum Power
{
    Power,      // 00 Superman
    Tactical,   // 01 Batman
    Control,    // 10 Ironman
    Mobility,   // 11 Spiderman
}

public enum Personality
{

}

