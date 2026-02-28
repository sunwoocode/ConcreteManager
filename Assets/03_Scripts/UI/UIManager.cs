using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private ProfileUI profileUI;
    [SerializeField] private GameObject postUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool isVillainIconClicked;

    public void ShowVillainUI()
    {
        profileUI.ShowVillainProfileUI();
        return;
    }

    public void ShowPostUI()
    {
        postUI.SetActive(true);
    }

    public void ShowUnitUI()
    {

    }

    public void ShowBuildingUI()
    {

    }

    public void ShowCharacterUI()
    {

    }
}
