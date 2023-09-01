using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioSource gameOverSound;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverSound.Play();
    }
}
