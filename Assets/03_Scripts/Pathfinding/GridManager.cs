using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static TreeEditor.TreeEditorHelper;

public class GridManager : MonoBehaviour
{
    public static GridManager instance { get; private set; }

    private int width = 10;             // 그리드 가로 갯수
    private int height = 10;            // 그리드 세로 갯수
    private float cellSize = 1;         // 그리드 사이즈

    private Node[,] grid;               // 전체 격자 노드 배열
    public List<BuildData> bpData;      // 건물 데이터 리스트

    private bool isLoged;               // CSV 문서 초기화

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        bpData = new List<BuildData>();

        CreateGrid();           // 그리드 생성
        NordExportToCSV();      // 그리드 csv 백업
    }

    void Start()    // 다른 메니저에서 건물 등의 정보 불러올 때 사용
    {
    }

    void Update()
    {
        NDInselt();             // 노드 수정
        BuildExportToCSV();     // 건물 데이터 csv 백업
        NordExportToCSV();
        bpData.Clear();
    }

    void NDInselt()             // walkable 데이터 수정
    {
        // grid[0, 1].walkable = true;
    }

    public void CreateGrid()
    {
        grid = new Node[10, 10];

        for (int x = 0; x < 10; x++)
            for (int y = 0; y < 10; y++)
                grid[x, y] = new Node(new Vector2Int(x, y), true);
    }

    public void NordExportToCSV()       // 노드 데이터 백업
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("x,y,direction,walkable");

        for (int i = 0; i < 2; i++)
        {
            for (int y = 0; y < 10; y++)
                for (int x = 0; x < 10; x++)
                {
                    Node node = grid[x, y];

                    if (i == 0)
                    {
                        node.nodeType = false;       // 가로
                        node.nodePos = new Vector3((float)x + 0.5f, 0, (float)y + 1f);

                        if (y != 9)
                        {
                            // wNode nodePos 계산 식
                            sb.AppendLine($"{node.nodePos.x},{node.nodePos.z},{node.nodeType},{node.walkable}");

                            FindWalkableNode(node);
                        }
                    }
                }

            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                {
                    Node node = grid[x, y];

                    if (i == 1)
                    {
                        node.nodeType = true;        // 세로
                        node.nodePos = new Vector3((float)x + 1f, 0, (float)y + 0.5f);

                        if (x != 9)
                        {
                            // hNode nodePos 계산 식
                            sb.AppendLine($"{node.nodePos.x},{node.nodePos.z},{node.nodeType},{node.walkable}");

                            FindWalkableNode(node);
                        }
                            
                    }
                }
        }
            
        File.WriteAllText(Application.dataPath + "/03_Scripts/Pathfinding/NodeData.csv", sb.ToString());
    }

    public void BuildExportToCSV()       // 건물 데이터 백업
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Index,Name,High,CenterX,CenterZ,EUpX,EUpZ,WUpX,WUpZ");

        // bpData 출력 반복문
        for (int i = 0; i < bpData.Count; i++)
        {
            sb.AppendLine($"{i},{bpData[i].height},{bpData[i].buildName}," +
                $"{bpData[i].corners[0].x},{bpData[i].corners[0].z}," +
                $"{bpData[i].corners[1].x},{bpData[i].corners[1].z}," +
                $"{bpData[i].corners[2].x},{bpData[i].corners[2].z}");
        }

        File.WriteAllText(Application.dataPath + "/03_Scripts/Pathfinding/BuildData.csv", sb.ToString());
    }


    public void FindWalkableNode(Node node)      // 이동 가능 노드 탐색
    {
        // node.nodePos이 bpData.corners[1]~bpData.corners[2] 범위 내 포함되는지 확인하고,
        // 포함되어 있다면 해당 node.walkable = flase 한다.

        if (bpData == null || bpData.Count == 0) return;

        for (int i = 0; i < bpData.Count; i++)
        {
            float minX = bpData[i].corners[1].x;
            float maxX = bpData[i].corners[2].x;
            float minZ = bpData[i].corners[1].z;
            float maxZ = bpData[i].corners[2].z;

            if (node.nodePos.x >= minX && node.nodePos.x <= maxX &&
            node.nodePos.z >= minZ && node.nodePos.z <= maxZ)
            {
                node.walkable = false; // 건물 영역 안이므로 이동 불가
                return; // 찾았으면 더 돌 필요 없음
            }
        }

        // 겹치는 건물이 없으면 이동 가능 유지
        node.walkable = true;
    }
}