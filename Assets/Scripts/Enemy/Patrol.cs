using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private Vector3 target;
    public bool hasReachedPointB = false;

    void Start()
    {
        target = pointB.position; // Start by moving towards point B
    }

    void Update()
    {
        PatrolBetweenPoints();// Continiusly travel to point b
    }

    //Move at a speed to a chosen point
    void PatrolBetweenPoints()
    {
        if (!hasReachedPointB)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
            {
                hasReachedPointB = true; // Stop moving when reached point B, not much a patrol script eh
            }
        }
    }


}
