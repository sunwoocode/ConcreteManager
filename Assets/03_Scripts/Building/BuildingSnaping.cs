using System.Collections.Generic;
using UnityEngine;

public class BuildingSnaping : MonoBehaviour
{
    private Vector3 pos;            // 건물 위치 지역 변수
    private float width;            // 건물 가로 지역 변수
    private float length;           // 건물 세로 지역 변수
    private float high;             // 건물 높이 지역 변수

    void Start()
    {
        width = this.transform.localScale.x;        // 건물 가로 크기
        length = this.transform.localScale.z;       // 건물 세로 크기
        high = this.transform.localScale.y;         // 건물 높이
    }

    void Update()
    {
        pos = this.transform.position;     // 현재 건물 위치로 초기화
        this.transform.position = GetSnappedPosition(pos, width, length);      // 건물 위치 0.5 단위로 정렬
        pos = this.transform.position;
        BuildingPosition();
    }

    public static Vector3 GetSnappedPosition(Vector3 worldPos, float width, float length)
    {
        bool oddX = width % 2 <= 1;     // 건물 가로 크기가 홀수
        bool oddZ = length % 2 <= 1;    // 건물 세로 크기가 홀수

        // 
        float snapX = oddX ? Mathf.Floor(worldPos.x) + 0.5f : Mathf.Round(worldPos.x);
        float snapZ = oddZ ? Mathf.Floor(worldPos.z) + 0.5f : Mathf.Round(worldPos.z);

        return new Vector3(snapX, worldPos.y, snapZ);
    }

    public void BuildingPosition()      // 빌딩 데이터
    {
        List<Vector3> bp = new List<Vector3>();

        float halfWidth = width / 2f;
        float halfLength = length / 2f;

        Vector3 applyPosX = new Vector3(pos.x + halfWidth, pos.y, pos.z + halfLength);
        Vector3 applyPosY = new Vector3(pos.x - halfWidth, pos.y, pos.z - halfLength);


        bp.Add(pos);
        bp.Add(applyPosY);
        bp.Add(applyPosY);

        BuildData data = new BuildData(this.name, high, bp);
        GridManager.instance.bpData.Add(data);
    }
}