using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCollector : MonoBehaviour
{
    // [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private AudioSource potionSoundEffect;
    [SerializeField] private AudioSource kingSoundEffect;
    [SerializeField] private Text pontsText;

    private int Points = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.CompareTag("Potion") || collision.gameObject.CompareTag("King"))
        {
            // collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            if (collision.gameObject.CompareTag("Potion"))
            {
                potionSoundEffect.Play();
                Points += 100;
            }
            else if (collision.gameObject.CompareTag("King"))
            {
                kingSoundEffect.Play();
                Points += 300;
            }
            pontsText.text = "Points: " + Points.ToString();
        }
    }

}


