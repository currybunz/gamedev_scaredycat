using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collide;
    private SpriteRenderer sprite;
    private Animator animated;

    public float moveSpeed = 2f; // Adjust the speed as needed
    public Transform leftBoundary;
    public Transform rightBoundary;
    private bool movingRight = true; // Flag to determine the direction of movement

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
        animated = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateAnimation();
    }

    private void UpdateMovement()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            animated.SetBool("walking", true);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            animated.SetBool("walking", false);
        }

        if (movingRight && transform.position.x > rightBoundary.position.x)
        {
            movingRight = false;
        }
        else if (!movingRight && transform.position.x < leftBoundary.position.x)
        {
            movingRight = true;
        }
    }

    private void UpdateAnimation()
    {
        if (rb.velocity.x > 0f)
        {
            sprite.flipX = false;
        }
        else if (rb.velocity.x < 0f)
        {
            sprite.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Touched obstacle");
            // Change direction when hitting an obstacle
            movingRight = !movingRight;
        }
    }
}

