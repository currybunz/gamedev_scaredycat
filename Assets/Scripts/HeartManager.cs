using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    private int currentLives;
    public Image[] heartImages;

    private void Start()
    {
        currentLives = maxLives;
        UpdateHeartUI();
    }

    public void TakeDamage()
    {
        if (currentLives > 0)
        {
            currentLives--;

            if (currentLives <= 0)
            {
                // Implement game over logic here
                Debug.Log("Game Over");
            }
            else
            {
                UpdateHeartUI();
            }
        }
    }
    private void UpdateHeartUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentLives)
            {
                heartImages[i].gameObject.SetActive(true);
            }
            else
            {
                heartImages[i].gameObject.SetActive(false);
            }
        }
    }
    // public void AddHealth(float _value)
    // {
    //     currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    // }
}