using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingSnaping : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float length;

    void Start()
    {
        width = this.transform.localScale.x;
        length = this.transform.localScale.z;
    }

    void Update()
    {
        position = this.transform.position;
        this.transform.position = GetSnappedPosition(position, width, length);
        BuildingPosition();
    }

    public static Vector3 GetSnappedPosition(Vector3 worldPos, float width, float length)
    {
        bool oddX = width % 2 <= 1;    // È¦¼ö
        bool oddZ = length % 2 <= 1;

        float snapX = oddX ? Mathf.Floor(worldPos.x) + 0.5f : Mathf.Round(worldPos.x);
        float snapZ = oddZ ? Mathf.Floor(worldPos.z) + 0.5f : Mathf.Round(worldPos.z);

        return new Vector3(snapX, worldPos.y, snapZ);
    }

    public List<Vector3> BuildingPosition()
    {
        List<Vector3> bp = new List<Vector3>();

        float halfWidth = width / 2;
        float halfLength = length / 2;

        bp.Add(position);
        bp.Add(new Vector3(position.x + halfWidth, position.y, position.z + halfWidth));
        bp.Add(new Vector3(position.x + halfWidth, position.y, position.z - halfWidth));
        bp.Add(new Vector3(position.x - halfWidth, position.y, position.z - halfWidth));
        bp.Add(new Vector3(position.x - halfWidth, position.y, position.z + halfWidth));

        return bp;
    }
}

public enum BP
{
    Center,
    EastUp,
    EastDown,
    WestUp,
    WestDown,
}