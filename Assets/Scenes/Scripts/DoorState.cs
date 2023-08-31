using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorState : MonoBehaviour
{
    [SerializeField] private AudioSource interactSoundEffect;
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
            interactSoundEffect.Play();
            isOpen = true;
            // Change the sprite to the open door sprite
            spriteRenderer.sprite = openSprite;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
