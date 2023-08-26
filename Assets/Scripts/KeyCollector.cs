using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectionSoundEffect;
    public GameObject Player;
    public float speed = 4f;

    private float distance;
    private bool isCollected = false;
    public bool IsCollected
    {
        get { return isCollected; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(isCollected)
        {
            Vector2 targetPosition = Player.transform.position;
            distance = Vector2.Distance(transform.position, Player.transform.position);
            Vector2 direction = Player.transform.position - transform.position;
            if(distance < 3)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = targetPosition;
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            collectionSoundEffect.Play();
            isCollected = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}