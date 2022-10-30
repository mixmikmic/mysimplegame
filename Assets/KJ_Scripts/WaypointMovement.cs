using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypoiuntIndex = 0;

    [SerializeField] float speed = 1f;

    void Update()
    {
        if(Vector3.Distance(transform.position, waypoints[currentWaypoiuntIndex].transform.position) < .1f)
        {
            currentWaypoiuntIndex++;
            if(currentWaypoiuntIndex >= waypoints.Length)
            {
                currentWaypoiuntIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoiuntIndex].transform.position, speed * Time.deltaTime);
    }
}
