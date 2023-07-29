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

       
    if (transform.position == patrolPoints[targetPoint].position)
    {
        UpdateTargetPoint();
        //Debug.Log("Target Int: " + targetPoint);
    }
    
    // Calculate the direction of movement
    Vector3 direction = patrolPoints[targetPoint].position - transform.position;

    // Get the angle to the target point
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    // Subtract 90 degrees to make the top of the object face the direction of movement
    // (assuming that the top of the object points up when rotation is 0)
    angle -= 90;

    // Rotate the object to face the direction of movement
    transform.rotation = Quaternion.Euler(0, 0, -angle);

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