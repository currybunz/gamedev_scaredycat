using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints;
    private int currentWaypontIndex = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
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
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypontIndex].transform.position, Time.deltaTime * speed);
    }
}
