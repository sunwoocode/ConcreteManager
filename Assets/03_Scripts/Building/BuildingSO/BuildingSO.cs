using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BuildingSO", menuName = "Scriptable Objects/BuildingSO")]
public class BuildingSO : ScriptableObject
{
    #region 변수
    public string buildingName;     // 이름
    public Sprite icon;             // 이미지

    public int coast;               // 가격 (달러)
    public float height;            // 높이 (미터)
    public int horizontalSize;      // 가로 크기 (타일)
    public int verticalSize;        // 세로 크기 (타일)
    #endregion
}
