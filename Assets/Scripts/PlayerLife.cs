/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animated;

    public int maxLives = 3; // Set the maximum number of lives the player has
    private int currentLives;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animated = GetComponent<Animator>();
        currentLives = maxLives;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {   

            LoseLife();
        }
    }

    private void LoseLife()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            Die();
        }
        else
        {
            DieAndRestartScene();
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animated.SetTrigger("death");
        // You can also add a game over screen or logic here if needed.
    }

    private void DieAndRestartScene()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animated.SetTrigger("death"); // Show death animation immediately
        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
*/