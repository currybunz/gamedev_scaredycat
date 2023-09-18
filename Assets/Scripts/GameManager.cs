using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private const string PlayerPointsKey = "PlayerPoints";

    public int playerPoints = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerPoints(int sceneIndex, int points)
    {
        PlayerPrefs.SetInt(PlayerPointsKey + sceneIndex, points);
        PlayerPrefs.Save();
    }

    public int LoadPlayerPoints(int sceneIndex)
    {
        return PlayerPrefs.GetInt(PlayerPointsKey + sceneIndex, 0);
    }

    // You can add methods to increase, decrease, or reset points as needed
}

