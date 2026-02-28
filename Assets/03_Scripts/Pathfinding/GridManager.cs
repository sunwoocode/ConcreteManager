using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GridManager : MonoBehaviour
{
    public static GridManager instance { get; private set; }

    private int width = 10;             // 그리드 가로 갯수
    private int height = 10;            // 그리드 세로 갯수
    private float cellSize = 1;         // 그리드 사이즈

    private Node[,] grid;               // 전체 격자 노드 배열

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        CreateGrid();       // 그리드 생성
        ExportToCSV();      // 그리드 csv 백업
    }

    void Start()    // 다른 메니저에서 건물 등의 정보 불러올 때 사용
    {

    }

    void Update()
    {
        NDResearch();       // 노드 walkable 값 탐색
        NDInselt();         // 노드 수정
    }

    public void NDResearch()
    {

    }

    void NDInselt()
    {
        grid[0, 1].walkable = false;
    }

    public void CreateGrid()
    {
        grid = new Node[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                grid[x, y] = new Node(new Vector2Int(x, y), true);
    }

    public void ExportToCSV()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("x,y,weight,walkable");

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Node node = grid[x, y];
                sb.AppendLine($"{x},{y},{node.movementWeight},{node.walkable}");
            }

        File.WriteAllText(Application.dataPath + "/03_Scripts/Pathfinding/NodeData.csv", sb.ToString());
    }
}

// sb.AppendLine("x,y,weight,walkable,Center,EastUp,EastDown,WestUp,WestDown");