using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animated;

    public int maxLives = 3; // Set the maximum number of lives the player has
    public Image[] livesUI;

    // Store the initial position for restarting
    private Vector3 initialPosition;

    // Store the current number of lives
    private int currentLives;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animated = GetComponent<Animator>();

        // Store the initial position of the player
        initialPosition = transform.position;

        currentLives = maxLives;
        UpdateLivesUI();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            currentLives--;
            if (currentLives <= 0)
            {
                DieAndRestartScene();
            }
            else
            {
                DieAndRestartScene();
                UpdateLivesUI()
            }
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < livesUI.Length; i++)
        {
            if (i < currentLives)
            {
                livesUI[i].enabled = true;
            }
            else
            {
                livesUI[i].enabled = false;
            }
        }
    }

    private void DieAndRestartScene()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animated.SetTrigger("death"); // Show death animation immediately
        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1.5f); // Adjust the delay as needed
        rb.velocity = Vector2.zero;
        transform.position = initialPosition;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
    // private void LoseLife()
    // {
    //     heartManager.TakeDamage(); // Use the TakeDamage function from HeartManager
    //     DieAndRestartScene();
    // }

    // private void Die()
    // {
    //     rb.bodyType = RigidbodyType2D.Static;
    //     animated.SetTrigger("death");
    //     // You can also add a game over screen or logic here if needed.
    // }

    // private void DieAndRestartScene()
    // {
    //     rb.bodyType = RigidbodyType2D.Static;
    //     animated.SetTrigger("death"); // Show death animation immediately
    //     StartCoroutine(RestartLevel());
    // }

    // private IEnumerator RestartLevel()
    // {
    //     yield return new WaitForSeconds(1.5f);
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
