using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class AttackSystem : MonoBehaviour
{
    private int targetType = -1;
    private float attackRange;

    private void Awake()
    {
        attackRange = VillainList.Instance.VillainDataList[0].attackRange;
    }

    void Start()
    {
        StartCoroutine(ReadyTime(VillainList.Instance.VillainDataList[0].readyTime));
        FindGoal(VillainList.Instance.VillainDataList[0].goal);
    }

    IEnumerator ReadyTime(float readyTime)
    {
        yield return new WaitForSeconds(readyTime);
        StartAttack();
    }

    public void StartAttack()
    {
        Debug.Log("공격 시작!");
        if (targetType == 0) FindPerson();
        else if (targetType == 1) FindHero();
        else if (targetType == 2) FindBuilding();
        else return;
    }

    public void FindGoal(Goal goal)     // 사정거리 범위 체크
    {
        if (goal == Goal.Person) targetType = 0;
        else if (goal == Goal.Hero) targetType = 1;
        else if (goal == Goal.Building) targetType = 2;
        else return;
    }

    public void FindPerson()
    {
        int count = 10;
        Debug.Log("주변에 사람이 " + count + "명 있네!");
    }

    public void FindHero()
    {

    }

    public void FindBuilding()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Building"))
            {
                Debug.Log("건물 발견: " + col.gameObject.name);
                Destroy(col.gameObject);
            }
        }
    }
}