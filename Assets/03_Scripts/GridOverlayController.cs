using UnityEngine;

public class GridOverlayController : MonoBehaviour
{
    [Header("Grid")]
    public float cellSize = 1f;
    public Vector2 origin = Vector2.zero; // 월드 XZ 기준 원점

    [Header("Refs")]
    public Camera cam;
    public Renderer targetRenderer; // Plane Renderer

    static readonly int CellSizeID = Shader.PropertyToID("_CellSize");
    static readonly int OriginID = Shader.PropertyToID("_GridOrigin");
    static readonly int HiCellID = Shader.PropertyToID("_HighlightCell");
    static readonly int HiOnID = Shader.PropertyToID("_HighlightEnabled");

    MaterialPropertyBlock mpb;

    void Awake()
    {
        if (!cam) cam = Camera.main;
        mpb = new MaterialPropertyBlock();
        ApplyStaticParams();
    }

    void ApplyStaticParams()
    {
        targetRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat(CellSizeID, cellSize);
        mpb.SetVector(OriginID, origin);
        targetRenderer.SetPropertyBlock(mpb);
    }

    void Update()
    {
        // 마우스 레이 -> 바닥 hit
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 500f))
        {
            Vector3 p = hit.point; // 월드
            Vector2 gridP = new Vector2(p.x, p.z);

            int gx = Mathf.FloorToInt((gridP.x - origin.x) / cellSize);
            int gy = Mathf.FloorToInt((gridP.y - origin.y) / cellSize);

            targetRenderer.GetPropertyBlock(mpb);
            mpb.SetVector(HiCellID, new Vector2(gx, gy));
            mpb.SetFloat(HiOnID, 1f);
            targetRenderer.SetPropertyBlock(mpb);
        }
        else
        {
            targetRenderer.GetPropertyBlock(mpb);
            mpb.SetFloat(HiOnID, 0f);
            targetRenderer.SetPropertyBlock(mpb);
        }
    }
}
