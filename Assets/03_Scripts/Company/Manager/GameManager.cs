using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<BuildingSO> buildingList = new List<BuildingSO>();

    public GameObject company;
    public bool isGmaeOver;
    public int hasMoney;
    public GameObject gameOver;

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (company == null)
        {
            Pause();
            gameOver.SetActive(true);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void MoneyCount()    // º¸À¯ µ· °è»ê
    {

    }
}
