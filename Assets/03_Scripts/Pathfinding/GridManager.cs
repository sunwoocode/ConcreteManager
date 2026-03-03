using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Mathematics;
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

    private bool isLoged;

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
        NDResearch();           // 노드 walkable 값 탐색
        NDInselt();             // 노드 수정

        isLoged = false;
        BuildExportToCSV();     // 건물 데이터 csv 백업
    }

    public void NDResearch()
    {

    }

    void NDInselt()
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

    public void NordExportToCSV()       // 노드 데이터
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

    public void BuildExportToCSV()       // 건물 데이터
    {
        if (isLoged) return;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Index,Name,High,Center,EUp,EDown,WUp,WDown");

        // bpData 출력 반복문
        for (int i = 0; i < bpData.Count; i++)
        {
            sb.AppendLine($"{i},{bpData[i].height},{bpData[i].buildName},{bpData[i].corners[0].x},{bpData[i].corners[1].x}," +
                $"{bpData[i].corners[2].x},{bpData[i].corners[3].x},{bpData[i].corners[4].x}");
        }
        File.WriteAllText(Application.dataPath + "/03_Scripts/Pathfinding/BuildData.csv", sb.ToString());

        isLoged = true;
    }


    public void FindWalkableNode(Node node)      // 이동 가능 노드 탐색
    {
        // node.nodePos이 bpData 범위 내 포함되는지 확인하고,
        // 포함되어 있다면 해당 node.walkable = flase 한다.
    }
}