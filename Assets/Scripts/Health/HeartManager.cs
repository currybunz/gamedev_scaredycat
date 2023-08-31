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
    private UIManager uiManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        animated = GetComponent<Animator>();
        uiManager = FindObjectOfType<UIManager>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            animated.SetTrigger("hurt");
            //reset player's position to starting position
            transform.position = new Vector3(-4.2f, -2.34f, 0.082f);
            //iframes
        }
        else
        {
            if (!dead)
            {
                animated.SetTrigger("death");
                /*GetComponent<PlayerMovement>().enabled = false;*/
                dead = true;

                //show gameover screen
                uiManager.GameOver();
            }
        }
    }
    // public void AddHealth(float _value)
    // {
    //     currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    // }

}