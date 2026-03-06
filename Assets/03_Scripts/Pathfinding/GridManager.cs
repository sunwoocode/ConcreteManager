
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class GridManager : MonoBehaviour
{
    public static GridManager instance { get; private set; }

    private int width = 10;             // 그리드 가로 갯수
    private int height = 10;            // 그리드 세로 갯수
    private float cellSize = 1;         // 그리드 사이즈

    private Node[,] grid;               // 전체 격자 노드 배열
    public List<BuildData> bpData;      // 건물 데이터 리스트

    private bool isNodeCleared;         // NodeData CSV 문서 초기화

    public Node nodeData;               // 업데이트 되는 Node 데이터

    public List<Node> nodes;            // 노드 반복문 횟수 체크

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        bpData = new List<BuildData>();
        nodes = new List<Node>();

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

                            nodes.Add(node);

                            FindWalkableNode();
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

                            nodes.Add(node);

                            FindWalkableNode();
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

    public void FindWalkableNode()
    {
        if (nodes.Count == 0) return;

        // 모든 노드 기본값 true로 초기화
        for (int j = 0; j < nodes.Count; j++)
            nodes[j].walkable = true;

        if (bpData == null || bpData.Count == 0) return;

        for (int i = 0; i < bpData.Count; i++)
        {
            float minX = Mathf.Min(bpData[i].corners[1].x, bpData[i].corners[2].x);
            float maxX = Mathf.Max(bpData[i].corners[1].x, bpData[i].corners[2].x);
            float minZ = Mathf.Min(bpData[i].corners[1].z, bpData[i].corners[2].z);
            float maxZ = Mathf.Max(bpData[i].corners[1].z, bpData[i].corners[2].z);

            for (int j = 0; j < nodes.Count; j++)
            {
                if (nodes[j].nodePos.x >= minX && nodes[j].nodePos.x <= maxX &&
                    nodes[j].nodePos.z >= minZ && nodes[j].nodePos.z <= maxZ)
                {
                    nodes[j].walkable = false;
                }
            }
        }
    }
}