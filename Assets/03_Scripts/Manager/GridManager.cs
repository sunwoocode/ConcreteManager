using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 20;
    public int height = 20;
    public float cellSize = 1f;

    private Tile[,] grid;

    void Awake()
    {
        grid = new Tile[width, height];
    }

    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt(worldPos.x / cellSize);
        int y = Mathf.FloorToInt(worldPos.z / cellSize);
        return new Vector2Int(x, y);
    }
}

public class Tile
{
    public bool occupied;
}
