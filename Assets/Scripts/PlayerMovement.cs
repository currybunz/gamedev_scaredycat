using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collide;
    private SpriteRenderer sprite;
    private Animator animated;

    [SerializeField] private LayerMask jumpGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpSpeed = 6f;

    private enum MoveState { idle, walk, jump, fall }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
        animated = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MoveState state;

        if(dirX > 0f)
        {
            state = MoveState.walk;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MoveState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MoveState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MoveState.jump;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MoveState.fall;
        }

        animated.SetInteger("state", (int)state);
    }

<<<<<<< Updated upstream
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
=======
>>>>>>> Stashed changes
}
