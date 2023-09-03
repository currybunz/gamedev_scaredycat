using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectionSoundEffect;
    
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
        }
    }

}
