using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int targetPoint;
    public float speed;
    private bool movingForwards = true; // New variable to keep track of direction
    
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolPoints[targetPoint].position)
        {
            UpdateTargetPoint();
            Debug.Log("Target Int: " + targetPoint);
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void UpdateTargetPoint()
    {
        if(movingForwards)
        {
            targetPoint++;
            if(targetPoint >= patrolPoints.Length)
            {
                targetPoint = patrolPoints.Length - 2; // Set to second last point
                movingForwards = false; // Change direction
            }
        }
        else // moving backwards
        {
            targetPoint--;
            if(targetPoint < 0)
            {
                targetPoint = 1; // Set to second point
                movingForwards = true; // Change direction
            }
        }
    }
}