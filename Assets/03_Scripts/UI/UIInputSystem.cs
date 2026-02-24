using UnityEngine;

public class UIInputSystem : MonoBehaviour
{
    public void SetActiveVillainUI()        // 빌런 아이콘 UI 클릭 메서드
    {
        UIManager.Instance.ShowVillainUI();
        return;
    }
}
