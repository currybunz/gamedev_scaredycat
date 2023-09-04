using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypontIndex = 0;

    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypontIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypontIndex++;
            if(currentWaypontIndex >= waypoints.Length)
            {
                currentWaypontIndex = 0;
            }
        }
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypontIndex].transform.position, Time.deltaTime * speed);
    }
}
