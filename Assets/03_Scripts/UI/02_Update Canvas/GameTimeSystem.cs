using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimeSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startTime = 5f;

    private float timer;
    private bool isRunning;

    void Start()
    {
        StartTimer(startTime);
    }

    void Update()
    {
        if (!isRunning) return;
        UpdateUI();
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0f;
            isRunning = false;
            timerText.text = "00:00";
            OnTimeOver();
            return;
        }
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
        if (timer <= 0f)
        {
            timerText.text = "00:00";
            return;
        }
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.CeilToInt(timer % 60f);
        if (seconds == 60) { seconds = 0; minutes++; }
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnTimeOver()
    {
        SpawnSystem.Instance.SpawnStart();
        StartCoroutine(HeroSpawnStart());
        StartCoroutine(RestartTimer());
    }

    private IEnumerator HeroSpawnStart()
    {
        int heroSpawnTime = Random.Range(2, 4);

        yield return new WaitForSeconds(heroSpawnTime);

        SpawnSystem.Instance.SpawnStart();
    }

    private IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(1f);
        StartTimer(startTime);
    }
}