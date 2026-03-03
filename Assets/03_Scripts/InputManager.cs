using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) OnKey1();
        if (Keyboard.current.digit2Key.wasPressedThisFrame) OnKey2();
        if (Keyboard.current.digit3Key.wasPressedThisFrame) OnKey3();
        if (Keyboard.current.digit4Key.wasPressedThisFrame) OnKey4();
    }

    private void OnKey1()       // Post Tab
    {
        Debug.Log("1 입력 -> Post Tab 이동");
        UIManager.Instance.ShowPostUI();
    }

    private void OnKey2()       // Unit Tab
    {
        Debug.Log("2 입력 -> Unit Tab 이동");
    }

    private void OnKey3()       // Build Tab
    {
        Debug.Log("3 입력 -> Build Tab 이동");
    }

    private void OnKey4()       // Character Tab
    {
        Debug.Log("4 입력 -> Character Tab 이동");
        UIManager.Instance.ShowVillainUI();
    }
}