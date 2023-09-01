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
    

    private void Awake()
    {
        currentHealth = startingHealth;
        animated = GetComponent<Animator>();

    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            animated.SetTrigger("hurt");
            //reset player's position to starting position
            transform.position = new Vector3(-4.2f, 0f, 0.082f);
            //iframes
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

}