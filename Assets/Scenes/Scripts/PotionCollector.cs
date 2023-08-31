using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private Text pontsText;

    private int Potion = 0;
    
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
         if(collision.gameObject.CompareTag("Potion"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Potion += 100;
            pontsText.text = "Points: " + Potion;
        }
    }

}
