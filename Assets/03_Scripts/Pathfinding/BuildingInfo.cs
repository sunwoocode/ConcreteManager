using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingInfo : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // Debug.Log("건물 데이터: " + GridManager.instance.bpData[0]);
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