using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState : MonoBehaviour
{
    public Sprite openSprite; // Sprite for the open door
    public KeyCollector keyCollector;

    private bool isOpen = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with object tag: " + collision.gameObject.tag);
        if (collision.CompareTag("Player") && !isOpen && keyCollector.IsCollected && keyCollector != null)
        {
            isOpen = true;

            // Change the sprite to the open door sprite
            spriteRenderer.sprite = openSprite;
        }
    }
}
