using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startTime = 15f;

    private float timer;
    private bool isRunning;

    void Start()
    {
        StartTimer(startTime);
    }

    void Update()
    {
        if (!isRunning) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = 0f;
            isRunning = false;
            OnTimeOver();
        }

        UpdateUI();
    }

    public void StartTimer(float time)
    {
        timer = time;
        isRunning = true;
        UpdateUI();
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void UpdateUI()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnTimeOver()
    {
        VillainSpawnSystem.Instance.VillainSpawnStart();
        StartTimer(startTime);
        Debug.Log("Time Over");
        // 게임오버 처리 등
    }
}