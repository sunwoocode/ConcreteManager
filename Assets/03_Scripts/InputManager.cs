using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) OnKey1();
        if (Keyboard.current.digit2Key.wasPressedThisFrame) OnKey2();
        if (Keyboard.current.digit3Key.wasPressedThisFrame) OnKey3();
    }

    private void OnKey1()
    {
        UIManager.Instance.ShowVillainUI();
    }

    private void OnKey2()
    {
        Debug.Log("2 입력");
    }

    private void OnKey3()
    {
        Debug.Log("3 입력");
    }
}