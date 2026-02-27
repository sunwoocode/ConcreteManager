using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int position;     // 그리드 상의 정수 좌표 (x, y)
    public bool walkable;           // 장애물 여부 (false일 경우 이동 불가능한 구역)
    public int movementWeight = 1;  // 이동 비용 가중치 (예: 도로는 1, 험지는 5)

    public int gCost;   // 시작점으로부터 현재 노드까지 도달하는 데 드는 실제 비용
    public int hCost;   // 현재 노드에서 목표점까지의 예상 거리 (맨해튼 거리)
    public int fCost => gCost + hCost;  // 총 비용 (gCost + hCost)
    public Node parent; // 역추적 노드

    public Node(Vector2Int pos, bool isWalkable, int weight = 10)    // 노드 생성자
    {
        position = pos;             // 격자 내 위치
        walkable = isWalkable;      // 통행 가능 여부
        movementWeight = weight;    // 이동 시 발생하는 추가 비용
    }

    public void Reset()     // 초기화
    {
        gCost = 0;
        hCost = 0;
        parent = null;
    }
}

public class AStarPathfinding : MonoBehaviour
{
    private GridManager gridManager;

    private List<Node> openList;        // 탐색 예정 노드 목록
    private HashSet<Node> closedList;   // 탐색 완료 노드 목록

    void Awake()
    {
        gridManager = GridManager.instance;
    }

    public List<Node> FindPath(Vector3 startPos, Vector3 targetPos) { return null; }
    private List<Node> GetNeighbours(Node node) { return null; }
    private List<Node> RetracePath(Node startNode, Node endNode) { return null; }
    private int GetDistance(Node nodeA, Node nodeB) { return 0; }
}