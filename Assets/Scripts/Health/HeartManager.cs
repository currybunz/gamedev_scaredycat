using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator animated;
    private bool dead;

    [SerializeField] private float duration;
    [SerializeField] private int flashNumber;
    private SpriteRenderer spriteR;
    
    [SerializeField] private AudioSource deathSoundEffect;

    private void Awake()
    {
        currentHealth = startingHealth;
        animated = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        deathSoundEffect.Play();

        if (currentHealth > 0)
        {
            animated.SetTrigger("hurt");
            //iframes, makes player invulnerable for a certain duration
            StartCoroutine(Invulnerability());
            //resets player position to starting point
            transform.position = new Vector3(-4.2f, -2.34f, 1f);
        }
        else
        {
            if (!dead)
            {
                Debug.Log("Game Over!");
                PlayerManager.isGameOver = true;
                animated.SetTrigger("death");
                dead = true;

                /*gameObject.SetActive(false);*/


                GetComponent<PlayerMovement>().enabled = false;
            }
        }
    }
     public void AddHealth(float _value)
     {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
     }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i=0; i < flashNumber; i++)
        {
            spriteR.color = new Color(1, 0, 0, 0.3f);
            yield return new WaitForSeconds(duration / (flashNumber * 2));
            spriteR.color = Color.white;
            yield return new WaitForSeconds(duration / (flashNumber * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }


}