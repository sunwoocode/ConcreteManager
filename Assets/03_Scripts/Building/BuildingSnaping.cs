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
    }

    public static Vector3 GetSnappedPosition(Vector3 worldPos, float width, float length)
    {
        bool oddX = width % 2 <= 1;    // È¦¼ö
        bool oddZ = length % 2 <= 1;

        float snapX = oddX ? Mathf.Floor(worldPos.x) + 0.5f : Mathf.Round(worldPos.x);
        float snapZ = oddZ ? Mathf.Floor(worldPos.z) + 0.5f : Mathf.Round(worldPos.z);

        return new Vector3(snapX, worldPos.y, snapZ);
    }
}