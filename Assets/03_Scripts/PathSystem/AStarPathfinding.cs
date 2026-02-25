using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A* 길찾기 알고리즘의 최소 단위인 격자 노드 정보를 담는 클래스입니다.
/// </summary>
public class Node
{
    [Header("기본 데이터")]
    public Vector2Int position;     // 그리드 상의 정수 좌표 (x, y)
    public bool walkable;           // 장애물 여부 (false일 경우 이동 불가능한 구역)
    public int movementWeight = 1;  // 이동 비용 가중치 (예: 도로는 1, 험지는 5)

    [Header("A* 알고리즘 연산용 비용")]
    /// <summary>
    /// G Cost: 시작점으로부터 현재 노드까지 도달하는 데 드는 실제 비용
    /// </summary>
    public int gCost;

    /// <summary>
    /// H Cost (Heuristic): 현재 노드에서 목표점까지의 예상 거리 (보통 맨해튼 거리 사용)
    /// </summary>
    public int hCost;

    /// <summary>
    /// F Cost: 총 비용 (gCost + hCost). 이 값이 낮은 노드를 우선적으로 탐색함
    /// </summary>
    public int fCost => gCost + hCost;

    /// <summary>
    /// 경로 역추적을 위한 부모 노드 참조. 
    /// 최종 경로 도달 시 목표점에서부터 부모를 타고 올라가면 최단 경로가 완성됨
    /// </summary>
    public Node parent;

    /// <summary>
    /// Node 생성자
    /// </summary>
    /// <param name="pos">격자 내 위치</param>
    /// <param name="isWalkable">통행 가능 여부</param>
    /// <param name="weight">이동 시 발생하는 추가 비용</param>
    public Node(Vector2Int pos, bool isWalkable, int weight = 1)
    {
        position = pos;
        walkable = isWalkable;
        movementWeight = weight;
    }

    /// <summary>
    /// 새로운 경로 탐색을 시작하기 전, 이전 탐색의 잔류 데이터를 초기화합니다.
    /// </summary>
    public void Reset()
    {
        gCost = 0;
        hCost = 0;
        parent = null;
    }
}

public class AStarPathfinding : MonoBehaviour
{
    private List<Node> openList;        // 탐색 예정 노드 목록
    private HashSet<Node> closedList;   // 탐색 완료 노드 목록
    private Node[,] grid;               // 전체 격자 노드 배열
    private Node startNode;             // 시작 노드
    private Node targetNode;            // 목표 노드

    /*
    public List<Vector3> FindPath(Vector3 startPos, Vector3 targetPos) { }
    private List<Node> GetNeighbours(Node node) { }
    private List<Vector3> RetracePath(Node startNode, Node endNode) { }
    private int GetDistance(Node nodeA, Node nodeB) { }
    private Node NodeFromWorldPoint(Vector3 worldPosition) { }
    */
}