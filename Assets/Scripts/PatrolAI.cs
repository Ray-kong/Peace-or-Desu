using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int targetPoint;
    public  float Nspeed = 3f;
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
    var position = transform.position;
    position = Vector3.MoveTowards(position, patrolPoints[targetPoint].position, Nspeed * Time.deltaTime);
    transform.position = position;
}

    public void SpeedDown()
    {
        
        Nspeed = 5f;
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