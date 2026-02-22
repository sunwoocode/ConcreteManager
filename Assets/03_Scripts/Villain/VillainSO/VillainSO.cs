using UnityEngine;

[CreateAssetMenu(fileName = "VillainSO", menuName = "Scriptable Objects/VillainSO")]
public class VillainSO : ScriptableObject
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
    public int sight;               // 시야 범위

    public int attType;             // 공격 타입
    public int tarType;             // 타깃 타입

    public int destructionPower;    // 최종 파괴력
    public int aggroPriority;       // 어그로 우선순위

    #endregion
}
