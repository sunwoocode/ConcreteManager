using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;

[CustomEditor(typeof(BuildingSO))]
public class BuildingSOEditor : Editor
{
    SerializedProperty nameProp;
    SerializedProperty iconProp;

    SerializedProperty coastProp;
    SerializedProperty heightProp;
    SerializedProperty horizontalSizenProp;
    SerializedProperty verticalSizeProp;

    void OnEnable()
    {
        // BuildingSO에 실제로 존재하는 필드명과 반드시 동일해야 함
        nameProp = serializedObject.FindProperty("buildingName");
        iconProp = serializedObject.FindProperty("icon");

        coastProp = serializedObject.FindProperty("coast");
        heightProp = serializedObject.FindProperty("height");
        horizontalSizenProp = serializedObject.FindProperty("horizontalSize");
        verticalSizeProp = serializedObject.FindProperty("verticalSize");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // 이름
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(nameProp, new GUIContent("Name"));
        bool changedByUser = EditorGUI.EndChangeCheck();

        if (changedByUser)
        {
            string cleaned = CleanName(nameProp.stringValue);
            if (nameProp.stringValue != cleaned)
                nameProp.stringValue = cleaned;
        }

        EditorGUILayout.Space(6);

        // 아이콘
        EditorGUILayout.PropertyField(iconProp, new GUIContent("Icon"));

        // 가격
        EditorGUILayout.PropertyField(coastProp, new GUIContent("coast"));

        // 높이
        EditorGUILayout.PropertyField(heightProp, new GUIContent("height"));

        // 가로 크기
        EditorGUILayout.PropertyField(horizontalSizenProp, new GUIContent("horizontalSize"));

        // 세로 크기
        EditorGUILayout.PropertyField(verticalSizeProp, new GUIContent("verticalSize"));

        serializedObject.ApplyModifiedProperties();
    }

    static string CleanName(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";
        return Regex.Replace(input, @"\s+", ""); // 모든 공백 제거
    }
}
