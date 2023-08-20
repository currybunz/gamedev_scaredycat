using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animated;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpSpeed = 6f;

    private enum MovementPosition { idle, walk, jump, fall }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animated = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementPosition state;

        if(dirX > 0f)
        {
            state = MovementPosition.walk;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementPosition.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementPosition.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementPosition.jump;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementPosition.fall;
        }

        animated.SetInteger("state", (int)state);
    }
}
